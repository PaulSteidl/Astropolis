// src* = https://github.com/andrew-raphael-lukasik/BFN
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class BFN_ExampleComponent : MonoBehaviour
{
    [Header("Text")]
    public string _money_display;

    [Space(5)]
    [SerializeField] BFN _a = new BFN();
    [SerializeField] BFN _b = new BFN();
    [SerializeField] OP _operator = OP.Add;
    [SerializeField] BFN _result = (BFN)0;
    public MoneyManager _moneyManager;


    public enum OP : byte { Add, Subtract, Multiply, Divide }

#if UNITY_EDITOR
    void Update()
    {
        _a.coefficient = _moneyManager.money;
        _a.exponent = 1;
        switch (_operator)
        {
            case OP.Add: _result = _a + _b; break;
            case OP.Subtract: _result = _a - _b; break;
            case OP.Multiply: _result = _a * _b; break;
            case OP.Divide: _result = _a / _b; break;
            default: throw new System.NotImplementedException();
        }

    }
#endif

    void Awake()
    {
        _moneyManager = GameObject.FindObjectOfType<MoneyManager>();
        Debug.Log(_moneyManager.gameObject);
        Debug.Log($"{_a} {_operator} {_b} = {_result}");

    }

    public string Shorten_number(float a)
    {
        if (a != 0)
        {
            float b = 0;
            BFN result;
            string _resultString;

            _a = (BFN)_moneyManager.money;
            switch (_operator)
            {
                case OP.Add: result = (BFN)a + b; break;
                case OP.Subtract: result = (BFN)a - b; break;
                case OP.Multiply: result = (BFN)a * b; break;
                case OP.Divide: result = (BFN)a / b; break;
                default: throw new System.NotImplementedException();
            }

            _resultString = result.ToString();

            // Debug.Log(_resultString);

            if (_resultString.Contains(","))
            {
                int commaIndex = _resultString.IndexOf(",");
                if (commaIndex != -1)
                {
                    string[] parts = _resultString.Split(',');
                    if (parts.Length == 2)
                    {
                        string decimals = parts[1];
                        if (decimals.Length > 2)
                        {
                            _resultString = parts[0] + "," + decimals.Substring(0, 2) + decimals.Substring(decimals.Length - 2);
                        }
                    }
                }
            }
            else
            {
                // Handle the case where the number might not have a comma but needs to be limited to 2 decimal places
                if (_resultString.Contains("."))
                {
                    int dotIndex = _resultString.IndexOf(".");
                    if (dotIndex != -1)
                    {
                        string[] parts = _resultString.Split('.');
                        if (parts.Length == 2)
                        {
                            string decimals = parts[1];
                            if (decimals.Length > 2)
                            {
                                _resultString = parts[0] + "." + decimals.Substring(0, 2) + decimals.Substring(decimals.Length - 2);
                            }
                        }
                    }
                }
            }

            return _resultString;
        }
        else
        {
            return "0";
        }
    }

}

