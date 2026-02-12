using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;
using UnityEngine.InputSystem.Switch;
using UnityEngine.UIElements;

public class new_UI : MonoBehaviour
{
    //セリフに使う変数
    //１
    public GameObject ui1;
    public float Timer1;
    //２
    public GameObject ui2;
    public float Timer2;
    //３
    public GameObject ui3;
    public float Timer3;
    //4
    public GameObject ui4;
    public float Timer4;
    //5
    public GameObject ui5;
    public float Timer5;

    //6
    public GameObject ui6;
    public float Timer6;

    //7
    public GameObject ui7;
    public float Timer7;

    //Up //Down
    public GameObject Up;
    public float Timer8;
    public GameObject Down;
    public float Timer9;

    //吹き出しをどこでも使うために必要な数字
    public int Count;

    //吹き出しの画像を入れる       
    public GameObject se;

    //プレイヤーのタグチェック機能を参照するために必要な変数
    public CheckpointTag checkTag;
    public PlayerMove playermove;
    public Event events;

    void Start()
    {
        //スクリプトを設定
        checkTag = checkTag.GetComponent<CheckpointTag>();
        playermove = checkTag.GetComponent<PlayerMove>();

        ui1.SetActive(false);
        ui2.SetActive(false);
        ui3.SetActive(false);
        ui4.SetActive(false);
        ui5.SetActive(false);
        Up.SetActive(false);
        Down.SetActive(false);  

        se.SetActive(false);
    }

    void Update()
    {
        WordUp();       //セリフ表示
        WordDelete();   //セリフ非表示
    }

    void WordUp()
    {
        //セリフ5
        if (playermove.ct == 1 || playermove.timer4 > 1.0f && Timer5 <= 3.0f)
        {
            ui5.SetActive(true);
            se.SetActive(true);
            Timer5 += Time.deltaTime;
            Count = 5;
            playermove.ct = 2;
        }
        //セリフ１
        if (playermove.hitTag == "Day2_Start" && Timer1 <= 3.0f)
        {
            ui1.SetActive(true);
            se.SetActive(true);
            Timer1 += Time.deltaTime;
            Count=1;
        }
        //セリフ２
        if (checkTag.fetchedCheckpointTag == "Map" && Timer2 <= 3.0f)
        {
            ui2.SetActive(true);
            se.SetActive(true);
            Timer2 += Time.deltaTime;
            Count = 2;
        }
        //セリフ３
        if(playermove.hitTag=="bookstand" )
        {
            ui3.SetActive(true);
            se.SetActive(true);
            Timer3 += Time.deltaTime;
            Count = 3;
        }
        //セリフ4
        if (playermove.hitTag == "Exit" )
        {
            ui4.SetActive(true);
            se.SetActive(true);
            Timer4 += Time.deltaTime;
            Count = 4;
        }

        //Up,Down
        if(events.Event_scene== true && playermove.TTEv >= 2.0f)
        {
            Up.SetActive(true);
            Down.SetActive(true);
        }
       
    }
    void WordDelete()
    {
         //セリフ5
        if (Timer5 >= 3.0f && Count == 5)
        {
            ui5.SetActive(false);
            se.SetActive(false);
        }
        //セリフ１
        if (Timer1 >= 3.0f && Count==1)
        {
            ui1.SetActive(false);
            se.SetActive(false);
            Count = 10;
           
        }
        //セリフ２
        if (Timer2 >= 3.0f && Count==2)
        {
            ui2.SetActive(false);
            se.SetActive(false);
        }
        //セリフ３
        if (Timer3 >= 3.0f && Count == 3)
        {
            ui3.SetActive(false);
            se.SetActive(false);
        }
        //セリフ4
        if (Timer4 >= 3.0f && Count == 4)
        {
            ui4.SetActive(false);
            se.SetActive(false);
        }

        //Up,Down
        if (events.Event_scene == false)
        {
            Up.SetActive(false);
            Down.SetActive(false);
        }

    }
}
   
