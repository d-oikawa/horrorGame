using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class fade : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    privateÅ@IEnumerator ChangeAlpha( float a, Action w , bool o = false)
    {
        if (!o)
        {
            image.enabled = true;
        }


        float time = 0.0f;

        var color = image.color;

        while (time < a)
        {
            var rate = Mathf.Min(time / a, 1.0f);
            color.a = o ? 1.0f - rate : rate;

                
            image.color = color;

            yield return null;
            time += Time.deltaTime;
        }

        if (o)
        {
            image.enabled = false;
        }
        if(w != null)
        {
            w();
        }
    }
    public void FadeIn(float a, Action w = null)
    {
        StartCoroutine(ChangeAlpha(a, w, true));
    }

    public void FadeOut(float a, Action w = null)
    {
        StartCoroutine(ChangeAlpha(a, w));
    }


}
