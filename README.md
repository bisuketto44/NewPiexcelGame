
<h2><a id="user-content-game-overview" class="anchor" aria-hidden="true" href="#game-overview"><svg class="octicon octicon-link" viewBox="0 0 16 16" version="1.1" width="16" height="16" aria-hidden="true"><path fill-rule="evenodd" d="M7.775 3.275a.75.75 0 001.06 1.06l1.25-1.25a2 2 0 112.83 2.83l-2.5 2.5a2 2 0 01-2.83 0 .75.75 0 00-1.06 1.06 3.5 3.5 0 004.95 0l2.5-2.5a3.5 3.5 0 00-4.95-4.95l-1.25 1.25zm-4.69 9.64a2 2 0 010-2.83l2.5-2.5a2 2 0 012.83 0 .75.75 0 001.06-1.06 3.5 3.5 0 00-4.95 0l-2.5 2.5a3.5 3.5 0 004.95 4.95l1.25-1.25a.75.75 0 00-1.06-1.06l-1.25 1.25a2 2 0 01-2.83 0z"></path></svg></a>Game Overview</h2>
<p>・ライブ配信者として投げ銭を貰いながら、強化&amp;部屋改造を行い、自身のチャンネル拡大を目指す2Dドットのモバイル向けシミュレーションゲームです。</p>
<h2><a id="user-content-topic" class="anchor" aria-hidden="true" href="#topic"><svg class="octicon octicon-link" viewBox="0 0 16 16" version="1.1" width="16" height="16" aria-hidden="true"><path fill-rule="evenodd" d="M7.775 3.275a.75.75 0 001.06 1.06l1.25-1.25a2 2 0 112.83 2.83l-2.5 2.5a2 2 0 01-2.83 0 .75.75 0 00-1.06 1.06 3.5 3.5 0 004.95 0l2.5-2.5a3.5 3.5 0 00-4.95-4.95l-1.25 1.25zm-4.69 9.64a2 2 0 010-2.83l2.5-2.5a2 2 0 012.83 0 .75.75 0 001.06-1.06 3.5 3.5 0 00-4.95 0l-2.5 2.5a3.5 3.5 0 004.95 4.95l1.25-1.25a.75.75 0 00-1.06-1.06l-1.25 1.25a2 2 0 01-2.83 0z"></path></svg></a>Topic</h2>
<ul>
<li><a href="#Data">データ管理・作成方法</a></li>
<li><a href="#live">配信/投げ銭機能</a></li>
<li><a href="#Layout">グリッド型のアイテムレイアウト機能</a></li>
<li><a href="#Shop">ショップシステム</a></li>
<li><a href="#motivation">時間回復のスタミナ機能(ゲーム非起動時も回復)</a></li>
<li><a href="#glaphe">動的な折れ線グラフ生成</a></li>
<li><a href="#RederChart">レーダーチャート生成</a></li>
<li><a href="#save">Jsonによるセーブシステム</a></li>
<li><a href="#other">その他雑記</a></li>
</ul>
<h2></h2><h3 id="user-content-data"><a id="user-content-データ管理作成方法" class="anchor" aria-hidden="true" href="#データ管理作成方法"><svg class="octicon octicon-link" viewBox="0 0 16 16" version="1.1" width="16" height="16" aria-hidden="true"><path fill-rule="evenodd" d="M7.775 3.275a.75.75 0 001.06 1.06l1.25-1.25a2 2 0 112.83 2.83l-2.5 2.5a2 2 0 01-2.83 0 .75.75 0 00-1.06 1.06 3.5 3.5 0 004.95 0l2.5-2.5a3.5 3.5 0 00-4.95-4.95l-1.25 1.25zm-4.69 9.64a2 2 0 010-2.83l2.5-2.5a2 2 0 012.83 0 .75.75 0 001.06-1.06 3.5 3.5 0 00-4.95 0l-2.5 2.5a3.5 3.5 0 004.95 4.95l1.25-1.25a.75.75 0 00-1.06-1.06l-1.25 1.25a2 2 0 01-2.83 0z"></path></svg></a>データ管理・作成方法</h3>
<p>・<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/Items.cs">item.cs</a><br>
対象の情報を書き込んだクラスを用意<br>
・<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/Item_DataBase.cs">item_Database.cs</a><br>
それをリストとしてインスタンス化し、リストごとに各データを管理します。<br>
インスタンス化は空オブジェクトをシーン上に用意し、ゲーム開始時に行います。</p>
<h2></h2><h3 id="user-content-live"><a id="user-content-配信投げ銭機能" class="anchor" aria-hidden="true" href="#配信投げ銭機能"><svg class="octicon octicon-link" viewBox="0 0 16 16" version="1.1" width="16" height="16" aria-hidden="true"><path fill-rule="evenodd" d="M7.775 3.275a.75.75 0 001.06 1.06l1.25-1.25a2 2 0 112.83 2.83l-2.5 2.5a2 2 0 01-2.83 0 .75.75 0 00-1.06 1.06 3.5 3.5 0 004.95 0l2.5-2.5a3.5 3.5 0 00-4.95-4.95l-1.25 1.25zm-4.69 9.64a2 2 0 010-2.83l2.5-2.5a2 2 0 012.83 0 .75.75 0 001.06-1.06 3.5 3.5 0 00-4.95 0l-2.5 2.5a3.5 3.5 0 004.95 4.95l1.25-1.25a.75.75 0 00-1.06-1.06l-1.25 1.25a2 2 0 01-2.83 0z"></path></svg></a>配信/投げ銭機能</h3>
<p>・<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/Viewer_Count.cs">Viewer_Count.cs</a><br>
主な役割は配信の強化状況や選択された配信スタイルの判定、配信に集まる人数・投げ銭の量や額の決定です。</p>
<h3><a id="user-content-配信" class="anchor" aria-hidden="true" href="#配信"><svg class="octicon octicon-link" viewBox="0 0 16 16" version="1.1" width="16" height="16" aria-hidden="true"><path fill-rule="evenodd" d="M7.775 3.275a.75.75 0 001.06 1.06l1.25-1.25a2 2 0 112.83 2.83l-2.5 2.5a2 2 0 01-2.83 0 .75.75 0 00-1.06 1.06 3.5 3.5 0 004.95 0l2.5-2.5a3.5 3.5 0 00-4.95-4.95l-1.25 1.25zm-4.69 9.64a2 2 0 010-2.83l2.5-2.5a2 2 0 012.83 0 .75.75 0 001.06-1.06 3.5 3.5 0 00-4.95 0l-2.5 2.5a3.5 3.5 0 004.95 4.95l1.25-1.25a.75.75 0 00-1.06-1.06l-1.25 1.25a2 2 0 01-2.83 0z"></path></svg></a><p>配信</p><p></p></h3>
<p>視聴者数は配信の強化状況に合わせて、ベース視聴者数が決定。Dictionaryを用いてValue(%)とその確率で返すキーを設定し、増減するようにします。
同じ方法で投げ銭等その他確率が必要な機能を処理しています。(ex : DictsViewer()とChooseViewer())<br>
この増減がコルーチンの中で指定回数(時間)行われ、最終結果を過去10回分までアーカイブとしてゲーム内で確認できるよう保存します。</p>
<h3><a id="user-content-投げ銭" class="anchor" aria-hidden="true" href="#投げ銭"><svg class="octicon octicon-link" viewBox="0 0 16 16" version="1.1" width="16" height="16" aria-hidden="true"><path fill-rule="evenodd" d="M7.775 3.275a.75.75 0 001.06 1.06l1.25-1.25a2 2 0 112.83 2.83l-2.5 2.5a2 2 0 01-2.83 0 .75.75 0 00-1.06 1.06 3.5 3.5 0 004.95 0l2.5-2.5a3.5 3.5 0 00-4.95-4.95l-1.25 1.25zm-4.69 9.64a2 2 0 010-2.83l2.5-2.5a2 2 0 012.83 0 .75.75 0 001.06-1.06 3.5 3.5 0 00-4.95 0l-2.5 2.5a3.5 3.5 0 004.95 4.95l1.25-1.25a.75.75 0 00-1.06-1.06l-1.25 1.25a2 2 0 01-2.83 0z"></path></svg></a><p>投げ銭</p><p></p></h3>
<p>集めた視聴者数によって貰える投げ銭の量を増減させます。<br>
投げ銭がどれほど貰えるかは１回の判定で貰える量と、判定が生じるまでの速度の2つを使い決定します。<br>
二つとも方法は同じで、
<code>Mathf.InverseLerp()</code>と<code> Mathf.Lerp()</code>を使用して計算します。<br>
<code>Mathf.InverseLerp()</code>で現在集めているベース視聴者数を、設定した最大、最小の視聴者数で正規化し、<code> Mathf.Lerp()</code>で指定した数値の間で線形補間した値を使い、上記２つを決定することで、プレイヤーがゲームを進め配信を強化し、視聴者を集めれば集めるほど、投げ銭の量が増えるようにしています。</p>
<p>・<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/InfinityScoll.cs">InfinityScoll.cs</a><br>
・<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/InfnityScrollLimited.cs">InfnityScrollLimited.cs</a><br>
・<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/ChatSortNumber.cs">ChatSortNumber.cs</a><br>
・<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/Hiper_Chat_Generates.cs">Hiper_Chat_Generates.cs</a></p>
<p>上二つは要素を使いまわすことで描画処理を抑える無限スクローラーのスクリプトです。 スクロールを行い、指定位置を超えるたびに要素をLinkedListで最初の要素と末尾の要素を入れ替え使いまわします。
今回のゲーム用にいくつか手を加えていますが、<a href="https://github.com/tsubaki/Unity_UI_Samples/tree/master/Assets/InfiniteScroll">テラシュールさん</a> のものを参考に作成しました。ありがとうございます。</p>
<p><a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/Hiper_Chat_Generates.cs">Hiper_Chat_Generates.cs</a>で投げ銭のデータをリストで作成、その後データを金額下降順でsortしておきます。スクロールの位置によって<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/ChatSortNumber.cs">ChatSortNumber.cs</a>に何番目のリストを表示するのかを決定させ、その結果をスクロールの中にある使いまわしのオブジェクトへと返します。<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/InfinityScoll.cs">InfinityScoll.cs</a>は自身と同じオブジェクトについているスクリプトを取得し、それによって表示する中身をinterfaceによって処理分けできるので、アーカイブ機能での投げ銭無限スクロールも同じ要領で実装しています。こちらは２次元リスト(正確にはリストを持たせたクラスをリスト化)を使用しています。詳しくはセーブデータ保存の部分で後述します。</p>
<h2></h2><h3 id="user-content-layout"><a id="user-content-グリッド型のアイテムレイアウト機能" class="anchor" aria-hidden="true" href="#グリッド型のアイテムレイアウト機能"><svg class="octicon octicon-link" viewBox="0 0 16 16" version="1.1" width="16" height="16" aria-hidden="true"><path fill-rule="evenodd" d="M7.775 3.275a.75.75 0 001.06 1.06l1.25-1.25a2 2 0 112.83 2.83l-2.5 2.5a2 2 0 01-2.83 0 .75.75 0 00-1.06 1.06 3.5 3.5 0 004.95 0l2.5-2.5a3.5 3.5 0 00-4.95-4.95l-1.25 1.25zm-4.69 9.64a2 2 0 010-2.83l2.5-2.5a2 2 0 012.83 0 .75.75 0 001.06-1.06 3.5 3.5 0 00-4.95 0l-2.5 2.5a3.5 3.5 0 004.95 4.95l1.25-1.25a.75.75 0 00-1.06-1.06l-1.25 1.25a2 2 0 01-2.83 0z"></path></svg></a>グリッド型のアイテムレイアウト機能</h3>
<p>・<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/Layout_Items.cs">Layout_Items.cs</a><br>
上記のスクリプトをレイアウトとして配置させたいスプライトオブジェクトに貼り付けPrefab化して用意しておきます。<br>
指定された範囲内かつ、プレイヤーの指(マウス)の位置に最も近い整数値を返すことで、グリッド移動を行います。</p>
<div class="snippet-clipboard-content position-relative" data-snippet-clipboard-copy-content="    private void Movement()
    {
        _playerFingerPs = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0) &amp;&amp; _playerFingerPs.x &lt;= 13 &amp;&amp; _playerFingerPs.x &gt;= -3 &amp;&amp; _playerFingerPs.y &lt;= 5 &amp;&amp; _playerFingerPs.y &gt;= -8)
        {
            this.gameObject.transform.position = new Vector2(Mathf.Clamp(Mathf.Round(_playerFingerPs.x), -2, 12), Mathf.Clamp(Mathf.Round(_playerFingerPs.y), -7, 4));
        }

    }
