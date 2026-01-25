using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // checkpointTagクラスの読み込み
    //[SerializeField] private CheckpointTag _checkpointtag;
    //テキストオブジェクト(髙山)
    [SerializeField] private TextMeshProUGUI tExt;

    //private RawImage _rawImage;

    // 1タイルの幅と高さ
    //private const float Tile_Size_w = 0.25f;
    //private const float Tile_Size_h = 0.5f;
    //private int col;
    //private int row;

    public float ti; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ti = 0;
        //_rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tExt.enabled) {
            ti += Time.deltaTime;
            if (ti > 5)
            {
                ti = 0;
                tExt.enabled = false;
            }
        }
        //SetColRow(_checkpointtag.GetCurrentCheckpointIndex());
        //_rawImage.uvRect = new Rect(col, row, Tile_Size_w, Tile_Size_h);
    }

    // 受け取ったインデックスからcolとrowを計算する
    void SetColRow(int index)
    {
        //col = index % 4;
        //if (index >= 4)
        //{
        //    row = 1;
        //}
        //else
        //{
        //    row = 0;
        //}
    }

    //鍵がない際の表示(髙山)
    public void DontKey()
    {
        //ti = Time.deltaTime;
        tExt.enabled = true;
        tExt.text = "開かない";
        //if (ti > 5)
        //{
        //    Debug.Log("ｇｋそｇ");
        //    ti = 0;
        //    tExt.enabled = false;
        //    return;
        //}
    }
}
