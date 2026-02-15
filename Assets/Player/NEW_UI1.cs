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
    public float Timer;
    public float Timer5;
    public int Count;
    public int CCC;
    //吹き出しの画像を入れる       
    public GameObject se;

    public GameObject Controra;
    public GameObject Hand;
    public GameObject purasu;
    public GameObject maru;
    public GameObject maru1;
    public GameObject maru2;

    public int clct;

    // 初期化
    void Start()
    {
        score_text = score_object.GetComponent<Text>();
        events = events.GetComponent<Event>();
        checkTag = checkTag.GetComponent<CheckpointTag>();
        playermove = checkTag.GetComponent<PlayerMove>();
        se.SetActive(false);
        Controra.SetActive(false);
        Hand.SetActive(false);
        purasu.SetActive(false);
        maru.SetActive(false);
        maru1.SetActive(false);
        maru2.SetActive(false);
        clct = 0;
    }

    // 更新
    void Update()
    {
        WordUp();       //セリフを更新

        //セリフを表示
        if (Count == 5 && Timer5 <= 4.0f)
        {
            Timer5 += Time.deltaTime;
            score_object.SetActive(true);
            se.SetActive(true);
        }
        //セリフを非表示
        if (Timer5 >= 3.0f && Count == 5 )
        {
            score_object.SetActive(false);
            se.SetActive(false);
           

            Timer5 = 0;
            Count = 0;
        }
        if(Word==2)
        {
            Controra.SetActive(false);
            Hand.SetActive(false);
            purasu.SetActive(false);
            maru.SetActive(false);
        }
        if(Word==3 && Input.GetKey("joystick button 4"))
        {
            Controra.SetActive(false);
            maru1.SetActive(false);
            maru2.SetActive(false);
        }
    }

    //セリフ表示
    void WordUp()
    {
        //セリフ1
        if (playermove.ct == 1 || playermove.timer4 > 1.0f && Word == 0)
        {
            // テキストの表示を入れ替える
            score_text.text = "            何の音だ...ドアの方から聞こえたぞ...?";

            Controra.SetActive(true);
            Hand.SetActive(true);
            purasu.SetActive(true);
            maru.SetActive(true);

            Timer5 = 0;
            Count = 5;
            playermove.ct = 2;
            Word = 1;
            playermove.hitTag = null;
        }
        //セリフ2
        if (playermove.hitTag == "Day2_Start" )
        {
            // テキストの表示を入れ替える
            score_text.text = "             あかなくなってしまった。ど、どうしよう";
            Timer5 = 0;
            Count = 5;
            Word = 2;
            playermove.hitTag = null;
        }
        //セリフ3
        if(events.start_soene==false && playermove.ctEv==1 && Word == 2)
        {
            score_text.text = "    あ、あれが噂の…？本当に目が見えてないみたいだ…\n静かに歩けば近くでも大丈夫かも…";
            Timer5 = 0;
            Count = 5;
            Word = 3;
            Timer=1.0f;
           
            //playermove.hitTag = null;
        }
         if(Word==3 && Timer==1.0f && Count==0)
        {
            score_text.text = "    LB + スティックで静かに歩るく";
            Controra.SetActive(true);
            maru1.SetActive(true);
            maru2.SetActive(true);
            Timer5 = 0;
            Count = 5;
            Timer = 2.0f;
           
        }
        //セリフ4
        if (playermove.hitTag == "Map" )
        {
            // テキストの表示を入れ替える
            score_text.text = "ん？この地図、一部屋切り取られてるな気になるし向かって見るか";

            Timer5 += Time.deltaTime;
            Count = 5;
            Word = 4;
            playermove.hitTag = null;
        }
        //セリフ5
        if (playermove.hitTag == "bookstand" )
        {
            // テキストの表示を入れ替える
            score_text.text = "                      うわ扉が出てきた…";

            Timer5 += Time.deltaTime;
            Count = 5;
            Word = 5;
            Timer = 3.0f;
            playermove.hitTag = null;
        }
        if(Word==5 && Timer==3.0f && Count==0)
        {
            // テキストの表示を入れ替える
            score_text.text = "化け物が来てる…！！。クローゼットに隠れよう…！！";
            Timer = 4.0f;
            Timer5 += Time.deltaTime;
            Count = 5;
        }
        //セリフ７
        if (playermove.WopCount==1 && clct == 0)
        {
            // テキストの表示を入れ替える
            score_text.text = "タンスの中でメモみたいなのを拾ったけど…\nこれはパスワード…？";

            Timer5 += Time.deltaTime;
            Count = 5;
            Word = 5;
            clct = 1;
            playermove.hitTag = null;
        }
        //セリフ８
        if (playermove.hitTag == "Exit")
        {
            // テキストの表示を入れ替える
            score_text.text = "                    うーん開かないな、鍵が必要なのかな？";

            Timer5 += Time.deltaTime;
            Count = 5;
            Word = 6;
            playermove.hitTag = null;
        }

    }
}
