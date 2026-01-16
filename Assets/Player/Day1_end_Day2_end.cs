using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem.Switch;
using UnityEngine.UIElements;

public class Day1_end_Day2_end : MonoBehaviour
{
    //チェックポイントの変数
    public CheckpointTag checkpointtag_2;

    private void Update()
    {
        if (checkpointtag_2.currentCheckpointTag == "Day2_end")
        {
            gameObject.tag = "Day2_end";
        }

    }
}
