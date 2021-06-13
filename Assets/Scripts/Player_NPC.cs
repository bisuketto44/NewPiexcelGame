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

    private float X;
    private float Y;

    //各方向のbool
    private bool up;
    private bool down;
    private bool left;
    private bool right;
    private bool nowhere;
    private bool stop;

    //方向決定を呼び出す
    private bool isdirection;

    private int count = 0;
    private int stopcount = 0;

    //立ち止まる時間
    private float CoolTime = 0.0f;
    private float nowhereCoolTime = 0.0f;

    private float ColisionCooltime = 0.0f;

    void Awake()
    {
        stopcount = Random.Range(2, 5);
        DicideDirection();

    }


    void Update()
    {
        ColisionCooltime += Time.deltaTime;
        if (ColisionCooltime >= 3.0f)
        {
            ColisionCooltime = 0.0f;
        }

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
                isdirection = true;
            }
        }

        //同じ座標に移動する場合
        if (nowhere == true)
        {
            nowhereCoolTime += Time.deltaTime;
            if (nowhereCoolTime <= 5f)
            {

            }
            else
            {
                PlayerAnimator.SetBool("IDLES", false);
                PlayerAnimator.SetBool("IDLEE", true);
                nowhereCoolTime = 0.0f;
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
                nowhere = false;
                return;
            }

            //進行方向の変更を呼び出す
            DicideDirection();
            count++;
            isdirection = false;
        }

    }


    void OnCollisionStay2D(Collision2D other)
    {
        if (ColisionCooltime <= 1.5f)
        {
            Debug.Log("CTです");
            return;
        }

        if (other.gameObject.tag == "Layout_Collision")
        {
            Debug.Log("衝突しました！");
            if (up == true)
            {
                PlayerAnimator.SetBool("EXITUP", true);
                PlayerAnimator.SetBool("STARTUP", false);
                isdirection = true;

            }
            else if (down == true)
            {
                PlayerAnimator.SetBool("EXITDOWN", true);
                PlayerAnimator.SetBool("STARTDOWN", false);
                isdirection = true;

            }
            else if (left == true)
            {
                PlayerAnimator.SetBool("EXITLEFT", true);
                PlayerAnimator.SetBool("STRATLEFT", false);
                isdirection = true;

            }
            else if (right == true)
            {
                PlayerAnimator.SetBool("EXITRIGHT", true);
                PlayerAnimator.SetBool("STRATRIGHT", false);
                isdirection = true;

            }
            //移動不可に
            up = false;
            down = false;
            left = false;
            right = false;


        }

    }

    //進行方向を決定するメソッド
    public void DicideDirection()
    {

        //XかYかを決定
        _XorY = Random.Range(0, 2);
        if (_XorY == 0)
        {
            //X軸方向
            _tarminalPositionX = (float)Random.Range((int)-2, (int)12);
            //Xがマイナスなら左方向、プラスなら右
            X = _tarminalPositionX - this.gameObject.transform.position.x;

            if (X < 0)
            {
                left = true;
                right = false;
                up = false;
                down = false;
                nowhere = false;
                PlayerAnimator.SetBool("STRATLEFT", true);
                PlayerAnimator.SetBool("EXITLEFT", false);

            }
            else if (X > 0)
            {
                left = false;
                right = true;
                up = false;
                down = false;
                nowhere = false;
                PlayerAnimator.SetBool("STRATRIGHT", true);
                PlayerAnimator.SetBool("EXITRIGHT", false);

            }
            else if (X == 0)
            {

                left = false;
                right = false;
                up = false;
                down = false;
                nowhere = true;
                PlayerAnimator.SetBool("IDLES", true);
                PlayerAnimator.SetBool("IDLEE", false);

            }
        }
        else if (_XorY == 1)
        {
            //Y軸方向
            _tarminalPositionY = (float)Random.Range((int)-7, (int)4);
            //Yがマイナスなら下方向、プラスなら上方向
            Y = _tarminalPositionY - this.gameObject.transform.position.y;
            if (Y < 0)
            {
                left = false;
                right = false;
                up = false;
                down = true;
                nowhere = false;
                PlayerAnimator.SetBool("STARTDOWN", true);
                PlayerAnimator.SetBool("EXITDOWN", false);

            }
            else if (Y > 0)
            {
                left = false;
                right = false;
                up = true;
                down = false;
                nowhere = false;
                PlayerAnimator.SetBool("STARTUP", true);
                PlayerAnimator.SetBool("EXITUP", false);

            }
            else if (Y == 0f)
            {
                left = false;
                right = false;
                up = false;
                down = false;
                nowhere = true;
                PlayerAnimator.SetBool("IDLES", true);
                PlayerAnimator.SetBool("IDLEE", false);

            }
        }

    }
}
