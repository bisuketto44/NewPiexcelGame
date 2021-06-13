using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Motivation_Effective
{
    public bool OnOrOff;
    public float Motivation_Percent;
    public int ConsMotivation;

    public Motivation_Effective(bool COnOrOff, float CMotivation_Precent, int consmotivation)
    {
        OnOrOff = COnOrOff;
        Motivation_Percent = CMotivation_Precent;
        ConsMotivation = consmotivation;
    }
}
