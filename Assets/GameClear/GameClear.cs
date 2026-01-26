using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{

    void Start()
    {
        Cursor.visible = true;//表示
        Cursor.lockState = CursorLockMode.None; //マウスカーソルを自由に
    }

    public void onClickStartButton()
    {
        SceneManager.LoadScene("Title");
    }

}
