using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentChange : MonoBehaviour
{
    [Tooltip("表示したい内容達")]
    [SerializeField]
    private GameObject[] Contents;

    [Tooltip("非表示にし、次表示したときのデフォルトの内容")]
    [SerializeField]
    private GameObject DefaultContent;

    [Tooltip("次を表示するボタン")]
    [SerializeField]
    private Button NextBtn;

    [Tooltip("ひとつ前を表示するボタン")]
    [SerializeField]
    private Button BackBtn;

    private int Count = 0;

    private SE_Contoroller sE_Contoroller;


    void Awake()
    {
        BackBtn.interactable = false;
        sE_Contoroller = GameObject.FindWithTag("SE").GetComponent<SE_Contoroller>();
    }

    /// <summary>
    /// 次の内容を表示する(最後の内容だった場合はボタン機能をoffにする)
    /// </summary>
    public void NextContent()
    {
        //=================================================================================
        // カウントを増やして次の内容を表示、前の内容を非表示にする
        //=================================================================================
        Count++;
        Contents[Count].SetActive(true);
        Contents[Count - 1].SetActive(false);

        //=================================================================================
        // 内容が最後まで表示されたら次へボタンを使えないように、また内容が最初のものでなくなったら、戻るボタンを使えるように
        //=================================================================================
        if (Count == Contents.Length - 1)
        {
            NextBtn.interactable = false;

        }
        if (Count != 0)
        {
            BackBtn.interactable = true;
        }
        sE_Contoroller.PlayDicideSound();

    }

    /// <summary>
    /// ひとつ前の内容に戻る(一番最初の内容だった場合はボタン機能をOffにする)
    /// </summary>
    public void BackContent()
    {
        Count--;
        Contents[Count].SetActive(true);
        Contents[Count + 1].SetActive(false);

        //=================================================================================
        // 上記の逆
        //=================================================================================

        if (Count != Contents.Length - 1)
        {
            NextBtn.interactable = true;

        }
        if (Count == 0)
        {
            BackBtn.interactable = false;
        }
        sE_Contoroller.PlayDicideSound();

    }

    /// <summary>
    /// デフォルトの内容に切り替え
    /// </summary>
    void OnDisable()
    {
        Contents[Count].SetActive(false);
        Contents[0].SetActive(true);

        NextBtn.interactable = true;
        BackBtn.interactable = false;

        Count = 0;

    }
}
