using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NEW_UI1 : MonoBehaviour
{
    public GameObject score_object = null; // Textオブジェクト
    public int Word = 0; // スコア変数
    public Text score_text;

    //プレイヤーのタグチェック機能を参照するために必要な変数
    public CheckpointTag checkTag;
    public PlayerMove playermove;
    public Event events;
    public float Timer5;
    public int Count;
    //吹き出しの画像を入れる       
    public GameObject se;

    // 初期化
    void Start()
    {
        score_text = score_object.GetComponent<Text>();
        checkTag = checkTag.GetComponent<CheckpointTag>();
        playermove = checkTag.GetComponent<PlayerMove>();
        se.SetActive(false);
    }

    // 更新
    void Update()
    {
        WordUp();       //セリフ表示

        if (Count == 5 && Timer5 <= 3.0f)
        {
            Timer5 += Time.deltaTime;
            score_object.SetActive(true);
            se.SetActive(true);
        }
        if (Timer5 >= 3.0f && Count == 5)
        {
            score_object.SetActive(false);
            se.SetActive(false);
            Timer5 = 0;
            Count = 0;
        }
    }

    //セリフ表示
    void WordUp()
    {
        //セリフ5
        if (playermove.ct == 1 || playermove.timer4 > 1.0f && Word == 0)
        {
            // テキストの表示を入れ替える
            score_text.text = "             何の音だ...ドアの方から聞こえたぞ...?";
            Timer5 = 0;
            Count = 5;
            playermove.ct = 2;
            Word = 1;
            playermove.hitTag = null;
        }
        //セリフ１
        if (playermove.hitTag == "Day2_Start" )
        {
            // テキストの表示を入れ替える
            score_text.text = "             あかなくなってしまった。ど、どうしよう";
            Timer5 = 0;
            Count = 5;
            Word = 2;
            playermove.hitTag = null;
        }
        //セリフ２
        if (playermove.hitTag == "Map" )
        {
            // テキストの表示を入れ替える
            score_text.text = "ん？この地図、一部屋切り取られてるな気になるし向かって見るか";

            Timer5 += Time.deltaTime;
            Count = 5;
            Word = 3;
            playermove.hitTag = null;
        }
        //セリフ３
        if (playermove.hitTag == "bookstand" )
        {
            // テキストの表示を入れ替える
            score_text.text = "                                 うわ扉が出てきた...";

            Timer5 += Time.deltaTime;
            Count = 5;
            Word = 4;
            playermove.hitTag = null;
        }
        //セリフ4
        if (playermove.hitTag == "Exit")
        {
            // テキストの表示を入れ替える
            score_text.text = "                    うーん開かないな、鍵が必要なのかな？";

            Timer5 += Time.deltaTime;
            Count = 5;
            Word = 5;
            playermove.hitTag = null;
        }

    }
}
