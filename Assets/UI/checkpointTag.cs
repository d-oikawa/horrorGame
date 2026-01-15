using UnityEngine;

// チェックポイントタグを配列にまとめたクラス
public class CheckpointTag : MonoBehaviour
{
    public string[] chekepointTag =
        {
        "None",
        "Start",
        "Day1_end",
        "Day2_Start",
        "Search_1",
        "Runaway",
        "Search_2",
        "Day2_end",
        "Day3_Start",
        "Exit_1",
        "Exit_2"
    };
    // 現在のチェックポイントタグ
    public string currentCheckpointTag;

    // 次のチェックポイントタグ
    public string nextCheckpointTag;

    // 到達したチェックポイントタグの取得
    public string fetchedCheckpointTag;

    public void SetfetchedCheckpointTag(string tag)
    {
        fetchedCheckpointTag = tag;
    }

    // UVRect用にチェックポイントをint型で取得
    public int GetCurrentCheckpointIndex()
    {
        return System.Array.IndexOf(chekepointTag, currentCheckpointTag);
    }

    void Start()
    {
        // 初期値を設定
        currentCheckpointTag = chekepointTag[1];
        nextCheckpointTag = chekepointTag[2];
    }

    void Update()
    {

        // チェックポイントタグの更新
        if (fetchedCheckpointTag == currentCheckpointTag)
        {
            currentCheckpointTag = nextCheckpointTag;
            // 次のチェックポイントタグを設定
            int currentIndex = System.Array.IndexOf(chekepointTag, currentCheckpointTag);
            if (currentIndex + 1 < chekepointTag.Length)
            {
                nextCheckpointTag = chekepointTag[currentIndex + 1];
            }
            else
            {
                nextCheckpointTag = "None"; // 最後のチェックポイントに到達した場合
            }
        }


    }
}
