using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadoaut : MonoBehaviour
{
	float Speed = 0.002f;        //フェードするスピード
	float red, green, blue, alfa;

	public bool Out = false;
	public bool In = false;

	Image fadeImage;                //パネル

	public fast GetFast;
	public int Countt;

	void Start()
	{
		fadeImage = GetComponent<Image>();
		red = fadeImage.color.r;
		green = fadeImage.color.g;
		blue = fadeImage.color.b;
		alfa = fadeImage.color.a;


		GetFast = GetFast.GetComponent<fast>();
	}

	void Update()
	{
		if (GetFast.Timer>=22.0f && Countt==0)
		{
			FadeOut();
			
		}

		if (In)
		{
			FadeIn();
		}
	}

	void FadeIn()
	{
		alfa -= Speed;
		Alpha();
		if (alfa <= 0)
		{
			Countt = 1;
			fadeImage.enabled = false;
		}
	}

	void FadeOut()
	{
		fadeImage.enabled = true;
		alfa += Speed;
		Alpha();
		if (alfa >= 1)
		{
			Out = false;
		}
	}

	void Alpha()
	{
		fadeImage.color = new Color(red, green, blue, alfa);
	}
}
