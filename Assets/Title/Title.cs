using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField]
    private GameObject fade_out;
    private fade fd;

    Action on_completed;


    public void Start()
    {
        on_completed = () =>
        {
            StartCoroutine(Wait3SecondsAndFadeOut());
        };
        fd = fade_out.GetComponent<fade>();
    }

    public void Update()
    {
        if (Input.GetKeyDown("joystick button 1"))
        {
            fd.FadeIn(2.0f, on_completed);
            SceneManager.LoadScene("Enemy_Scene");//Ÿ‚És‚«‚½‚¢ƒV[ƒ“–¼‚ğ‘‚­
        }  
    }

    private IEnumerator Wait3SecondsAndFadeOut()
    {
        yield return new WaitForSeconds(3.0f);
        fd.FadeOut(2.0f);
    }
}
