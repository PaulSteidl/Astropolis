using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] sources; // Array von AudioSources
    private int currentSourceIndex = -1;

    void Start()
    {
        StartCoroutine(PlayMusic());
    }

    private IEnumerator PlayMusic()
    {
        while (true)
        {
            // Wählt eine zufällige AudioSource aus
            int nextSourceIndex;
            do
            {
                nextSourceIndex = Random.Range(0, sources.Length);
            } while (nextSourceIndex == currentSourceIndex);

            currentSourceIndex = nextSourceIndex;
            AudioSource source = sources[currentSourceIndex];
            source.volume = 0f;
            source.Play();

            // Fade-In
            yield return StartCoroutine(Fade(true, source, 4f, 1f));

            // Warten bis der Clip fast zu Ende ist
            float clipLength = source.clip.length;
            yield return new WaitForSeconds(clipLength - 4f); // 4 Sekunden für Fade-Out

            // Fade-Out
            yield return StartCoroutine(Fade(false, source, 4f, 0f));

            // Stoppt die aktuelle AudioSource nach dem Fade-Out
            source.Stop();
        }
    }

    public IEnumerator Fade(bool fadeIn, AudioSource source, float duration, float targetVolume)
    {
        float time = 0f;
        float startVol = source.volume;

        while (time < duration)
        {
            time += Time.deltaTime;
            source.volume = Mathf.Lerp(startVol, targetVolume, time / duration);
            yield return null;
        }

        source.volume = targetVolume;
    }
}
