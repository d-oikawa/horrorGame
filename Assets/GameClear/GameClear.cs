using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    public GC Ge;
    void Start()
    {
        Cursor.visible = true;//表示
        Cursor.lockState = CursorLockMode.None; //マウスカーソルを自由に
        Ge = Ge.GetComponent<GC>();
    }

    public void Update()
    {
        //Bボタン押したら進む場所
        if (Input.GetKeyDown("joystick button 1") && Ge.Timer>=15.0f)
        {
            SceneManager.LoadScene("Title");
        }
           
    }

}
