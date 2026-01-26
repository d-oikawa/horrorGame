using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{

    public void Update()
    {
        Cursor.visible = true;//表示
        Cursor.lockState = CursorLockMode.None; //マウスカーソルを自由に

        SceneManager.LoadScene("Title");//次に行きたいシーン名を書く
    }
}
