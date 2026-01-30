using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class enemy_modechange: MonoBehaviour
{
    public CheckpointTag CKT;
    public GameObject ckt;

    public PlayerMove Pm;

    [SerializeField]
    public GameObject enemy_ob;

    //[SerializeField]
    //public GameObject player_ob;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ckt = GameObject.FindGameObjectWithTag("Player");

        Pm = ckt.GetComponent<PlayerMove>();

        CKT = ckt.GetComponent<CheckpointTag>();
        enemy_ob.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Pm.orgspeed1 != 0f)
        {
            CKT.fetchedCheckpointTag = "Day2_Start";
        }

        if (CKT.fetchedCheckpointTag == "Day2_Start")
        {
            enemy_ob.SetActive(true);
        }
    }
}
