using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem.Switch;
using UnityEngine.UIElements;
public class Start_Day2_start : MonoBehaviour
{

    //チェックポイントの変数
    public CheckpointTag checkpointtag_1;
    // public GameObject checkpointtagobj_1;

    private void Update()
    {
        if (checkpointtag_1.currentCheckpointTag == "Day2_Start")
        {
            gameObject.tag = "Day2_Start";
        }

    }
}