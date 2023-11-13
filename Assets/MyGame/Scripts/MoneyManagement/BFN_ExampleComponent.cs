// src* = https://github.com/andrew-raphael-lukasik/BFN
using UnityEngine;
public class BFN_ExampleComponent : MonoBehaviour
{
	[SerializeField] BFN _a = new BFN();
	[SerializeField] BFN _b = new BFN();
	[SerializeField] OP _operator = OP.Add;
	[SerializeField] BFN _result = (BFN) 0;
	MoneyManager _moneyManager;

	public enum OP : byte { Add , Subtract , Multiply , Divide }

	#if UNITY_EDITOR
	void Update ()
	{
        _a = (BFN)_moneyManager.money;
        switch ( _operator )
		{
			case OP.Add:		_result = _a + _b; break;
			case OP.Subtract:	_result = _a - _b; break;
			case OP.Multiply:	_result = _a * _b; break;
			case OP.Divide:		_result = _a / _b; break;
			default: throw new System.NotImplementedException();
		}
    }
	#endif
	
	void Start ()
	{
		_moneyManager = GameObject.FindObjectOfType<MoneyManager>();		
		Debug.Log($"{_a} {_operator} {_b} = {_result}");
		
	}

}
