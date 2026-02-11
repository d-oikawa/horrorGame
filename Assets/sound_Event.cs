using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using static Unity.Burst.Intrinsics.X86.Avx;
using static UnityEngine.Rendering.DebugUI;

public class Event : MonoBehaviour
{
    public event Action TheSound;
  
    public ItemBase iitem;

    public GameObject itflg;

    public bool enemy_sound;

    //イベントsceneか否か
    public bool Event_scene;

    public bool start_soene;

    //エネミーオブジェクト
    [SerializeField]
    public GameObject enemy_ob;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Event_scene = false;
        enemy_sound = false;
        start_soene = false;
        itflg = GameObject.FindWithTag("Testitem");
        iitem = itflg.GetComponent<ItemBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if(iitem.IsItemOnGround)
        {
            enemy_sound = true;
            //Debug.Log("きょおおお");
        }
        TheSound?.Invoke();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            enemy_ob.SetActive(true);
                   
            //現在がイベントsceneかどうか
            Event_scene = true;

            //最初のイベントsceneのフラグ(これをつかってイベントsceneの処理をしてください。)
            start_soene = true;
        }

        //Debug.Log("Event_scene" + Event_scene);
        //Debug.Log("start_soene" + start_soene);
    }

    void detect_sound()
    {
        Debug.Log("ping");
    }

    void jyavavavava()
    {
        Debug.Log("しょうゆ");
    }

}