"><pre><code>    private void Movement()
    {
        _playerFingerPs = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0) &amp;&amp; _playerFingerPs.x &lt;= 13 &amp;&amp; _playerFingerPs.x &gt;= -3 &amp;&amp; _playerFingerPs.y &lt;= 5 &amp;&amp; _playerFingerPs.y &gt;= -8)
        {
            this.gameObject.transform.position = new Vector2(Mathf.Clamp(Mathf.Round(_playerFingerPs.x), -2, 12), Mathf.Clamp(Mathf.Round(_playerFingerPs.y), -7, 4));
        }

    }
</code></pre></div>
<p>・<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/Layout_Items_StoreBOX.cs">Layout_Items_StoreBOX</a><br>
・<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/Layout_BtnPro_BOXCS.cs">Layout_BtnPro_BOXCS.cs</a><br>
アイテム選択時のオブジェクトPrfabs、配置オブジェクトPrefabs、回転オブジェクトprefabs、そして各オブジェクトの配置後のオブジェクトとそれを判定するフラグを配列でそれぞれ用意し、プレイヤーの選択状況によってinstans化を行い切り替えることでレイアウトシステムを作成しています。決定ボタンによってレイアウトを決定し、再度移動するにはアイテムを一旦しまう or オブジェクトを0.8秒以上長押する ことで可能です。後者はEventTriggerで実装しています。</p>
<h2></h2><h3 id="user-content-shop"><a id="user-content-ショップシステム" class="anchor" aria-hidden="true" href="#ショップシステム"><svg class="octicon octicon-link" viewBox="0 0 16 16" version="1.1" width="16" height="16" aria-hidden="true"><path fill-rule="evenodd" d="M7.775 3.275a.75.75 0 001.06 1.06l1.25-1.25a2 2 0 112.83 2.83l-2.5 2.5a2 2 0 01-2.83 0 .75.75 0 00-1.06 1.06 3.5 3.5 0 004.95 0l2.5-2.5a3.5 3.5 0 00-4.95-4.95l-1.25 1.25zm-4.69 9.64a2 2 0 010-2.83l2.5-2.5a2 2 0 012.83 0 .75.75 0 001.06-1.06 3.5 3.5 0 00-4.95 0l-2.5 2.5a3.5 3.5 0 004.95 4.95l1.25-1.25a.75.75 0 00-1.06-1.06l-1.25 1.25a2 2 0 01-2.83 0z"></path></svg></a>ショップシステム</h3>
<p>・<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/Item_Purchase.cs">Item_Purchase.cs</a><br>
・<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/Shop_Conditions.cs">Shop_Conditions.cs</a><br>
マネー用の変数を用意して、アイテムが購入できるか否かを判定、ゲームスタート時に、後述するJsonのセーブデータ読み込みを行うことで、前回のアイテムデータを復元します。</p>
<h2></h2><h3 id="user-content-motivation"><a id="user-content-時間回復のスタミナ機能" class="anchor" aria-hidden="true" href="#時間回復のスタミナ機能"><svg class="octicon octicon-link" viewBox="0 0 16 16" version="1.1" width="16" height="16" aria-hidden="true"><path fill-rule="evenodd" d="M7.775 3.275a.75.75 0 001.06 1.06l1.25-1.25a2 2 0 112.83 2.83l-2.5 2.5a2 2 0 01-2.83 0 .75.75 0 00-1.06 1.06 3.5 3.5 0 004.95 0l2.5-2.5a3.5 3.5 0 00-4.95-4.95l-1.25 1.25zm-4.69 9.64a2 2 0 010-2.83l2.5-2.5a2 2 0 012.83 0 .75.75 0 001.06-1.06 3.5 3.5 0 00-4.95 0l-2.5 2.5a3.5 3.5 0 004.95 4.95l1.25-1.25a.75.75 0 00-1.06-1.06l-1.25 1.25a2 2 0 01-2.83 0z"></path></svg></a>時間回復のスタミナ機能</h3>
<p>・<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/Motivation_Contoroller.cs">Motivation_Contoroller.cs</a></p>
<p>time.deltatimeを足し合わせることで時間を計測します。デフォルト状態では60秒でやる気ゲージを1回復します。<br>
また、Datatime構造体を使用することでゲーム起動時以外もゲージ回復するようにしています。<br>
方法は簡単で、ゲームの終了時間を記録しておき、次にゲームを起動したときの時間から前回の終了時間との差分をとることで何秒間ゲームを起動していなかったかを計算し、その分ゲージを回復させます。</p>
<p>ただDatatime構造体はデバイスのローカル設定時間を読み取るものなので、ローカル時間を変更するとスタナミが不正回復されるという欠点があり、それをカバーする場合はサーバー時間を使用したほうが良いです。今回は仮に不正回復を行ってもゲームバランスに特に問題が出ないので、ローカル時間を採用していますが、可能な限り避けたほうが良いと思われます。</p>
<h2></h2><h3 id="user-content-glaphe"><a id="user-content-動的な折れ線グラフ生成" class="anchor" aria-hidden="true" href="#動的な折れ線グラフ生成"><svg class="octicon octicon-link" viewBox="0 0 16 16" version="1.1" width="16" height="16" aria-hidden="true"><path fill-rule="evenodd" d="M7.775 3.275a.75.75 0 001.06 1.06l1.25-1.25a2 2 0 112.83 2.83l-2.5 2.5a2 2 0 01-2.83 0 .75.75 0 00-1.06 1.06 3.5 3.5 0 004.95 0l2.5-2.5a3.5 3.5 0 00-4.95-4.95l-1.25 1.25zm-4.69 9.64a2 2 0 010-2.83l2.5-2.5a2 2 0 012.83 0 .75.75 0 001.06-1.06 3.5 3.5 0 00-4.95 0l-2.5 2.5a3.5 3.5 0 004.95 4.95l1.25-1.25a.75.75 0 00-1.06-1.06l-1.25 1.25a2 2 0 01-2.83 0z"></path></svg></a>動的な折れ線グラフ生成</h3>
<p>・<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/LineGrahpe.cs">LineGrahpe.cs</a><br>
・<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/LineGrahpeContoroller.cs">LineGrahpeContoroller.cs</a></p>
<p>視聴者の推移に合わせてグラフを表示します。<br>
グラフを表示するビューポートの高さの最高点を、表示する値の最大値とし値を正規化、グラフ用のドットを生成する位置を決定します。
次に生成したドット間のベクトルと距離を計算します。</p>
<div class="snippet-clipboard-content position-relative" data-snippet-clipboard-copy-content="Vector2 dir = (_pointB - _pointA).normalized;
float fDistance = Vector2.Distance(_pointA, _pointB);
"><pre><code>Vector2 dir = (_pointB - _pointA).normalized;
float fDistance = Vector2.Distance(_pointA, _pointB);
</code></pre></div>
<p>傾きを求めます。</p>
<div class="snippet-clipboard-content position-relative" data-snippet-clipboard-copy-content="rtLine.localEulerAngles = new Vector3(0f, 0f, Vector2.SignedAngle(new Vector2(1f, 0f), dir));
"><pre><code>rtLine.localEulerAngles = new Vector3(0f, 0f, Vector2.SignedAngle(new Vector2(1f, 0f), dir));
</code></pre></div>
<p>最後に線の長さを決定し、線の位置を生成したドットの中間点に配置することで繋ぎます。</p>
<div class="snippet-clipboard-content position-relative" data-snippet-clipboard-copy-content=" rtLine.sizeDelta = new Vector2(fDistance, 2f);  
 rtLine.anchoredPosition = _pointA + (dir * fDistance * 0.5f);  
