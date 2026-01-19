using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using static Unity.Burst.Intrinsics.X86.Avx;
using System;

public class Event : MonoBehaviour
{
    public event Action TheSound;
  
    public ItemBase iitem;

    public GameObject itflg;

    public bool enemy_sound;

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
