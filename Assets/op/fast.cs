using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fast : MonoBehaviour
{
    //吹き出しの画像を入れる       
    public GameObject se;
    //吹き出しの画像を入れる       
    public GameObject notoCloze;
    //吹き出しの画像を入れる       
    public GameObject notoOpen;
    public GameObject UP;
    public GameObject Down;
    public GameObject Skipe;
    public float Timer;
    public float Timer2;

    public GameObject score_object = null; // Textオブジェクト
    public int Word = 0; // スコア変数
    public Text score_text;

    //サウンドで使う変数
    public AudioSource audioSource;
    public AudioClip sound1;
    public AudioClip sound2;

    void Start()
    {
        score_text = score_object.GetComponent<Text>();
        score_object.SetActive(false);
        se.SetActive(false);
        notoCloze.SetActive(false);
        notoOpen.SetActive(false);
        UP.SetActive(true);
        Down.SetActive(true);
        Skipe.SetActive(true);

        //Componentを取得(サウンド)
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer>=1.0f && Word==0)
        {
            score_object.SetActive(true);
            se.SetActive(true);
            notoCloze.SetActive(true);
            score_text.text = "僕は未知の存在を調べる探偵だ、そんな僕のところにある一冊のノードが届いた。";

            Word = 1;
        }
        if(Timer>=3.0f && Word==1)
        {
            score_text.text = "                         中身を見てみると…";
            notoCloze.SetActive(false);
            Word = 2;
            audioSource.PlayOneShot(sound1);
        }
        if(Timer >= 5.0f && Word == 2)
        {
           
            notoOpen.SetActive(true);
            score_text.text = "                       何かの情報がまとめられていた。";
            Word = 3;
        }
        if (Timer >= 10.0f && Word == 3)
        {
            Timer2 += Time.deltaTime;
            if(Timer2<=0.1f && Word==3)
            {
                audioSource.PlayOneShot(sound2);

            }
            score_text.text = "そこには、【奇妙な音】、【大きな爪】、【目が見えない】特徴を持つ生物がいる、ということだ。";
            Word = 4;
        }
        if (Timer >= 15.0f && Word == 4)
        {
            score_text.text = "　　　　　その生物についての謎を解き明かす為、" + "" +
                "僕は静岡の洋館へ向かった。";
        }
        //Bボタン押したら進む場所
        if (Timer >= 23.0f || Input.GetKeyDown("joystick button 7"))
        {
            SceneManager.LoadScene("Enemy_Scene");//次に行きたいシーン名を書く
        }
    }
}
