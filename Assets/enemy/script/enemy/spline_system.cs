using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Splines;
public class spline_system : MonoBehaviour
{
    //スプイラン
    [SerializeField]
    private SplineContainer splineContainer;

    //動かすオブジェクト
    [SerializeField]
    private Transform enemy;

    //スプライン移動割合(0～1)
    [SerializeField]
    private float splines_Percentage;

    //スプラインに沿って移動しているか
    [SerializeField]
    public bool spline_flg;

    //アタッチされているスプラインのタグ
    public string spline_tag;

    //ひとつ前のスプラインの名前
    public string before_spline;


    //次のスプライトに移るまでの動き
    public bool spline_nextmove;

    //スプラインを変更するフラグ
    public bool change_splien;

    public bool next_spuline;

    public float tim;

    public enemy_move em;

    //sound_Evect.cs
    public Event eVent;

    public GameObject se;

    //仲介
    private intermediary inter;
    private GameObject ter;

    public bool event_chane_splien;

    public bool k;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        //splineに沿って移動しているかどうかのflagを初期化
        spline_flg = true;
        //スプラインパーセンテージを初期化
        splines_Percentage = 0;
        //スプラインを変更しているかどうかの初期化
        change_splien = false;
        //次のスプラインに移動するflagの初期化
        next_spuline = false;
        //一つ前のスプラインを初期化
        before_spline = null;
        //タイマーを初期化
        tim = 0;
        //最初のスプラインを設定
        spline_change("Spline_A");

        //イベントのスプラインに切り替わるかどうかの初期化
        event_chane_splien = false;

        ter = GameObject.FindWithTag("intermediary");
        inter = ter.GetComponent<intermediary>();

        se = GameObject.FindGameObjectWithTag("Event");
        eVent = se.GetComponent<Event>();

        em = GetComponent<enemy_move>();

