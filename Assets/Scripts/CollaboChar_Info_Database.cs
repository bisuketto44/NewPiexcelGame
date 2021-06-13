using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollaboChar_Info_Database : MonoBehaviour
{
    public List<CollaboChar_Infomation> CollaboCharinfo;

    [Tooltip("チャンネル登録者数の情報を獲得")]
    [SerializeField]
    private Channel_Infomation_Update ChannelInfomationUpdate;

    [Tooltip("対象のコラボキャラクター達")]
    [SerializeField]
    private GameObject[] CollaboCharcters;

    [Tooltip("新しいコラボキャラが増えたことを告知するパネル")]
    [SerializeField]
    GameObject NewEarndPanel;

    int currentCount = 2;
    int maxCount = 11;
    int nowsucsriver = 0;

    void Awake()
    {
        CollaboCharinfo = new List<CollaboChar_Infomation>();

        CollaboCharinfo.Add(new CollaboChar_Infomation("ニック", 1, "しがない配信者。一攫千金を目指し奮闘中。", "★", 0));
        CollaboCharinfo.Add(new CollaboChar_Infomation("アメリア", 2, "駆け出し配信者。ゲーム実況が得意らしい。", "★", 0));
        CollaboCharinfo.Add(new CollaboChar_Infomation("親方", 3, "配信者を始める前は･･･。強面だが一部の視聴者からは密かに人気がある。", "★★", 5000));
        CollaboCharinfo.Add(new CollaboChar_Infomation("ルーシーシェフ", 4, "料理を得意とする配信者。魚はどうやらさばけないらしい。", "★★", 7500));
        CollaboCharinfo.Add(new CollaboChar_Infomation("オランジーノ", 5, "普段は美容師。1カ月に1回髪色が変わることで有名。", "★★★", 12500));
        CollaboCharinfo.Add(new CollaboChar_Infomation("アンドロイフォン", 6, "スマホ大好き。常にスマホから24時間配信を行う猛者。", "★★★", 27500));
        CollaboCharinfo.Add(new CollaboChar_Infomation("新伊麦一郎", 7, "80歳を超えて配信者デビュー。高齢者層からの人気を集める。", "★★★★", 50000));
        CollaboCharinfo.Add(new CollaboChar_Infomation("ヨウドルちゃん", 8, "小さく童顔。自称は５歳らしい。軽快なトークで若年層に人気。", "★★★★", 100000));
        CollaboCharinfo.Add(new CollaboChar_Infomation("ゴーストン", 9, "霊界から参戦。人間には不可能な芸風で大人気の配信者。", "★★★★★", 200000));
        CollaboCharinfo.Add(new CollaboChar_Infomation("ウォーキングアンデット", 10, "アメリカドラマ出演経験あり。世界を股にかける配信者。", "★★★★★★", 300000));
        CollaboCharinfo.Add(new CollaboChar_Infomation("ビビデバビデ嬢", 11, "噂によると魔女の血を引くお嬢様。ド派手な配信で世界を席巻する。", "★★★★★★★", 500000));
        CollaboCharinfo.Add(new CollaboChar_Infomation("Mr.サンタクロース", 12, "世界中でプレゼント企画を行う大人気者。世界中で大人気の配信者。", "★★★★★★★★", 1000000));
    }

    public void ActivateCollabocharcter(int subscriver)
    {
        if (currentCount == maxCount)
        {
            return;
        }
        //登録者
        nowsucsriver = subscriver;

        while (nowsucsriver >= CollaboCharinfo[currentCount].RequiredRegistrants)
        {
            CollaboCharcters[currentCount].gameObject.SetActive(true);
            NewEarndPanel.SetActive(true);
            currentCount++;
            if (currentCount == maxCount)
            {
                return;
            }
        }

    }
}
