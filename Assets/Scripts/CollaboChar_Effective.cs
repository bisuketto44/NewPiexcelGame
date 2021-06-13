using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CollaboChar_Effective
{
    public bool OnOrOff;
    public float CollaboChareMuptipure;
    public string CharName;

    public CollaboChar_Effective(bool COnOrOff, float CCollaboChareMutipure, string CCharName)
    {
        OnOrOff = COnOrOff;
        CollaboChareMuptipure = CCollaboChareMutipure;
        CharName = CCharName;
    }

}
