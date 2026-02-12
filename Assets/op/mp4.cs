using UnityEngine;
using UnityEngine.SceneManagement;

public class mp4 : MonoBehaviour
{
    float Timer = 0;

    public void Update()
    {
        Timer += Time.deltaTime;

        //Bボタン押したら進む場所
        if (Timer>=3.0f)
        {
            SceneManager.LoadScene("Title");//次に行きたいシーン名を書く
        }

    }
}
