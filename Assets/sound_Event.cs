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

    //ƒCƒxƒ“ƒgscene‚©”Û‚©
    public bool Event_scene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy_sound = false;
        itflg = GameObject.FindWithTag("Testitem");
        iitem = itflg.GetComponent<ItemBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if(iitem.IsItemOnGround)
        {
            enemy_sound = true;
            //Debug.Log("‚«‚å‚¨‚¨‚¨");
        }
        TheSound?.Invoke();


    }

    void detect_sound()
    {
        Debug.Log("ping");
    }

    void jyavavavava()
    {
        Debug.Log("‚µ‚å‚¤‚ä");
    }

}
