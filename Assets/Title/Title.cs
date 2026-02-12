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

    public Action on_completed;

    public Action on_completede;

    public bool dontketdown;

    public void Start()
    {
        dontketdown = true;
            
        on_completed = () =>
        {
            StartCoroutine(Wait3SecondsAndFadeOut());
        };

        on_completede = () =>
        {
            StartCoroutine(Wait3SecondsAndFadeInt());
        };

        fd = fade_out.GetComponent<fade>();
        fd.FadeIn(1.0f, on_completede);
    }

    public void Update()
    {
        if (!dontketdown)
        {
            if (Input.GetKeyDown("joystick button 1"))
            {
                fd.FadeOut(1.0f, on_completed);
                dontketdown = true;
            }
        }
    }

    private IEnumerator Wait3SecondsAndFadeOut()
    {
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene("Enemy_Scene");//次に行きたいシーン名を書く
    }

    private IEnumerator Wait3SecondsAndFadeInt()
    {
        yield return new WaitForSeconds(0f);
        dontketdown = false;
        //SceneManager.LoadScene("Enemy_Scene");//次に行きたいシーン名を書く
    }
}
