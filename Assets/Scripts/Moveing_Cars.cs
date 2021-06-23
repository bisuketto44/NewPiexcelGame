using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//車スプライトを動かすスクリプト
public class Moveing_Cars : MonoBehaviour
{
    private bool left;
    private bool right;

    void Awake()
    {
        if (this.gameObject.tag == "Left_Cars")
        {
            left = true;

        }
        else if (this.gameObject.tag == "Right_Cars")
        {
            right = true;

        }
    }

    void Update()
    {
        if (left == true)
        {
            //左に進行させる
            this.gameObject.transform.Translate(Vector2.left * 4f * Time.deltaTime);
            if (this.gameObject.transform.localPosition.x <= -7)
            {
                Destroy(this.gameObject);
            }

        }
        else if (right == true)
        {
            //右に進行させる
            this.gameObject.transform.Translate(Vector2.right * 4f * Time.deltaTime);
            if (this.gameObject.transform.localPosition.x >= 17)
            {
                Destroy(this.gameObject);
            }

        }

    }
}