"><pre><code> rtLine.sizeDelta = new Vector2(fDistance, 2f);  
 rtLine.anchoredPosition = _pointA + (dir * fDistance * 0.5f);  
</code></pre></div>
<p>ドット数がビューポートに表示できる数を超えると生成したドットと線をリセットし、描画を更新します。<br>
上記を繰り返すことで動的な折れ線グラフを作成しています。</p>
<h2></h2><h3 id="user-content-rederchart"><a id="user-content-レーダーチャート" class="anchor" aria-hidden="true" href="#レーダーチャート"><svg class="octicon octicon-link" viewBox="0 0 16 16" version="1.1" width="16" height="16" aria-hidden="true"><path fill-rule="evenodd" d="M7.775 3.275a.75.75 0 001.06 1.06l1.25-1.25a2 2 0 112.83 2.83l-2.5 2.5a2 2 0 01-2.83 0 .75.75 0 00-1.06 1.06 3.5 3.5 0 004.95 0l2.5-2.5a3.5 3.5 0 00-4.95-4.95l-1.25 1.25zm-4.69 9.64a2 2 0 010-2.83l2.5-2.5a2 2 0 012.83 0 .75.75 0 001.06-1.06 3.5 3.5 0 00-4.95 0l-2.5 2.5a3.5 3.5 0 004.95 4.95l1.25-1.25a.75.75 0 00-1.06-1.06l-1.25 1.25a2 2 0 01-2.83 0z"></path></svg></a>レーダーチャート</h3>
<p>・<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/Style_Status_RaderChart.cs">Style_Status_RaderChart.cs</a><br>
・<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/Style_Status_RaderChart_DinamicMesh.cs">Style_Status_RaderChart_DinamicMesh.cs</a><br>
・<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/Style_Status_Management.cs">Style_Status_Management.cs</a><br>
・<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/Activate_RaderChart.cs">Activate_RaderChart.cs</a></p>
<p>6角形のレーダーチャートを作成したいので、</p>
<div class="snippet-clipboard-content position-relative" data-snippet-clipboard-copy-content="        //生成するメッシュ
        Mesh mesh = new Mesh();

        //頂点の位置をvector3配列で指定(五角形=6 六角形=7 三角形=3)
        Vector3[] vertices = new Vector3[7];

        //同じく頂点の位置をvector2配列で指定(Mesh生成に必要)
        Vector2[] uv = new Vector2[7];

        //描画順をInt配列で指定(三角形*何個必要か)
        int[] triangles = new int[3 * 6];

        //頂点の最大地点(大きさ)を決定
        float raderChartSize = 45f;

        //角度計算
        float angleIncrement = 360f / 6;
