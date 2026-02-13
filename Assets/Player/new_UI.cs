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

    //Up //Down
    public GameObject Up;
    public GameObject Down;

    //プレイヤーのタグチェック機能を参照するために必要な変数
    public CheckpointTag checkTag;
    public PlayerMove playermove;
    public Event events;

    void Start()
    {
        //スクリプトを設定
        checkTag = checkTag.GetComponent<CheckpointTag>();
        playermove = checkTag.GetComponent<PlayerMove>();

        Up.SetActive(false);
        Down.SetActive(false);
    }

    void Update()
    {
        WordUp();       //セリフ表示
        WordDelete();   //セリフ非表示
    }

    void WordUp()
    {
        //Up,Down
        if (events.Event_scene == true && playermove.TTEv >= 2.0f)
        {
            Up.SetActive(true);
            Down.SetActive(true);
        }

    }
    void WordDelete()
    {
        //Up,Down
        if (events.Event_scene == false)
        {
            Up.SetActive(false);
            Down.SetActive(false);
        }

    }
}


