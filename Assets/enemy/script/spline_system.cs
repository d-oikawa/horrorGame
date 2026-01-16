using System.Collections;
using System.Collections.Generic;
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

    //次のスプライトに移るまでの動き
    public bool spline_nextmove;

    //スプラインを変更するフラグ
    public bool change_splien;

    public bool next_spuline;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        //初期化
        spline_flg = true;
        splines_Percentage = 0;
        change_splien = false;
        next_spuline = false;
        //最初のスプラインを設定
		spline_change("Spline_A");        
    }

    // Update is called once per frame
    void Update()
    {
        //splineのタグを取得
        spline_tag = splineContainer.gameObject.tag;

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
                change_splien = true;
                spline_change("Spline_B");                
            }
        }

        //以下同文
        else if (splineContainer.tag == "Spline_B")
		{            
            if (splines_Percentage > 1f)
			{
				splines_Percentage = 0f;
				change_splien = true;
				spline_change("Spline_C");
			}
		}

		else if (splineContainer.tag == "Spline_C")
		{
			if (splines_Percentage > 1f)
			{
				splines_Percentage = 0f;
				change_splien = true;
				spline_change("Spline_D");
			}
		}
		else if (splineContainer.tag == "Spline_D")
		{
			if (splines_Percentage > 1f)
			{
				splines_Percentage = 0f;
				change_splien = true;
				spline_change("Spline_E");
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
				change_splien = true;
				spline_change("Spline_G");
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

        //移動速度を設定
        float move_speed = 3 / spuline_length;

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
        Debug.Log("スプラインにそって移動している");
    }    

    //スプラインを変更する処理
    void spline_change(string tagName)
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

        /*
        //スプラインを変更
        if (Input.GetKeyDown(KeyCode.Alpha1) && spline_tag != "Spline_A")
        {
            spline_change("Spline_A");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && spline_tag != "Spline_B")
        {
            spline_change("Spline_B");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && spline_tag != "Spline_C")
        {
            spline_change("Spline_C");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && spline_tag != "Spline_D")
        {
            spline_change("Spline_D");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && spline_tag != "Spline_E")
        {
            spline_change("Spline_E");
        }

        if (Input.GetKeyDown(KeyCode.Alpha6) && spline_tag != "Spline_F")
        {
            spline_change("Spline_F");
        }

        if (Input.GetKeyDown(KeyCode.Alpha7) && spline_tag != "Spline_G")
        {
            spline_change("Spline_G");
        }

        if (Input.GetKeyDown(KeyCode.Alpha8) && spline_tag != "Spline_H")
        {
            spline_change("Spline_H");
        }

        if (Input.GetKeyDown(KeyCode.Alpha9) && spline_tag != "Spline_I")
        {
            spline_change("Spline_I");
        }

        if (Input.GetKeyDown(KeyCode.Alpha0) && spline_tag != "Spline_J")
        {
            spline_change("Spline_J");
        }
        */
    }
}
