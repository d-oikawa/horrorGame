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
    //UI‚ğg‚¤•Ï”
    public GameObject ui1;
    public GameObject ui2;


    public GameObject se;

    //”‚ğ”‚¦‚é
    public float Timer;

    //ƒ^ƒO‚ğ’²‚×‚éŠÖ”
    public CheckpointTag chekTag; 

	 void Start()
	 {
        chekTag = chekTag.GetComponent<CheckpointTag>();
        ui1.SetActive(false);
        ui2.SetActive(false);
        se.SetActive(false);

    }

    void Update()
    {
        if(chekTag.fetchedCheckpointTag == "Day2_Start" && Timer <= 3.0f)
        {
            ui1.SetActive(true);
            se.SetActive(true);
            Timer += Time.deltaTime;
        }
        else if(chekTag.fetchedCheckpointTag == "Map" && Timer <= 6.0f)
        {
            Timer = 0;
            ui2.SetActive(true);
            se.SetActive(true);
            Timer += Time.deltaTime;
           
         }
        // else if (chekTag.fetchedCheckpointTag == "Day2_Start")
        // {
        //     UI_1.SetActive(true);
        //     Timer += Time.deltaTime;
        // }
        // else if (chekTag.fetchedCheckpointTag == "Day2_Start")
        // {
        //   UI_1.SetActive(true);
        //   //  Timer += Time.deltaTime;
        // }
        if (Timer>=3.0f)
        {
            ui1.SetActive(false);
            ui2.SetActive(false);

            se.SetActive(false);
           
        }

    }
}
