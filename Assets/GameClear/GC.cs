using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GC : MonoBehaviour
{
    //吹き出しの画像を入れる       
  //  public GameObject se;
    //吹き出しの画像を入れる       
 //   public GameObject notoCloze;
    //吹き出しの画像を入れる       
   // public GameObject notoOpen;
    public GameObject UP;
    public GameObject Down;
    public float Timer;
    public float Timer2;

    public GameObject score_object = null; // Textオブジェクト
    public int Word = 0; // スコア変数
    public Text score_text;

    //サウンドで使う変数
   // public AudioSource audioSource;
   // public AudioClip sound1;
    //public AudioClip sound2;

    void Start()
    {
        score_text = score_object.GetComponent<Text>();
        score_object.SetActive(false);
      // se.SetActive(false);
       // notoCloze.SetActive(false);
       // notoOpen.SetActive(false);
        UP.SetActive(true);
        Down.SetActive(true);

        //Componentを取得(サウンド)
       // audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 1.0f && Word == 0)
        {
            score_object.SetActive(true);
           // se.SetActive(true);
           // notoCloze.SetActive(true);
            score_text.text = "続いてのニュースです。";

            Word = 1;
        }
        if (Timer >= 3.0f && Word == 1)
        {
            score_text.text = "静岡県○○市の森の中で男性の死体が発見されました。";
           // notoCloze.SetActive(false);
            Word = 2;
           // audioSource.PlayOneShot(sound1);
        }
        if (Timer >= 5.0f && Word == 2)
        {

           // notoOpen.SetActive(true);
            score_text.text = "死体には三本の大きな鋭い物でえぐられたような痕があり、最近話題になっている生物ではないかと言われています。";
            Word = 3;
        }
        if (Timer >= 10.0f && Word == 3)
        {
            
            score_text.text = "警察は事故死として調査を進めています。";
            Word = 4;
        }
        if (Timer >= 15.0f && Word == 4)
        {
            score_text.text = "Bボタンを押す";
        }
    }
}
