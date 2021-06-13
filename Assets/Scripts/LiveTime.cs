using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LiveTime
{
    public bool OnOrOff;
    public int Livetime;
    public string name;

    public LiveTime(bool COnOrOff, int CLiveTime, string Cname)
    {
        OnOrOff = COnOrOff;
        Livetime = CLiveTime;
        name = Cname;
    }
}
