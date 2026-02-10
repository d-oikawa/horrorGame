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

    //吹き出しをどこでも使うために必要な数字
    public int Count;

    //吹き出しの画像を入れる
    public GameObject se;

    //プレイヤーのタグチェック機能を参照するために必要な変数
    public CheckpointTag checkTag;
    public PlayerMove playermove;

    void Start()
    {
        //スクリプトを設定
        checkTag = checkTag.GetComponent<CheckpointTag>();
        playermove = checkTag.GetComponent<PlayerMove>();

        ui1.SetActive(false);
        ui2.SetActive(false);
        ui3.SetActive(false);
        ui4.SetActive(false);

        se.SetActive(false);
    }

    void Update()
    {
        WordUp();       //セリフ表示
        WordDelete();   //セリフ非表示
    }

    void WordUp()
    {
        //セリフ１
        if (checkTag.fetchedCheckpointTag == "Day2_Start" && Timer1 <= 3.0f)
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
        if(playermove.hitTag=="bookstand")
        {
            ui3.SetActive(true);
            se.SetActive(true);
            Timer3 += Time.deltaTime;
            Count = 3;
        }
        //セリフ4
        if (playermove.hitTag == "Exit")
        {
            ui4.SetActive(true);
            se.SetActive(true);
            Timer4 += Time.deltaTime;
            Count = 4;
        }
    }

    void WordDelete()
    {
        //セリフ１
        if (Timer1 >= 3.0f && Count==1)
        {
            ui1.SetActive(false);
            se.SetActive(false);
            Count = 0;
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
    }
}
   
