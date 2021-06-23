using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Main画面のアイテム情報全般を保持するデータベース
public class Item_DataBase : MonoBehaviour
{
    public List<Items> items;

    //データを以下に追記,配列のように取り出せる
    void Awake()
    {
        //ItemName,ID,Desc,IconName,ability,cost
        items = new List<Items>();
        items.Add(new Items("青いエレキギター", 0, "視聴者数UP +10", "BuleGuitar", 0, 75000, "新品の青いエレキギター(配置可)"));
        items.Add(new Items("クラシックなギター", 1, "視聴者数UP +10%", "ClaGuitar", 1, 50000, "100年もののクラシックギター(配置可)"));
        items.Add(new Items("快眠ベッド", 2, "やる気の回復速度UP +10%", "Bed", 0, 400000, "快適なベッド(配置可)"));
        items.Add(new Items("ソファ", 3, "やる気の回復速度UP +10%", "Sofa", 0, 250000, "ゆったり座れるソファ(配置可)"));
        items.Add(new Items("木製丸テーブル", 4, "やる気の回復速度UP +5%", "MaruTable", 0, 50000, "温かみのある木製テーブル(配置可)"));
        items.Add(new Items("ガラス製テーブル", 5, "やる気の回復速度UP +5%", "GlassTable", 0, 100000, "ガラスでできたテーブル(配置可)"));
        items.Add(new Items("青色ランプ", 6, "視聴継続率UP +15%", "BuleLump", 0, 125000, "消費電量を抑えたランプ(配置可能"));
        items.Add(new Items("ドレッサー", 7, "視聴継続率UP +35%", "Dresser", 0, 400000, "最新式ドレッサー(配置可)"));
        items.Add(new Items("観葉植物", 8, "視聴継続率UP +5%", "FakeTree", 0, 35000, "室内でも大きく育つ観葉植物(配置可)"));
        items.Add(new Items("真ん丸カーペット", 9, "視聴継続率UP +15%", "CurPet", 0, 150000, "丁度良いサイズ感のカーペット(配置可)"));
        items.Add(new Items("本棚", 10, "視聴者数UP +15%", "Shelf", 0, 250000, "大量の本を収納できる棚(配置可)"));
        items.Add(new Items("3色収納棚", 11, "視聴者数UP +15%", "TreeShelf", 0, 150000, "様々なものを収納できる棚(配置可)"));
        items.Add(new Items("青いドラムセット", 12, "視聴者数UP +20%", "Drum", 0, 300000, "本格的なドラムセット(配置可)"));
        items.Add(new Items("高性能マイク", 13, "視聴者数UP +25%", "Mike", 0, 450000, "配信にも歌にも使える万能マイク(配置可)"));
        items.Add(new Items("液晶テレビ", 14, "視聴者数UP +30%", "TV", 0, 750000, "対応液晶テレビ(配置可)"));
        items.Add(new Items("YBOX型ゲーム機", 15, "レアチャット獲得確率UP +5%", "YBOX", 0, 30000, "海外の大人気ゲーム機(配置可)"));
        items.Add(new Items("Wee型ゲーム機", 16, "レアチャット獲得確率UP +5%", "Wee", 0, 75000, "国内の最新大人気ゲーム機(配置可)"));
        items.Add(new Items("キューブ型ゲーム機", 17, "レアチャット獲得確率UP +5%", "Qbe", 0, 100000, "国内の大人気ゲーム機(配置可)"));
        items.Add(new Items("アーケードゲーム機", 18, "レアチャット獲得確率UP +55%", "Acade", 0, 2000000, "憧れのアーケードゲーム機(配置可)"));
        items.Add(new Items("PC強化パーツ1", 19, "全効果 +15%", "PCone", 0, 1000000, "配信デスクのPCを強化するパーツ1"));
        items.Add(new Items("PC強化パーツ2", 20, "全効果 +15%", "PCtwo", 0, 1000000, "配信デスクのPCを強化するパーツ2"));
        items.Add(new Items("スタイル強化キット", 21, "スタイル強化ポイントを1獲得する", "StyleKit", 0, 50000, "自身のスタイルをより強化する増幅剤"));
        items.Add(new Items("配信デスク", 22, "ライブ配信を可能にする", "LiveDesk", 0, 0, "ライブ配信には欠かせないPCを乗せた配信用デスク(配置可)"));
        items.Add(new Items("配信チェア", 23, "ライブ配信を可能にする", "LiveChair", 0, 0, "ライブ配信には欠かせない座り心地の良いイス(配置可)"));


    }

    //やる気回復速度 = 計55%
    //視聴者数増加 = 計150%
    //視聴継続率 = 計100%
    //レアチャット獲得率 = 計100%




}
