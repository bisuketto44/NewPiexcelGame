using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Style_Status_RaderChart_DinamicMesh : MonoBehaviour
{
    //インスタンス生成
    private Style_Status_RaderChart RaderChartstats;
    //メッシュ生成
    [SerializeField]
    private CanvasRenderer raderMeshCanvasRendere;
    //マテリアル生成
    [SerializeField]
    private Material raderMaterial;


    //Stats.CSから持ってきて、このClassのStats変数に代入
    //ゲーム開始時に呼ばれ、別のScriptで初期化
    public void SetStats(Style_Status_RaderChart raderChartstats)
    {
        this.RaderChartstats = raderChartstats;
        UpdateStatsVisual();
    }

    private void UpdateStatsVisual()
    {
        /* transform.Find("AttackBar").localScale = new Vector3(1, stats.GetStatAmountNormalized(Stats.Type.Attack));
        transform.Find("DefenceBar").localScale = new Vector3(1, stats.GetStatAmountNormalized(Stats.Type.Defence)); */

        //生成するメッシュ
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

        //頂点の位置を指定。標準化した(最大値に対する割合)値が入る。頂点をスケールさせることで形を変更する
        Vector3 attackVertex = Quaternion.Euler(0, 0, -angleIncrement * 0) * Vector3.up * raderChartSize * RaderChartstats.GetStatAmountNormalized(Style_Status_RaderChart.Type.Serious);
        Vector3 defenceVertex = Quaternion.Euler(0, 0, -angleIncrement * 1) * Vector3.up * raderChartSize * RaderChartstats.GetStatAmountNormalized(Style_Status_RaderChart.Type.Funy);
        Vector3 SpeedVertex = Quaternion.Euler(0, 0, -angleIncrement * 2) * Vector3.up * raderChartSize * RaderChartstats.GetStatAmountNormalized(Style_Status_RaderChart.Type.Eros);
        Vector3 ManaVertex = Quaternion.Euler(0, 0, -angleIncrement * 3) * Vector3.up * raderChartSize * RaderChartstats.GetStatAmountNormalized(Style_Status_RaderChart.Type.Flames);
        Vector3 MagicVertex = Quaternion.Euler(0, 0, -angleIncrement * 4) * Vector3.up * raderChartSize * RaderChartstats.GetStatAmountNormalized(Style_Status_RaderChart.Type.Cute);
        Vector3 HPVertex = Quaternion.Euler(0, 0, -angleIncrement * 5) * Vector3.up * raderChartSize * RaderChartstats.GetStatAmountNormalized(Style_Status_RaderChart.Type.Crazy);


        int attackVertexIndex = 1;
        int defenceVertexIndex = 2;
        int SpeedVertexIndex = 3;
        int ManaVertexIndex = 4;
        int MagicVertexIndex = 5;
        int HPVertexIndex = 6;


        //三角形の座標を指定(時計回り)
        vertices[0] = Vector3.zero;
        vertices[attackVertexIndex] = attackVertex;
        vertices[defenceVertexIndex] = defenceVertex;
        vertices[SpeedVertexIndex] = SpeedVertex;
        vertices[ManaVertexIndex] = ManaVertex;
        vertices[MagicVertexIndex] = MagicVertex;
        vertices[HPVertexIndex] = HPVertex;

        //描画順を指定していく。
        triangles[0] = 0;
        triangles[1] = attackVertexIndex;
        triangles[2] = defenceVertexIndex;

        triangles[3] = 0;
        triangles[4] = defenceVertexIndex;
        triangles[5] = SpeedVertexIndex;

        triangles[6] = 0;
        triangles[7] = SpeedVertexIndex;
        triangles[8] = ManaVertexIndex;

        triangles[9] = 0;
        triangles[10] = ManaVertexIndex;
        triangles[11] = MagicVertexIndex;

        triangles[12] = 0;
        triangles[13] = MagicVertexIndex;
        triangles[14] = HPVertexIndex;

        triangles[15] = 0;
        triangles[16] = HPVertexIndex;
        triangles[17] = attackVertexIndex;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        raderMeshCanvasRendere.SetMesh(mesh);
        raderMeshCanvasRendere.SetMaterial(raderMaterial, null);
    }
}
