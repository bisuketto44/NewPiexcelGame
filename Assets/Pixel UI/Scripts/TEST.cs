using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    [SerializeField]
    private LvUp_EXP EXP;

    public void OnClick()
    {
        EXP.GiveExP(100);

    }
}
