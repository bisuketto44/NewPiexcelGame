using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Linq;

//1 : Panelを作成無限スクロールならUnrestricted , 制限スクロールならElastic
//2 : 下層にゲームオブジェクトを作成し、横ならpivot x = 0 縦なら pivot y = 1設定
//3 : 各種スクリプトを付与。(制限ならXかYを指定数*Baseの大きさで増やす)
//4 : そのさらに下層にContentの基準となるゲームオブジェクトを作成し、pivotとアンカーを同じく設定。Item用のスクリプト付与
//5 : その下に表示したいイメージやテキストを中央固定アンカーで表示し、Item用スクリプトで書き換えを可能にしておく。
//6 : 制限付きの場合はスクロールバーを用意し、ContentにViewを、スクロールバーの指定方向にスクロールバーをSctollRectに登録しておく
public class InfinityScoll : UIBehaviour
{
    //基準となる大きさ
    [SerializeField]
    private RectTransform itemPrototype;

    //何個まで表示して使いまわすか
    [SerializeField, Range(0, 30)]
    public int instantateItemCount = 9;

    //スクロールの方向
    [SerializeField]
    private Direction direction;

    //下記のClassをインスタンス化
    public OnItemPositionChange onUpdateItem = new OnItemPositionChange();

    //前の値を保持しない、ReactTransFormでLinkedListをインスタンス化
    [System.NonSerialized]
    public LinkedList<RectTransform> itemList = new LinkedList<RectTransform>();
    public List<GameObject> ItemLIstGameObject = new List<GameObject>();

    protected float diffPreFramePosition = 0;

    protected int currentItemNo = 0;

    //スクロールの振り分け
    public enum Direction
    {
        Vertical,
        Horizontal,
    }

    // cache component

    //下記のrectTransformをこの変数に保存
    private RectTransform _rectTransform;
    //reactTranformでこのスクリプトのオブジェクトのRectTransformを取得する
    protected RectTransform rectTransform
    {
        //代入時に呼ばれる
        get
        {
            if (_rectTransform == null) _rectTransform = GetComponent<RectTransform>();
            return _rectTransform;
        }
    }

    //アンカー基準点に対する RectTransform の相対的なピボットの位置
    private float anchoredPosition
    {
        get
        {
            //例えば縦方向だった場合、このオブジェクトが上に上がっていくことで、下にスクロールしているように見える。なので、Y=200の位置ならpositionは-200を返す
            return direction == Direction.Vertical ? -rectTransform.anchoredPosition.y : rectTransform.anchoredPosition.x;
        }
    }

    //スケールを保存
    private float _itemScale = -1;
    //変更されてない場合スクロール方向によってベースアイテムのデルタサイズを返す(アンカー間の距離と比較した RectTransform のサイズ。)
    public float itemScale
    {
        get
        {
            if (itemPrototype != null && _itemScale == -1)
            {
                _itemScale = direction == Direction.Vertical ? itemPrototype.sizeDelta.y : itemPrototype.sizeDelta.x;
            }
            return _itemScale;
        }
    }

    public List<InfinityScrollSetUp> controllers;

　　//最初の初期化更新とゲームオブジェクト生成
    protected override void Awake()
    {
        //MonoBehaviour = すべての親クラス。
        //両方のclassのメッソドにアクセスしたいのでListで取得。獲得するList自体は1個だけ。
        controllers = GetComponents<MonoBehaviour>()
                //型キャスト可能かどうかを判定するis + 条件指定のWhere
                .Where(item => item is InfinityScrollSetUp)
                .Select(item => item as InfinityScrollSetUp)
                .ToList();

        // create items

        //このスクリプトのオブジェクトのスクロールレクトを取得
        var scrollRect = GetComponentInParent<ScrollRect>();
        //設定したスクロール方向がどっちかを判定し、合致したほうに代入
        scrollRect.horizontal = direction == Direction.Horizontal;
        scrollRect.vertical = direction == Direction.Vertical;
        //スクロールレクトに代入
        scrollRect.content = rectTransform;

        //基準のゲームオブジェクトは非表示に
        itemPrototype.gameObject.SetActive(false);

        for (int i = 0; i < instantateItemCount; i++)
        {
            //ベースアイテムをRectTransformにキャストして生成。その後var itemに代入
            var item = GameObject.Instantiate(itemPrototype) as RectTransform;


            //親としてこのオブジェクトのトランスフォームを設定
            item.SetParent(transform, false);

            //オブジェクトの名前を番号に変更
            item.name = i.ToString();


            //アンカーポジションをスクロール方向が縦なら左をそうじゃない(横なら)右を採用
            item.anchoredPosition = direction == Direction.Vertical ? new Vector2(0, -itemScale * i) : new Vector2(itemScale * i, 0);

            //作成した指定数のオブジェクトをリストの中に入れる
            itemList.AddLast(item);


            //元のオブジェクトを非表示にたのでtrueに
            item.gameObject.SetActive(true);

            //取得したListはClassのリストなので、一回展開してから必要な方に情報を渡す(最初のアイテムの読み込みを行う)
            foreach (var controller in controllers)
            {
                //取得したリストにインターフェースを介して、メソッドに番号とゲームオブジェクトを譲渡。内容を更新する。
                controller.OnUpdateItem(i, item.gameObject);
                ItemLIstGameObject.Add(item.gameObject);

            }
        }

        //ここまでが使いまわすオブジェクトに対するもの(ItemBaseの複製)


        //ビューサイズの変更と下記のClassへのAddLisnerの登録を行う
        foreach (var controller in controllers)
        {
            controller.OnPostSetupItems();
        }
    }

