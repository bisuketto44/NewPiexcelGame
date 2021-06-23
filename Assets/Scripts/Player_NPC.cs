using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_NPC : MonoBehaviour
{
    [SerializeField]
    Animator PlayerAnimator;

    private float _XorY;
    private float _tarminalPositionX;
    private float _tarminalPositionY;

    public bool[] isProcessing;

    private float X;
    private float Y;

    //各方向のbool
    private bool up;
    private bool down;
    private bool left;
    private bool right;
    private bool stop;

    //方向決定を呼び出す
    private bool isdirection;

    private int count = 0;
    private int stopcount = 0;

    //立ち止まる時間
    private float CoolTime = 0.0f;


    void Awake()
    {
        isProcessing = new bool[] { true, true, true, true };
        stopcount = Random.Range(2, 5);
        DiceideDirection();

    }

    void Update()
    {

        //X右移動なら
        if (right == true)
        {
            if (this.gameObject.transform.position.x <= _tarminalPositionX)
            {
                this.gameObject.transform.Translate(Vector2.right * 1f * Time.deltaTime);
            }
            else
            {
                PlayerAnimator.SetBool("EXITRIGHT", true);
                PlayerAnimator.SetBool("STRATRIGHT", false);
                right = false;
                isdirection = true;
            }
        }

        //X左移動なら
        if (left == true)
        {
            if (this.gameObject.transform.position.x >= _tarminalPositionX)
            {
                this.gameObject.transform.Translate(Vector2.left * 1f * Time.deltaTime);
            }
            else
            {
                PlayerAnimator.SetBool("EXITLEFT", true);
                PlayerAnimator.SetBool("STRATLEFT", false);
                left = false;
                isdirection = true;
            }
        }

        //Y上移動なら
        if (up == true)
        {
            if (this.gameObject.transform.position.y <= _tarminalPositionY)
            {
                this.gameObject.transform.Translate(Vector2.up * 1f * Time.deltaTime);
            }
            else
            {
                PlayerAnimator.SetBool("EXITUP", true);
                PlayerAnimator.SetBool("STARTUP", false);
                up = false;
                isdirection = true;
            }
        }

        //Y下移動なら
        if (down == true)
        {
            if (this.gameObject.transform.position.y >= _tarminalPositionY)
            {
                this.gameObject.transform.Translate(Vector2.down * 1f * Time.deltaTime);
            }
            else
            {
                PlayerAnimator.SetBool("EXITDOWN", true);
                PlayerAnimator.SetBool("STARTDOWN", false);
                down = false;
                isdirection = true;
            }
        }

        //定期的にストップ処理
        if (stop == true)
        {
            CoolTime += Time.deltaTime;
            if (CoolTime >= 10f)
            {
                PlayerAnimator.SetBool("IDLES", false);
                PlayerAnimator.SetBool("IDLEE", true);
                isdirection = true;
                CoolTime = 0.0f;
                stop = false;

            }
        }

        //進行が終了したら次の進行方向を決定する
        if (isdirection == true)
        {
            //何回か方向転換したら5秒間止まる
            if (stopcount == count)
            {
                //初期化処理
                count = 0;
                stopcount = Random.Range(2, 5);

                isdirection = false;

                stop = true;
                PlayerAnimator.SetBool("IDLES", true);
                PlayerAnimator.SetBool("IDLEE", false);
                up = false;
                down = false;
                left = false;
                right = false;
                return;
            }

            //進行方向の変更を呼び出す
            DiceideDirection();
            count++;
            isdirection = false;
        }

    }


    private void DiceideDirection()
    {
        var num = 0;
        List<int> directionList;
        directionList = new List<int>();

        directionList.Clear();

        // 0上 1下 2左 3右で進める方向リストを作成
        for (int i = 0; i < 4; i++)
        {
            if (isProcessing[i] == true)
            {
                directionList.Add(i);
            }

        }

        if (directionList == null)
        {
            //その場で待機に移行
            return;
        }
        num = Random.Range(0, directionList.Count);
        //最終決定された方向
        var direction = directionList[num];

        switch (direction)
        {
            case 0:
                up = true;
                break;
            case 1:
                down = true;
                break;
            case 2:
                left = true;
                break;
            case 3:
                right = true;
                break;
        }

        DicideDistance();

    }

    //進行方向を決定するメソッド(上記のメソッド内で呼ぶ)
    public void DicideDistance()
    {
        //現在座標を取得
        var x = this.gameObject.transform.position.x;
        var y = this.gameObject.transform.position.y;

        //それぞれの方向の目的地計算
        if (up == true)
        {
            //移動できる残り距離を計算
            var leftY = (4 - y);
            //その間でランダムな目的地を設定する
            _tarminalPositionY = Random.Range((int)0, (int)leftY) + y;
            PlayerAnimator.SetBool("STARTUP", true);
            PlayerAnimator.SetBool("EXITUP", false);
        }
        else if (down == true)
        {
            var leftY = (-7 - y);
            //下方向は0より大きくなることはない
            _tarminalPositionY = Random.Range((int)leftY, (int)0) + y;
            PlayerAnimator.SetBool("STARTDOWN", true);
            PlayerAnimator.SetBool("EXITDOWN", false);
        }
        else if (left == true)
        {
            var leftX = (-2 - x);
            _tarminalPositionX = Random.Range((int)leftX, (int)0) + x;
            PlayerAnimator.SetBool("STRATLEFT", true);
            PlayerAnimator.SetBool("EXITLEFT", false);
        }
        else if (right == true)
        {
            var leftX = (12 - x);
            _tarminalPositionX = Random.Range((int)0, leftX) + x;
            PlayerAnimator.SetBool("STRATRIGHT", true);
            PlayerAnimator.SetBool("EXITRIGHT", false);
        }

    }

    //ものに当たると、目的地を現在地に上書きし、移動を中断する。(外部からupdateの中身の変数はあまり弄らないほうがよさそう？移動系の処理は基本座標で操作したほうがよさげ？)
    public void MotionInterruption(int num)
    {
        switch (num)
        {
            case 0:
                _tarminalPositionY = this.gameObject.transform.position.y;
                break;
            case 1:
                _tarminalPositionY = this.gameObject.transform.position.y;
                break;
            case 2:
                _tarminalPositionX = this.gameObject.transform.position.x;
                break;
            case 3:
                _tarminalPositionX = this.gameObject.transform.position.x;
                break;
        }

    }

    // PlayerAnimator.SetBool("EXITUP", true);
    // PlayerAnimator.SetBool("STARTUP", false);
    // up = false;
    // isdirection = true;を直接よんだらうまく処理できなかった。コードの構造自体を外部からいじるのは辞めたほうがよさそう。

}

