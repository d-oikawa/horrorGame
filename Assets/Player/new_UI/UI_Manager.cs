using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    //チェックポイントの変数
    public CheckpointTag checkpointtag_ui;

    public GameObject UI_1;
    public GameObject UI_2;
    public GameObject UI_3;
    public GameObject UI_4;
    public GameObject UI_5;
    public GameObject UI_6;



    void Start()
    {
        //チェックポイント
        checkpointtag_ui = checkpointtag_ui.GetComponent<CheckpointTag>();
        UI_1.SetActive(false);
        UI_2.SetActive(false);
        UI_3.SetActive(false);
        UI_4.SetActive(false);
        UI_5.SetActive(false);
        UI_6.SetActive(false);


    }

    void Update()
    {
        if(checkpointtag_ui.currentCheckpointTag=="Start")
        {
            UI_1.SetActive(true);
        }
        else if(checkpointtag_ui.currentCheckpointTag == "Day1_end")
        {
            UI_1.SetActive(false);
            UI_2.SetActive(true);
        }
        else if(checkpointtag_ui.currentCheckpointTag == "Day2_Start")
        {
            UI_2.SetActive(false);
            UI_3.SetActive(true);
        }
        else if (checkpointtag_ui.currentCheckpointTag == "Search_1")
        {
            UI_3.SetActive(false);
            UI_4.SetActive(true);
        }
        else if (checkpointtag_ui.currentCheckpointTag == "Runaway")
        {
            UI_4.SetActive(false);
            UI_5.SetActive(true);
        }
    }
}
