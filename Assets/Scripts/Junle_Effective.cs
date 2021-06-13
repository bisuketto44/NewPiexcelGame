using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Junle_Effective
{
    public bool OnorOff;
    public int BaseIncrease;
    public string JunleName;

    public Junle_Effective(bool ConoreOff, int CBaseIncrese, string CJunleName)
    {
        OnorOff = ConoreOff;
        BaseIncrease = CBaseIncrese;
        JunleName = CJunleName;

    }
}
