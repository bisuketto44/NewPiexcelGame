using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Style_Status_RaderChart
{
    //定数の最小値と最大値
    public static int STAT_MIN = 1;
    public static int STAT_MAX = 26;

    //Typeで振り分け
    public enum Type
    {
        Serious,
        Funy,
        Eros,
        Flames,
        Cute,
        Crazy,

    }

    //ステータスの値
    private SingleStat SeriousStat;
    private SingleStat FunyStat;
    private SingleStat ErosStat;
    private SingleStat FlamesStat;
    private SingleStat CuteStat;
    private SingleStat CrazyStat;

    //整数値を引数に各インスタンスを生成する(その中でさらにprivateClassのコンストラクタに投げて生成)
    public Style_Status_RaderChart(int SeriousStatAmount, int FunyStastAmount, int Eros, int Flames, int Cute, int Crazy)
    {
        //インスタンスが指定数生成される
        SeriousStat = new SingleStat(SeriousStatAmount);
        FunyStat = new SingleStat(FunyStastAmount);
        ErosStat = new SingleStat(Eros);
        FlamesStat = new SingleStat(Flames);
        CuteStat = new SingleStat(Cute);
        CrazyStat = new SingleStat(Crazy);
    }

    //Typeによってどのインスタンスを返すかを指定
    private SingleStat GetSingleStat(Type statType)
    {
        switch (statType)
        {
            case Type.Serious: return SeriousStat;
            case Type.Funy: return FunyStat;
            case Type.Eros: return ErosStat;
            case Type.Flames: return FlamesStat;
            case Type.Cute: return CuteStat;
            case Type.Crazy: return CrazyStat;
            default: return null;

        }

    }

    //PrivateClassの各Typeごとのインスタンスの、値に数値を渡すprivateClassを呼び出すメソッド
    public void SetStatAmount(Type statType, int StatAmount)
    {
        GetSingleStat(statType).SetStatAmount(StatAmount);
    }

    //privateClassの現在のTypeごとの値を返すメソッドを呼び出すメソッド
    public int GetStatAmount(Type statType)
    {
        return GetSingleStat(statType).GetStatAmount();
    }

    //Typeごとの正規化した値を返すprivateClassのメソッドを呼び出すメソッド
    public float GetStatAmountNormalized(Type statType)
    {
        return GetSingleStat(statType).GetStatAmountNormalized();
    }

    //privateClassの値を渡すメソッドに+１して値を渡すメソッド
    public void Increase(Type statType)
    {
        SetStatAmount(statType, GetStatAmount(statType) + 1);


    }

    //上記の逆
    public void Decrease(Type statType)
    {
        SetStatAmount(statType, GetStatAmount(statType) - 1);

    }


    //実際に値を操作する(値の数だけインスタンス化される)Class
    private class SingleStat
    {

        private int Stat = 1;

        //コンストラクタ(intを引数にとり、SetStatAmountを返す)
        public SingleStat(int statAmount)
        {
            SetStatAmount(statAmount);
        }

        //変動値に制限をかけたうえで数値を渡すメソッド
        public void SetStatAmount(int StatAmount)
        {
            Stat = Mathf.Clamp(StatAmount, STAT_MIN, STAT_MAX);
        }

        //今の値を返すメソッド
        public int GetStatAmount()
        {
            return Stat;
        }

        //Vector3(スケール)のために割合で正規化する
        public float GetStatAmountNormalized()
        {
            return (float)Stat / STAT_MAX;
        }


    }

}
