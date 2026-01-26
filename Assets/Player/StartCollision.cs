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

    void Start()
    {
        //スクリプトを設定
        playermove=playermove.GetComponent<PlayerMove>();
        playrobj.GetComponent<PlayerMove>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //もし当たったコリジョンがプレイヤーのものなら
       string ObjName=other.gameObject.name;
        if(ObjName=="Player")
        {
            // プレイヤーを操作不能に
            playermove.characterController.enabled = false;
            //キャラクターの位置を確認
            Vector3 charPos=playermove.transform.position;
            Vector3 charposKeep = charPos;
            
           
           
        }
    }
}
