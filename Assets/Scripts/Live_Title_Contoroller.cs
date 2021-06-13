using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TitleControllerオブジェクトに付与。選ばれたジャンルから配信タイトルを自動で付ける。
public class Live_Title_Contoroller : MonoBehaviour
{
    [Tooltip("配信のタイトルを表示するテキスト")]
    [SerializeField]
    private Text LiveTitleText;

    [Tooltip("ジャンル情報を格納するデータリスト")]
    [SerializeField]
    Live_Data_Information LiveDataInfomation;

    [Tooltip("チャンネルに関する情報データ")]
    [SerializeField]
    Channel_Infomation_Update channelinfomationupdate;

    string TitleName;
    string[] Titles;

    //ぞれぞれのジャンルを何回放送したかをカウントする変数
    private int[] CountOfJunle;

    void Awake()
    {
        CountOfJunle = new int[6];
        Titles = new string[] { "ゲーム配信", "歌配信", "ダンス配信", "雑談配信", "お絵描き配信", "コラボ配信" };
    }

    //選択されたジャンルを読み取って配信タイトルとして決定する
    public string DicideLiveTitle()
    {
        for (int i = 0; i < LiveDataInfomation.JuneEffective.Count; i++)
        {
            if (LiveDataInfomation.JuneEffective[i].OnorOff == true)
            {
                //各ジャンルの回数を計算
                CountOfJunle[i]++;
                //タイトル名を決定
                TitleName = JudgeJunle(i) + CountOfJunle[i].ToString();
                //配信画面にタイトルを表示
                LiveTitleText.text = channelinfomationupdate.ChannelNameString + "の" + TitleName;


            }
        }
        //string型で配信タイトルを返す
        return TitleName;
    }

    //ジャンル名を返すメソッド
    private string JudgeJunle(int i)
    {
        return Titles[i];
    }


}