"><pre><code>        //生成するメッシュ
        Mesh mesh = new Mesh();

        //頂点の位置をvector3配列で指定(五角形=6 六角形=7 三角形=3)
        Vector3[] vertices = new Vector3[7];

        //同じく頂点の位置をvector2配列で指定(Mesh生成に必要)
        Vector2[] uv = new Vector2[7];

        //描画順をInt配列で指定(三角形*何個必要か)
        int[] triangles = new int[3 * 6];

        //頂点の最大地点(大きさ)を決定
        float raderChartSize = 45f;

        //角度計算
        float angleIncrement = 360f / 6;
</code></pre></div>
<p>それぞれ頂点位置や角度を指定します。6角形のメッシュは3角形を6つ生成することで作り出すので、３＊６のint配列を用意しておきます。<br>
あとはそれぞれの3角形の描画順を指定し、ステータスが上がるたびに、各頂点部分スケールさせレーダーチャートを作成します。<br>
頂点位置はいつものことながら正規化して決定します。</p>
<p>注意点としてGuI上でメッシュを生成し、Mask機能で隠す場合にメッシュのStencil Comparisionがデフォルト値ではうまく機能しないので、変更を加えておく必要があります。<br>
今回はStencil Comparision = 6に設定しています。</p>
<h2></h2><h3 id="user-content-save"><a id="user-content-jsonによるセーブシステム" class="anchor" aria-hidden="true" href="#jsonによるセーブシステム"><svg class="octicon octicon-link" viewBox="0 0 16 16" version="1.1" width="16" height="16" aria-hidden="true"><path fill-rule="evenodd" d="M7.775 3.275a.75.75 0 001.06 1.06l1.25-1.25a2 2 0 112.83 2.83l-2.5 2.5a2 2 0 01-2.83 0 .75.75 0 00-1.06 1.06 3.5 3.5 0 004.95 0l2.5-2.5a3.5 3.5 0 00-4.95-4.95l-1.25 1.25zm-4.69 9.64a2 2 0 010-2.83l2.5-2.5a2 2 0 012.83 0 .75.75 0 001.06-1.06 3.5 3.5 0 00-4.95 0l-2.5 2.5a3.5 3.5 0 004.95 4.95l1.25-1.25a.75.75 0 00-1.06-1.06l-1.25 1.25a2 2 0 01-2.83 0z"></path></svg></a>Jsonによるセーブシステム</h3>
<p>・<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/SaveData.cs">SaveData.cs</a><br>
・<a href="https://gist.github.com/kankikuchi/d33d1072b8518b412908dd55a0897024">kankikuchi</a>さんのJsonでのclass保存を使用させて頂いております。</p>
<p>JsonUtilityを使用して、オブジェクトをJSONにする、あるいはJSONからオブジェクトを作ります。インスタンス化ごとに別のインスタンスが作成されては困るので、<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/SaveData.cs">SaveData.cs</a>はシングルトンで実装されています。.instanceからアクセスすることで同じインスタンスを返すことが可能です。これによってゲーム終了時にJsonファイルを作成し、ゲーム開始時に終了時作成したJsonファイルからオブジェクトを復元することでセーブ機能を実装しています。</p>
<p>また、JsonUtilityでJson変換できる条件として</p>
<p>・Serializable属性でマークされているプレーンなクラスか構造体でなければなりません。<br>
・オブジェクトのフィールドはシリアライザーでサポートされるタイプでなければなりません。</p>
<p>が存在するため、前述した2次元リスト等は通常Json変換不可能となっています。<br>
これを解決するために、</p>
<p>・<a href="https://github.com/bisuketto44/NewPiexcelGame/blob/master/Assets/Scripts/Live_Acaive_Store_List.cs">Live_Acaive_Store_List.cs</a></p>
<p>リストを持ったクラスをリスト化し、それぞれをシリアライズ化することで、実質的に２次元リストを作り、過去１０回分の配信の投げ銭履歴をアーカイブとして残しています。<br>
ただセーブシステムに関しては、今回実装した方法が理想的とは言えないので他の方法も検証していきたいと思います。</p>
<h2></h2><h3 id="user-content-other"><a id="user-content-その他雑記" class="anchor" aria-hidden="true" href="#その他雑記"><svg class="octicon octicon-link" viewBox="0 0 16 16" version="1.1" width="16" height="16" aria-hidden="true"><path fill-rule="evenodd" d="M7.775 3.275a.75.75 0 001.06 1.06l1.25-1.25a2 2 0 112.83 2.83l-2.5 2.5a2 2 0 01-2.83 0 .75.75 0 00-1.06 1.06 3.5 3.5 0 004.95 0l2.5-2.5a3.5 3.5 0 00-4.95-4.95l-1.25 1.25zm-4.69 9.64a2 2 0 010-2.83l2.5-2.5a2 2 0 012.83 0 .75.75 0 001.06-1.06 3.5 3.5 0 00-4.95 0l-2.5 2.5a3.5 3.5 0 004.95 4.95l1.25-1.25a.75.75 0 00-1.06-1.06l-1.25 1.25a2 2 0 01-2.83 0z"></path></svg></a>その他雑記</h3>
<p>後付けでいろいろ機能を増やしたいと思っていたらかなりゴチャついてしまったので、もう少しフレキシブルで管理しやすいコードを心掛けで書いていきたい。</p>
</article>
  </div>