    //最大数が更新されるたびに中身を更新
    public void AutoUpdata()
    {

        for (int i = 0; i < instantateItemCount; i++)
        {

            //取得したListはClassのリストなので、一回展開してから必要な方に情報を渡す(最初のアイテムの読み込みを行う)
            foreach (var controller in controllers)
            {
                //取得したリストにインターフェースを介して、メソッドに番号とゲームオブジェクトを譲渡。内容を更新する。
                controller.OnUpdateItem(i, ItemLIstGameObject[i]);

            }
        }

        //ビューサイズの変更と下記のClassへのAddLisnerの登録を行う
        foreach (var controller in controllers)
        {
            controller.OnPostSetupItems();
        }

    }


    //再利用
    void Update()
    {

        //バグ防ぐよう？リスト(オブジェクト)に何も格納されてなかったらUpdateを使用しない。
        if (itemList.First == null)
        {
            return;
        }

        //(上から下スクロール)


        //一番最初はベースアイテムの2倍の値を超えたらwhile以下が起動。
        //起動すると、-(-45) = 90-45 = 45になってまたリセットがかかる。(=差分計算を行っている(セルごとに))
        //while内が起動するということはセル１つ分がview内からなくなったことを指す。= 一番最初の要素を最後に使いまわすということ。
        while (anchoredPosition - diffPreFramePosition < -itemScale * 2)
        {

            //リセット用にセル分を足していく。
            diffPreFramePosition -= itemScale;

            //リストの最初のオブジェクトを取得し保存
            var item = itemList.First.Value;
            //リストの最初のオブジェクトを削除
            itemList.RemoveFirst();
            //最後尾に付け加える
            itemList.AddLast(item);

            //一番目は0,0に生成されているため
            //使いまわし時に生成するポジションは基準スケール*使う総合Objectの数 + (基準スケール * 何番目の追加か)
            //例 45 * 9 +(45 * 0 ) = 405 最初のオブジェクトが使いまわされる場合は最初の追加なので45*0になり405の位置に10番目として再生成される。
            var pos = itemScale * instantateItemCount + itemScale * currentItemNo;

            //位置を決定したら、縦スクロールならyに横スクロール(左から右なら)xに正で設定。
            item.anchoredPosition = (direction == Direction.Vertical) ? new Vector2(0, -pos) : new Vector2(pos, 0);

            //※インターフェースのaddLisnerを使ったほうが処理が軽い？
            //スタート時に追加addLisnerを呼び出す(実質OnUpdateItemを呼び出している)
            //onUpdateItem.Invoke(currentItemNo + instantateItemCount, item.gameObject);

            foreach (var controller in controllers)
            {
                //取得したリストにインターフェースを介して、メソッドに番号とゲームオブジェクトを譲渡。内容を更新する。
                controller.OnUpdateItem(currentItemNo + instantateItemCount, item.gameObject);

            }

            //次のためにカウントを増やしておく。最後まで行ったらカウントこの処理が実行されなくなりカウントが増えずにとまる。
            currentItemNo++;


        }

        //下から上にスクロール
        while (anchoredPosition - diffPreFramePosition > 0)
        {
            //上と逆で判定していく
            diffPreFramePosition += itemScale;

            var item = itemList.Last.Value;
            itemList.RemoveLast();
            itemList.AddFirst(item);

            currentItemNo--;

            var pos = itemScale * currentItemNo;
            item.anchoredPosition = (direction == Direction.Vertical) ? new Vector2(0, -pos) : new Vector2(pos, 0);
            onUpdateItem.Invoke(currentItemNo, item.gameObject);

        }


    }

    //何個目かをカウントするintと、GameObjectを引数にとったUnityEventを継承したClassを作成
    [System.Serializable]
    public class OnItemPositionChange : UnityEngine.Events.UnityEvent<int, GameObject> { }



    //1 : Max数に追加分を足していく
    //2 : それに基づいたViewの大きさを再計算するためにメソッドを呼び出す。
    //3 : そのカウントに基づいた情報を格納する。
}
