using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemy_modechange: MonoBehaviour
{
    public CheckpointTag CKT;
    public GameObject ckt;

    [SerializeField]
    public GameObject enemy_ob;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ckt = GameObject.FindGameObjectWithTag("Player");
        CKT = ckt.GetComponent<CheckpointTag>();
        enemy_ob.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            CKT.fetchedCheckpointTag = "Runaway";
        }
        Debug.Log("‚Ì‚È‚©");

        if (CKT.fetchedCheckpointTag == "Runaway")
        {
            enemy_ob.SetActive(true);
        }
    }
}
