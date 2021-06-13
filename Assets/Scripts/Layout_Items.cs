using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Layout_Items : MonoBehaviour
{
    private Vector2 _playerFingerPs;
    private Button DicideBtn;

    void Awake()
    {
        DicideBtn = GameObject.FindWithTag("Layout_Dicide_Btn").GetComponent<Button>();
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        _playerFingerPs = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0) && _playerFingerPs.x <= 13 && _playerFingerPs.x >= -3 && _playerFingerPs.y <= 5 && _playerFingerPs.y >= -8)
        {
            this.gameObject.transform.position = new Vector2(Mathf.Clamp(Mathf.Round(_playerFingerPs.x), -2, 12), Mathf.Clamp(Mathf.Round(_playerFingerPs.y), -7, 4));
        }

    }

    //かぶっている範囲、壁の外側に触れると赤色に変更して警告
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Layout_Collision" || other.gameObject.tag == "Layout_Collision_Tile")
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 150);

            //決定ボタンを無効化
            DicideBtn.interactable = false;

            //子オブジェクトが3(Stream_Desk)だった場合はその子オブジェクトも赤色へ変更
            if (this.gameObject.transform.childCount == 3)
            {
                for (int a = 0; a < 3; a++)
                {
                    this.gameObject.transform.GetChild(a).GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 150);
                }

            }
            Debug.Log("赤色に変わりました");
        }
    }

    //範囲外に出ると色を元に戻す
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Layout_Collision" || other.gameObject.tag == "Layout_Collision_Tile")
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);

            //判定から出たら決定ボタンを有効化
            DicideBtn.interactable = true;

            if (this.gameObject.transform.childCount == 3)
            {
                for (int a = 0; a < 3; a++)
                {
                    this.gameObject.transform.GetChild(a).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);
                }

            }
            Debug.Log("色が元に戻りました");
        }
    }


}
