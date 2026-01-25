using UnityEngine;
using UnityEngine.SceneManagement;

public class gameclear_seni : MonoBehaviour
{
    public GameObject ply;
    public CheckpointTag pm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ply = GameObject.FindWithTag("Player");
        pm = ply.GetComponent<CheckpointTag>();

    }

    // Update is called once per frame
    void Update()
    {
        if(pm.fetchedCheckpointTag == "Exit_1")
        SceneManager.LoadScene("GameClear");//Ÿ‚És‚«‚½‚¢ƒV[ƒ“–¼‚ğ‘‚­
    }
}
