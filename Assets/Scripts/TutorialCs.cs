using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCs : MonoBehaviour
{

    private SE_Contoroller sE_Contoroller;

    [SerializeField]
    private GameObject ChangeChannnelNamePanel;

    void Awake()
    {
        sE_Contoroller = GameObject.FindWithTag("SE").GetComponent<SE_Contoroller>();
    }

    public void InactivateAndFlagUp()
    {
        this.gameObject.SetActive(false);
        sE_Contoroller.PlayCancelSound();

        //=================================================================================
        //初回時はそのままチャンネル名決定へと移行
        //=================================================================================
        if (SaveData.Instance.PreviousDataIsAvailableOrNot == false)
        {
            ChangeChannnelNamePanel.SetActive(true);
        }

    }

    public void Activate()
    {
        this.gameObject.SetActive(true);
        sE_Contoroller.PlayDicideSound();
    }
}
