using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // checkpointTagクラスの読み込み
    [SerializeField] private CheckpointTag _checkpointtag;

    private RawImage _rawImage;

    // 1タイルの幅と高さ
    private const float Tile_Size_w = 0.25f;
    private const float Tile_Size_h = 0.5f;
    private int col;
    private int row;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        SetColRow(_checkpointtag.GetCurrentCheckpointIndex());
        _rawImage.uvRect = new Rect(col, row, Tile_Size_w, Tile_Size_h);
    }

    // 受け取ったインデックスからcolとrowを計算する
    void SetColRow(int index)
    {
        col = index % 4;
        if (index >= 4)
        {
            row = 1;
        }
        else
        {
            row = 0;
        }
    }
}
