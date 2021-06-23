using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars_Contoroller : MonoBehaviour
{
    [Tooltip("車の左進行スプライト群")]
    [SerializeField]
    private GameObject[] CarsLeft;

    [Tooltip("車の右進行スプライト群")]
    [SerializeField]
    private GameObject[] CarsRight;

    [Tooltip("車の親オブジェクト")]
    [SerializeField]
    Transform ParentObject;

    //車のスポーン時間
    private float _leftCarsSpornTime = 0;
    private float _rightCarsSpornTime = 0;

    //タイマー
    private float leftcount = 0;
    private float rightcount = 0;

    private int SpornCarsleft = 0;
    private int SpornCarsRight = 0;

    void Awake()
    {
        DicideSpornCarsTimeLeft();
        DicideSpornCarsTimeRight();
    }

    void Update()
    {
        leftcount += Time.deltaTime;
        rightcount += Time.deltaTime;

        if (leftcount >= _leftCarsSpornTime)
        {
            //オブジェクトを生成
            Instantiate(CarsLeft[SpornCarsleft], CarsLeft[SpornCarsleft].transform.position, Quaternion.identity, ParentObject);
            leftcount = 0;
            DicideSpornCarsTimeLeft();
        }
        if (rightcount >= _rightCarsSpornTime)
        {
            Instantiate(CarsRight[SpornCarsRight], CarsRight[SpornCarsRight].transform.position, Quaternion.identity, ParentObject);
            rightcount = 0;
            DicideSpornCarsTimeRight();
        }
    }

    //何秒後にスポーンし、それがどの車を決定するメソッド
    private void DicideSpornCarsTimeLeft()
    {
        //45秒から90秒の間でランダムスポーン
        _leftCarsSpornTime = Random.Range((int)45, (int)90);
        SpornCarsleft = Random.Range(0, CarsLeft.Length);
    }

    private void DicideSpornCarsTimeRight()
    {
        _rightCarsSpornTime = Random.Range((int)45, (int)90);
        SpornCarsRight = Random.Range(0, CarsRight.Length);
    }
}
