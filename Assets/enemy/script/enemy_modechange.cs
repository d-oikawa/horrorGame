using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class enemy_modechange: MonoBehaviour
{
    public CheckpointTag CKT;
    public GameObject ckt;

    public PlayerMove Pm;

    [SerializeField]
    public GameObject enemy_ob;

    public Event eVent;

    public GameObject se;

    //public bool end_move;

    public bool mode1;

    public bool mode33;


    public spline_system spline;
   

    //子オブジェクトのColliderを全取得
    Collider[] colliders;


    //[SerializeField]
    //public GameObject player_ob;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ckt = GameObject.FindGameObjectWithTag("Player");
        Pm = ckt.GetComponent<PlayerMove>();

        CKT = ckt.GetComponent<CheckpointTag>();
        enemy_ob.SetActive(false);

        se = GameObject.FindGameObjectWithTag("Event");
        eVent = se.GetComponent<Event>();

        spline = enemy_ob.GetComponent<spline_system>();

        colliders = GetComponentsInChildren<Collider>();

        var mode = GetComponentsInChildren<modechange_Collider>(true);
        foreach (var h in mode)
        {
            h.SetParent(this);
        }

        mode1 = false;

        mode33 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pm.orgspeed1 != 0f && !mode33)
        {
            CKT.fetchedCheckpointTag = "Day2_Start";
            mode33 = true;
        }

        if ((CKT.fetchedCheckpointTag == "Day2_Start" && (mode1)) || Pm.have_key)
        {
            enemy_ob.SetActive(true);
        }
        //if (enemy_ob != null) {
            if (spline.change_splien)
            {
                enemy_ob.SetActive(false);
                spline.change_splien = false;
                mode1 = false;
            }
    }

    public void OnHit(Collider collider, modechange_Collider mode,bool modecen) {

        switch (mode.gameObject.tag)
        {
            case "Enemy_mode1":            
            mode1 = modecen;
            //spline.spline_change("Spline_A");
            break;

            case "Enemy_mode2":
                if (Pm.have_map)
                {
                    mode1 = modecen;
                }
            break;

            case "Enemy_mode3":
                if (Pm.have_map)
                {
                    spline.Next_Spline("Spline_C");
                }

                //mode1 = modecen;
                break;

        }
                


        if (mode.gameObject.tag == "Enemy_mode2" || mode.gameObject.tag == "Enemy_mode3")
        {
            if (Pm.have_map)
            {
                mode.gameObject.SetActive(false);
            }
            return;
        }
        else
        {

            mode.gameObject.SetActive(false);
        }


        //Debug.Log("馬刺し");
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player" ))
        {
            //mode1 = true;
            //Debug.Log("馬刺し");
        }
    }
}
