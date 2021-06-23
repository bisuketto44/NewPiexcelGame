using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coment_HiperChat_DataBaseContoroller : MonoBehaviour
{
    [Tooltip("通常コメント内容一覧")]
    public string[] NomalComents;

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
            "最近ずっと見てる",
            "ハマってます～",
            "結構稼いでるんじゃない？",
            "新作のゲーム配信してほしい！",
            "なんでもできるね",
            "最近勢いがある",
            "かわいい",
            "今日も見に来たよー",
            "とりあえずこの配信！",
            "なんでもできるね",
            "今日のごはんは何食べた？",
            "明日テストなのに見るのやめられない",
            "眠いけどみちゃう",
            "今日はいつまでやるの？",
            "この間やった配信の続きまだ～？",
            "おまえが天下を取る日も近い",
            "空いた時間にやってね",
            "人生いろいろある",
            "体調に気を付けてね",
            "怪物エネルギーよりイエローブル派",
            "やったね",
            "それはあるある",
            "おもろ！",
            "とりあえず大声出せばいいってもんじゃない",
            "そんな日もあるべ",
            "発想が素晴らしい",
            "ちなかなり面白い",
            "バイトの前に精神統一してます",
            "俺は好きだったよ",
            "ご飯いってきます",
            "飯 フルバイしに行きます",
            "間違ってぬけちゃったんですけど眠いので寝ますおつです",
            "どうなっちゃうの?!",
            "目から鱗だ",

        };

        //前回のデータが存在する場合は初期化を実行しない
        if (SaveData.Instance.PreviousDataIsAvailableOrNot == true)
        {
            return;
        }

        //黄色コメント(12 → 15)

        SaveData.Instance.YellowChatComents.Add(new Base_YellowChat_Coment(false, "いつもお疲れ様です！毎日楽しみに見てます！", "優しくカジュアルな視聴者が送る ハイパーチャット", "お疲れ様"));
        SaveData.Instance.YellowChatComents.Add(new Base_YellowChat_Coment(false, "初めてのハイパーチャットです！", "初々しさがある、ハイパーチャット", "初めて"));
        SaveData.Instance.YellowChatComents.Add(new Base_YellowChat_Coment(false, "一番好きな配信者!!", "熱烈なファンからの ラブコールチャット", "一番"));
        SaveData.Instance.YellowChatComents.Add(new Base_YellowChat_Coment(false, "次は何の配信するのかな～", "次回の配信も絶対来てくれそうな ハイパーチャット", "期待"));
        SaveData.Instance.YellowChatComents.Add(new Base_YellowChat_Coment(false, "少量ながら受け取って", "謙虚さの残るハイパーチャット", "少量"));
        SaveData.Instance.YellowChatComents.Add(new Base_YellowChat_Coment(false, "だんだん人増えてきたね！", "配信を昔から見てくれているが分かる ハイパーチャット", "だんだん"));
        SaveData.Instance.YellowChatComents.Add(new Base_YellowChat_Coment(false, "チャンネル登録少ない時から見てます", "配信を昔から見てくれていることが分かる ハイパーチャット、その2", "古参"));
        SaveData.Instance.YellowChatComents.Add(new Base_YellowChat_Coment(false, "これからも応援していくよー！", "シンプルに嬉しい ハイパーチャット", "これからも"));
        SaveData.Instance.YellowChatComents.Add(new Base_YellowChat_Coment(false, "給料入ったのでハイパーチャットします", "根強いファンからの ハイパーチャット", "給料日"));
        SaveData.Instance.YellowChatComents.Add(new Base_YellowChat_Coment(false, "次の配信はこの間発売した新作のゲーム配信してよ！", "新作ゲームが大好きな ハイパーチャット", "指示"));
        SaveData.Instance.YellowChatComents.Add(new Base_YellowChat_Coment(false, "今回も最高の配信！", "次回も頑張ろうと思う ハイパーチャット", "今回も"));
        SaveData.Instance.YellowChatComents.Add(new Base_YellowChat_Coment(false, "No1配信者になれる日も近い！", "先見の明がある ハイパーチャット", "下剋上"));
        SaveData.Instance.YellowChatComents.Add(new Base_YellowChat_Coment(false, "久々に笑った！", "普段が気になる ハイパーチャット", "久々の"));
        SaveData.Instance.YellowChatComents.Add(new Base_YellowChat_Coment(false, "無理しない程度に楽しんで配信してください！", "気遣いがありがたい ハイパーチャット", "気遣い"));
        SaveData.Instance.YellowChatComents.Add(new Base_YellowChat_Coment(false, "毎回逃さずみてるよ！！", "毎回来てくれていそうな ハイパーチャット", "常連"));


        //橙色コメント(9 → 12)

        SaveData.Instance.OrangeChatComents.Add(new Base_OrangeChat_Coment(false, "フル課金で投げるのが俺の人生だった。だからお前と俺は兄弟だった。お前も同じだったから。", "親愛なる兄弟に向けたハイパーチャット スピードの出しすぎには注意", "チャージャー"));
        SaveData.Instance.OrangeChatComents.Add(new Base_OrangeChat_Coment(false, "おまえは今まで投げたハイパーチャットの数をおぼえているのか？", "自身の欲を満たすため 数えきれない数投げた者からの ハイパーチャット", "幻の血液"));
        SaveData.Instance.OrangeChatComents.Add(new Base_OrangeChat_Coment(false, "配信をナメンなよ。まだまだだね。", "小生意気なハイパー千ャット", "ツイスト"));
        SaveData.Instance.OrangeChatComents.Add(new Base_OrangeChat_Coment(false, "君の未来はまだ決まってない。誰のでもそうだ。未来は自分で切り開くものなんだ。だから頑張れよ", "未来からのハイパーチャット 愛車はDMC-12らしい", "時計台"));
        SaveData.Instance.OrangeChatComents.Add(new Base_OrangeChat_Coment(false, "ハイパーチャット おじさん だよ きみに これを あげちゃうよ", "無償で高価なものをくれるハイパーチャット", "5000"));
        SaveData.Instance.OrangeChatComents.Add(new Base_OrangeChat_Coment(false, "ハイパーチャットあげる！報酬はね･･･デート一回！", "花売りからのハイパーチャット", "忘らるる町"));
        SaveData.Instance.OrangeChatComents.Add(new Base_OrangeChat_Coment(false, "今でも時々目が覚めるかい？明け方に配信開始音を聞くかい？", "狂気的なハイパーチャット 変わったものが好物", "シープ"));
        SaveData.Instance.OrangeChatComents.Add(new Base_OrangeChat_Coment(false, "配信は!!!終わらねエ!!!", "海を駆けるハイパーチャット 配信は疲れたら終わる", "危機一髪"));
        SaveData.Instance.OrangeChatComents.Add(new Base_OrangeChat_Coment(false, "おまえが信じるおまえを信じろ！", "背中を押してくれる ハイパーチャット", "兄貴"));
        SaveData.Instance.OrangeChatComents.Add(new Base_OrangeChat_Coment(false, "私たち大人はお前たちにこんなハイパーチャットしか残せなかった。許しておくれ", "偉い人からのハイパーチャット", "ディンネルリア"));
        SaveData.Instance.OrangeChatComents.Add(new Base_OrangeChat_Coment(false, "名前が知りたい。このハイパーチャットに名前を書いてくれ。", "ハイパーチャットの合理的な売り文句として使えそうなハイパーチャット 一攫千金を狙っているらしい", "狼"));
        SaveData.Instance.OrangeChatComents.Add(new Base_OrangeChat_Coment(false, "人生に やり直しボタンは 無い　続けるボタンは ある ハイパーチャットも ある", "核心をつく者からのハイパーチャット 貝が好きらしい", "マリンスーツ"));

        //赤色コメント(5 →9)
        SaveData.Instance.RedChatComents.Add(new Base_RedChat_Coment(false, "次のハイパーチャットで告白しようと思ってる。この配信を見てるみんなには、悪いけど。抜け駆けで。給料日お金入るから。ハイチャして。そこで気持ち伝える。びっくりするかもだけど。もう気持ちを伝えるのを我慢できないから。", "愛情表現の仕方は　人それぞれ", "告白"));
        SaveData.Instance.RedChatComents.Add(new Base_RedChat_Coment(false, "暗く困難な時が待っている。正しいことと容易いことの選択が迫られる。だけど忘れないで、君には僕たちがいる。ひとりではないよ。", "偉大なるおじいさんからのハイパーチャット 魔法が使えるとか 使えないとか", "フオクス"));
        SaveData.Instance.RedChatComents.Add(new Base_RedChat_Coment(false, "高額なハイパーチャットと応援コメントでは、配信者も毒付かないと分かったの。ダメなのは低額ハイチャなんです。このハイチャですら安いんです。なぜ、誰が配信をこんなふうにしてしまったのでしょう。", "遠い谷からのハイパーチャット 人の愚かさと愛おしさを説く", "ルタフエ"));
        SaveData.Instance.RedChatComents.Add(new Base_RedChat_Coment(false, "帰ってきた無限麻雀男", "晴れの日が少ない土地に幽閉されているらしい", "TY"));
        SaveData.Instance.RedChatComents.Add(new Base_RedChat_Coment(false, "もし　ぼくの　いうことをきけば　ぜんざいさんの　はんぶんを　やろう", "世界を支配する者からのハイパーチャット さぁ ゆっくり やすむがよい!", "はい"));
        SaveData.Instance.RedChatComents.Add(new Base_RedChat_Coment(false, "ありがとう。配信をしているとかわいいな。帰ったら電話番号を教えてくれ。", "とある任務についた者からのハイパーチャット ウィルスが きらい", "ラングラー"));
        SaveData.Instance.RedChatComents.Add(new Base_RedChat_Coment(false, "王、悪魔、何とでも呼べい。配信者はそこでハイパーチャットをした者の名前などすくに忘れてしまうのだ", "なんでも飲み込むハイパーチャット 心強いのに 不人気", "W← →R"));
        SaveData.Instance.RedChatComents.Add(new Base_RedChat_Coment(false, "ああああ", "めんどくさくなった人からのハイパーチャット でもやめは しない", "電源切れ"));
        SaveData.Instance.RedChatComents.Add(new Base_RedChat_Coment(false, "初ハイチャ…ども… 俺みたいな中3で配信見てる腐れ野郎、他に、いますかっていねーか、はは かたや俺は電子の砂漠で配信を見て、呟くんすわit’a true wolrd．狂ってる？それ、誉め言葉ね。", "誰にでも黒い歴史は ある そんな ハイパーチャット", "ブラックヒストリー"));


    }
}
