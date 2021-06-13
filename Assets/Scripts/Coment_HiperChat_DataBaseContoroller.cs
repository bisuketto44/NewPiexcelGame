using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coment_HiperChat_DataBaseContoroller : MonoBehaviour
{
    [Tooltip("通常コメント内容一覧")]
    public string[] NomalComents;

    public List<Base_YellowChat_Coment> YellowChatComents;
    public List<Base_OrangeChat_Coment> OrangeChatComents;
    public List<Base_RedChat_Coment> RedChatComents;


    void Awake()
    {
        //通常コメント
        NomalComents = new string[]
        {
            "面白すぎワロタ",
            "最高！",
            "今日は何時までやるの？",
            "初見です",
            "もっと見たい！",
            "wwwwww",
            "それは微妙かも",
            "お前がナンバーワン",
            "うける",
            "いつもよりテンション高いね",
            "眠たくなってきた",
            "でもそれあなたの意見ですよね？",
            "声が良い！",

        };

        //黄色コメント
        YellowChatComents = new List<Base_YellowChat_Coment>();
        YellowChatComents.Add(new Base_YellowChat_Coment(false, "いつもお疲れ様です！毎日楽しみに見てます！"));
        YellowChatComents.Add(new Base_YellowChat_Coment(false, "初めてのハイパーチャットです！"));
        YellowChatComents.Add(new Base_YellowChat_Coment(false, "いつもお疲れ様です！"));
        YellowChatComents.Add(new Base_YellowChat_Coment(false, "次は何の配信するのかな～"));
        YellowChatComents.Add(new Base_YellowChat_Coment(false, "少量ながら受け取って"));
        YellowChatComents.Add(new Base_YellowChat_Coment(false, "だんだん人増えてきたね！"));
        YellowChatComents.Add(new Base_YellowChat_Coment(false, "チャンネル登録少ない時から見てます"));
        YellowChatComents.Add(new Base_YellowChat_Coment(false, "これからも応援していくよー！"));
        YellowChatComents.Add(new Base_YellowChat_Coment(false, "給料入ったのでハイパーチャットします"));
        YellowChatComents.Add(new Base_YellowChat_Coment(false, "次の配信はこの間発売した新作のゲーム実況してよ！"));
        YellowChatComents.Add(new Base_YellowChat_Coment(false, "今回も最高の配信！"));
        YellowChatComents.Add(new Base_YellowChat_Coment(false, "No1配信者になれる日も近い！"));

        //橙色コメント
        OrangeChatComents = new List<Base_OrangeChat_Coment>();
        OrangeChatComents.Add(new Base_OrangeChat_Coment(false, "フル課金で投げるのが俺の人生だった。だからお前と俺は兄弟だった。お前も同じだったから。"));
        OrangeChatComents.Add(new Base_OrangeChat_Coment(false, "おまえは今まで投げたハイパーチャットの数をおぼえているのか？"));
        OrangeChatComents.Add(new Base_OrangeChat_Coment(false, "配信をナメンなよ。まだまだだね。"));
        OrangeChatComents.Add(new Base_OrangeChat_Coment(false, "君の未来はまだ決まってない。誰のでもそうだ。未来は自分で切り開くものなんだ。だから頑張れよ"));
        OrangeChatComents.Add(new Base_OrangeChat_Coment(false, "ハイパーチャット おじさん だよ きみに これを あげちゃうよ"));
        OrangeChatComents.Add(new Base_OrangeChat_Coment(false, "ハイパーチャットあげる！報酬はね･･･デート一回！"));
        OrangeChatComents.Add(new Base_OrangeChat_Coment(false, "今でも時々目が覚めるかい？明け方に配信開始音を聞くかい？"));
        OrangeChatComents.Add(new Base_OrangeChat_Coment(false, "配信は!!!終わらねエ!!!"));
        OrangeChatComents.Add(new Base_OrangeChat_Coment(false, "おまえが信じるおまえを信じてくれよな。"));


        //赤色コメント
        RedChatComents = new List<Base_RedChat_Coment>();
        RedChatComents.Add(new Base_RedChat_Coment(false, "次のハイパーチャットで告白しようと思ってる。この配信を見てるみんなには、悪いけど。抜け駆けで。給料日お金入るから。ハイチャして。そこで気持ち伝える。びっくりするかもだけど。もう気持ちを伝えるのを我慢できないから。"));
        RedChatComents.Add(new Base_RedChat_Coment(false, "暗く困難な時が待っている。正しいことと容易いことの選択が迫られる。だけど忘れないで、君には僕たちがいる。ひとりではないよ。"));
        RedChatComents.Add(new Base_RedChat_Coment(false, "高額なハイパーチャットと応援コメントでは、配信者も毒付かないと分かったの。ダメなのは低額ハイチャなんです。このハイチャですら安いんです。なぜ、誰が配信をこんなふうにしてしまったのでしょう。"));
        RedChatComents.Add(new Base_RedChat_Coment(false, "帰ってきた無限麻雀男"));
        RedChatComents.Add(new Base_RedChat_Coment(false, "もし　ぼくの　いうことをきけば　ぜんざいさんの　はんぶんを　やろう。"));


    }
}
