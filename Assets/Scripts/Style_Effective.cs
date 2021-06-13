using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Style_Effective
{
    public bool OnOrOff;
    public int BaseIncrease;
    public string StyleName;

    public Style_Effective(bool ConOreOff, int CBaseIncrease, string CStyaleName)
    {
        OnOrOff = ConOreOff;
        BaseIncrease = CBaseIncrease;
        StyleName = CStyaleName;

    }

}