        k = false;

    }


    // Update is called once per frame
    void Update()    {

        //splineのタグを取得
        if (splineContainer != null)
        {
        spline_tag = splineContainer.gameObject.tag;
        }

        //splineに沿って移動していないとき
        if (!spline_flg)
        {
            return;
        }
        //しているとき
        else
        {
            //万が一splineが設定されていないとき
            if (splineContainer == null || enemy == null)
            {
                Debug.Log("スプラインにそって移動していない");
                return;
            }
            //設定されているとき
            else
            {
                //スプラインを変更(デバッグ)
                spline_choice();
            }
        }
        //割合表示のデバッグ         
        //Debug.Log(splines_Percentage);

    }

    //スプイランに沿って移動する処理(ごり押し)
    void spline_move()
    {
        if (!inter.isevent_Scene)
        {
            //splineの長さ
            float spuline_length = 0f;

            //現在のスプラインタグを判別
            if (splineContainer.tag == "Spline_A")
            {
                //splineの長さを取得
                spuline_length = splineContainer.CalculateLength();
                //splineの終点に到達したら
                if (splines_Percentage > 1f)
                {
                    //splineパーセンテージを0に
                    splines_Percentage = 0f;
                    //spline変更フラグ
                    Next_Spline("Spline_B");
                }
            }

            //以下同文
            else if (splineContainer.tag == "Spline_B")
            {
                spuline_length = splineContainer.CalculateLength();

                if (splines_Percentage > 1f)
                {
                    splines_Percentage = 0f;
                    //change_splien = true;
                    Next_Spline("Spline_C");
                }
            }

            else if (splineContainer.tag == "Spline_C")
            {
                spuline_length = splineContainer.CalculateLength();

                if (splines_Percentage > 1f)
                {
                    splines_Percentage = 1f;
                    //change_splien = true;
                    //spline_change("Spline_D");
                }
            }
            else if (splineContainer.tag == "Spline_D")
            {
                if (splines_Percentage > 1f)
                {
                    splines_Percentage = 1f;
                    //change_splien = true;
                    //Next_Spline("Spline_E");
                }
            }
            else if (splineContainer.tag == "Spline_E")
            {
                if (splines_Percentage > 1f)
                {
                    splines_Percentage = 0f;
                    change_splien = true;
                    spline_change("Spline_F");
                }
            }
            else if (splineContainer.tag == "Spline_F")
            {
                if (splines_Percentage > 1f)
                {
                    splines_Percentage = 0f;
                    //change_splien = true;
                    //spline_change("Spline_G");
                }
            }
            else if (splineContainer.tag == "Spline_G")
            {
                if (splines_Percentage > 1f)
                {
                    splines_Percentage = 0f;
                    change_splien = true;
                    spline_change("Spline_H");
                }
            }
            else if (splineContainer.tag == "Spline_H")
            {
                if (splines_Percentage > 1f)
                {
                    splines_Percentage = 0f;
                    change_splien = true;
                    spline_change("Spline_I");
                }
            }
            else if (splineContainer.tag == "Spline_I")
            {
                if (splines_Percentage > 1f)
                {
                    splines_Percentage = 0f;
                    change_splien = true;
                    spline_change("Spline_J");
                }
            }
            else if (splineContainer.tag == "Spline_J")
            {
                if (splines_Percentage > 1f)
                {
                    splines_Percentage = 0f;
                    change_splien = true;
                    spline_change("Spline_A");
                }
            }

            //splineの長さを取得
            spuline_length = splineContainer.CalculateLength();

            Debug.Log("スプラインの長さ" + spuline_length);


            //移動速度を設定
            float move_speed = 3 / spuline_length;

            //超絶デバッグ大魔神
            if (Input.GetKey(KeyCode.Alpha9))
            {
                move_speed = 300 / spuline_length;
            }


            //splineの割合で移動
            splines_Percentage += Time.deltaTime * move_speed;

            if(em.player_ishade && !k)
            {
                Debug.Log("ざるそば");
                splines_Percentage = 0.7f;
                k = true;
            }

            //Debug.Log("splineの長さ" + spuline_length);

            //位置を更新
            Vector3 pos = splineContainer.EvaluatePosition(splines_Percentage);
            enemy.position = pos;

            

            if((splineContainer.tag == "Spline_C"|| splineContainer.tag == "Spline_D") && (splines_Percentage >= 1 && splines_Percentage <=1.1))
            {
                tim += Time.deltaTime;
                //enemy.transform.Rotate(0, 36 * Time.deltaTime, 0);

                if (tim > 5)
                {
                    splines_Percentage = 0f;
                    tim = 0;
                    if (splineContainer.tag == "Spline_C")
                    {
                        spline_change("Spline_D");
                    }
                    else if(splineContainer.tag == "Spline_D")
                    {
                        spline_change("Spline_E");
                    }
                }
            }
            else
            {
                //回転を更新
                Vector3 tangent = ((Vector3)splineContainer.EvaluateTangent(splines_Percentage)).normalized;
                Vector3 up = ((Vector3)splineContainer.EvaluateUpVector(splines_Percentage));
                enemy.rotation = Quaternion.LookRotation(tangent, up);
                Debug.Log("スプラインにそって移動している");
            }
        }
    }    

    //スプラインを変更する処理
    public void spline_change(string tagName)
    {
        GameObject spline_obj = GameObject.FindGameObjectWithTag(tagName);

        //Nullチェック
        if(spline_obj == null)
        {
            Debug.Log("Splineが見つかりませんでした。");
            return;
        }

        SplineContainer sc = spline_obj.GetComponent<SplineContainer>();

        if (sc == null)
        {
            Debug.Log("Splineが見つかりませんでした。2");
            return;
        }


        //スプラインを変更
        splineContainer = sc;
        //スプラインのスタート地点に移動
        splines_Percentage = 0f;
    }


    //スプラインを変更する処理(デバッグ)
    void spline_choice()
    {
        //スプラインに沿って移動
        //(現在のスプラインと変更後スプラインが一致しない場合処理)
        spline_move();

        ////スプラインを変更
        //if (Input.GetKeyDown(KeyCode.Alpha1) && spline_tag != "Spline_A")
        //{
        //    spline_change("Spline_A");
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha2) && spline_tag != "Spline_B")
        //{
        //    spline_change("Spline_B");
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha3) && spline_tag != "Spline_C")
        //{
        //    spline_change("Spline_C");
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha4) && spline_tag != "Spline_D")
        //{
        //    spline_change("Spline_D");
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha5) && spline_tag != "Spline_E")
        //{
        //    spline_change("Spline_E");
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha6) && spline_tag != "Spline_F")
        //{
        //    spline_change("Spline_F");
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha7) && spline_tag != "Spline_G")
        //{
        //    spline_change("Spline_G");
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha8) && spline_tag != "Spline_H")
        //{
        //    spline_change("Spline_H");
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha9) && spline_tag != "Spline_I")
        //{
        //    spline_change("Spline_I");
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha0) && spline_tag != "Spline_J")
        //{
        //    spline_change("Spline_J");
        //}
    }

    //スプラインを切り替えるための関数だったのだが、change_splienをtrueにすると敵のアクティブがfalseになるので、
    //次のスプラインを設定しつつ、一度敵を消滅させるという意図のときに使ってください。
    public void Next_Spline(string spli)
    {
        spline_change(spli);
        change_splien = true;
        Debug.Log("ooo");
    }


    public void Event_Spline(int stopd_time, string spli, bool eve)
    {
        if (inter.isevent_Scene)
        {
            //splineの長さ
            float spuline_length;

            ////現在のスプラインタグを判別
            //if (splineContainer.tag == "Spline_A")
            //{
            //    //splineの長さを取得
            //    spuline_length = splineContainer.CalculateLength();
            //    //splineの終点に到達したら
            //    if (splines_Percentage > 1f)
            //    {
            //        //splineパーセンテージを0に
            //        splines_Percentage = 0f;
            //        //spline変更フラグ
            //        Next_Spline("Spline_B");
            //    }
            //}

            if ((before_spline != spli || before_spline == null)&& !event_chane_splien) 
            {
                spline_change(spli);
                event_chane_splien = eve;

                before_spline = spli;
            }

            
                //splineの長さを取得
                spuline_length = splineContainer.CalculateLength();

                Debug.Log("スプラインの長さ" + spuline_length);

                float move_speed = 3 / spuline_length;




            //移動速度を設定

            if (tim < stopd_time && splines_Percentage < 1)
            {
                //splineの割合で移動
                splines_Percentage += Time.deltaTime * move_speed;

                //Debug.Log("splineの長さ" + spuline_length);

                //位置を更新
                Vector3 pos = splineContainer.EvaluatePosition(splines_Percentage);
                enemy.position = pos;

                //回転を更新
                Vector3 tangent = ((Vector3)splineContainer.EvaluateTangent(splines_Percentage)).normalized;
                Vector3 up = ((Vector3)splineContainer.EvaluateUpVector(splines_Percentage));
                enemy.rotation = Quaternion.LookRotation(tangent, up);
                Debug.Log("イベントのスプラインにそって移動している");

                if (!em.AudioSource.isPlaying)
                {
                    em.AudioSource.PlayOneShot(em.sound1);
                }

            }

            if (tim > stopd_time)
            {
                //splineの割合で移動
                splines_Percentage -= Time.deltaTime * move_speed;

                //Debug.Log("splineの長さ" + spuline_length);

                //位置を更新
                Vector3 pos = splineContainer.EvaluatePosition(splines_Percentage);
                enemy.position = pos;

                //回転を更新
                //Vector3 tangent = ((Vector3)splineContainer.EvaluateTangent(splines_Percentage)).normalized;
                //Vector3 up = ((Vector3)splineContainer.EvaluateUpVector(splines_Percentage));
                //enemy.rotation = Quaternion.LookRotation(tangent, up);
                Debug.Log("イベントのスプラインにそって移動している");
                if (!em.AudioSource.isPlaying)
                {
                    em.AudioSource.PlayOneShot(em.sound1);
                }
            }


            if (splines_Percentage >= 1 && tim < stopd_time)
            {
                splines_Percentage = 1.1f;
                enemy.transform.Rotate(0, 60 * Time.deltaTime, 0);
                tim += Time.deltaTime;
            } 

            if(splines_Percentage < 0)
            {
                Next_Spline("Spline_A");
                splines_Percentage = 0f;
                tim = 0f;
                eVent.Event_scene = false;
                eVent.start_soene = false;

                this.gameObject.SetActive(false);
            }
        }
    }
}
