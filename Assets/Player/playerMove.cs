using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class PlayerMove:MonoBehaviour
{
    //アイテムベースの変数
   public GameObject Itemobj;
    public ItemBase itembase;
    
    //キャラクタコントローラーを使う為の変数
    public CharacterController characterController;

    //動く速さ変数
    public float walkSpeed;
    public float slowwalkSpeed;
    public float runSpeed;
    public  float speed;
    public float orgspeed1;

    //視点移動変数
    public float mauseSensitivti; //マウスの感度
    public Transform cam;
    private float xRotation;
    private bool PlayerSound;

    public Camera Camera;

    //プレイヤーが音を立てているか
    public bool IsPlayerSound() {  return PlayerSound; }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //マウスカーソルを中央に固定して非表示

        //アイテムのスクリプトを使う処理
        Itemobj = GameObject.FindGameObjectWithTag("Testitem");
        itembase = Itemobj.GetComponent<ItemBase>();  
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * Time.deltaTime;

        //歩き・走り・ゆっくり歩き
        if (Input.GetKey(KeyCode.LeftShift))    //走り
        {
            orgspeed1 = runSpeed;
            PlayerSound = true;
        }
        else if (Input.GetKey(KeyCode.LeftControl)) //ゆっくり歩き
        {
            orgspeed1 = slowwalkSpeed;
            PlayerSound = false;
        }
        else　//歩き
        {
            orgspeed1 = walkSpeed;
           // PlayerSound = true;
        }

        ////横移動
        //if (moveHorizontal >= 0)
        //{
        //    orgspeed1 = speed;
        //}
        ////縦移動
        //if(moveVertical>=0)
        //{
        //    orgspeed1 = speed;
        //}
        movement = transform.rotation * movement * orgspeed1;
        characterController.Move(movement);


        MoveCamera();   //カメラの上下左右の動き(視点)
        GetItem();      //Eを押したらアイテムを取得、投擲する処理


    } 

        //Eを押したらアイテムを取得、投擲する処理
        void GetItem()
        {
            ////Eを押したら
            //if (Input.GetKeyDown(KeyCode.E))
            //{

            //    //アイテムを持っているか否かでアイテムの取得・投擲を分岐
            //    switch (itembase.GetIsPlayerHaveItem())
            //    {
            //        case false:
            //            {
            //                //レイを使っての選択
            //                Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            //                RaycastHit hit;
            //                if (Physics.Raycast(ray, out hit, 3.0f))
            //                {
            //                    if (hit.collider.CompareTag("Testitem")) // タグが Testitem かどうかをチェック
            //                    {
            //                        //アイテムの取得
            //                        itembase.GetItem();
            //                        itembase.SetPlayerHaveItem(true);
            //                        Debug.Log("ゲット！！");
            //                    }
            //                }
            //            }
            //            break;
            //        case true:
            //            {
            //                //アイテムを投げる
            //                itembase.ThrowItem();
            //                itembase.SetPlayerHaveItem(false);
            //                Debug.Log("投擲！！");
            //            }
            //            break;
            //    }
            //}



            //Eを押したら
            if (Input.GetKeyDown(KeyCode.E))
            {
                //レイを使っての選択
                Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 3.0f))
                {
                }

                if (Physics.Raycast(ray, out hit, 3.0f))
                {
                    //アイテムをもってたら
                    if (itembase.GetIsPlayerHaveItem())
                    {
                        //アイテムを投げる
                        itembase.ThrowItem();
                        itembase.SetPlayerHaveItem(false);
                        Debug.Log("投擲！！");
                    }
                    //アイテムを持ってなかったら
                }

            }

        }

        //カメラの動き
        void MoveCamera()
        {
            //カメラの動き
            float mauseX = Input.GetAxisRaw("Mouse X") * mauseSensitivti * Time.deltaTime; //X
            transform.Rotate(Vector3.up * mauseX);
            float mouseY = Input.GetAxisRaw("Mouse Y") * mauseSensitivti * Time.deltaTime; //Y
            xRotation -= mouseY;
            //振り向き制限
            xRotation = Mathf.Clamp(xRotation, -60.0f, 60.0f);
            cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        }

    
 }

