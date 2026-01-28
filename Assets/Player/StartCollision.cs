using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;
using UnityEngine.InputSystem.Switch;
using UnityEngine.UIElements;

public class StartCollision : MonoBehaviour
{
    //プレイヤーを使う変数
    public GameObject playrobj;
    public PlayerMove playermove;

    //タグを使う変数
    public CheckpointTag checkpointtag;
    public GameObject checTagobj;

    public GameObject collesion;

    void Start()
    {
        //スクリプトを設定
        playermove=playermove.GetComponent<PlayerMove>();
        playrobj.GetComponent<PlayerMove>();

        //スクリプトを設定
        checkpointtag=checkpointtag.GetComponent<CheckpointTag>();
        collesion.SetActive(true);
    }

    void Update()
    {
       if(checkpointtag.fetchedCheckpointTag=="Day2_Start")
       {
			collesion.SetActive(false);
	   }
	}

    private void OnTriggerEnter(Collider other)
    {
        //もし当たったコリジョンがプレイヤーのものなら
       string ObjName=other.gameObject.name;
        if(ObjName=="Player")
        {
            //キャラクターの位置を確認
            Vector3 charPos=playermove.transform.position;
            Vector3 charposKeep = charPos;
        }
    }
}
