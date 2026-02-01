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

    public bool mode1;


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

        colliders = GetComponentsInChildren<Collider>();

        var mode = GetComponentsInChildren<modechange_Collider>(true);
        foreach (var h in mode)
        {
            //h.SetParent(this);
        }

        mode1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pm.orgspeed1 != 0f)
        {
            CKT.fetchedCheckpointTag = "Day2_Start";
        }

        if (CKT.fetchedCheckpointTag == "Day2_Start" && mode1)
        {
            enemy_ob.SetActive(true);
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            mode1 = true;
            Debug.Log("馬刺し");
        }
    }

}
