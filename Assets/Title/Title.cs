using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown("joystick button 1"))
        {
            SceneManager.LoadScene("Enemy_Scene");//Ÿ‚És‚«‚½‚¢ƒV[ƒ“–¼‚ğ‘‚­
        }  
    }
}
