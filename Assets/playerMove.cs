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

   //視点移動変数
    public float mauseSensitivti; //マウスの感度
    public Transform cam;
    private float xRotation;

    public Camera Camera;


    void Start()
    {
       
        Cursor.visible = false;
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
            movement = transform.rotation * movement * runSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftControl)) //ゆっくり歩き
        {
            movement = transform.rotation * movement * slowwalkSpeed;
        }
        else　//歩き
        {
            movement = transform.rotation * movement * walkSpeed;
        }
        characterController.Move(movement);

        //カメラの動き
        float mauseX = Input.GetAxisRaw("Mouse X") * mauseSensitivti * Time.deltaTime; //X
        transform.Rotate(Vector3.up * mauseX);
        float mouseY = Input.GetAxisRaw("Mouse Y") * mauseSensitivti * Time.deltaTime; //Y
        xRotation -= mouseY;
        //振り向き制限
        xRotation = Mathf.Clamp(xRotation, -60.0f, 60.0f);
        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
       

        //レイを使っての選択
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,3.0f))
        {
            if (hit.collider.CompareTag("Testitem")) // タグが Testitem かどうかをチェック
            {
                //Eを押したら
                if (Input.GetKey(KeyCode.E))
                {


                    //アイテムを持っているか否かでアイテムの取得・投擲を分岐
                    switch (itembase.GetIsPlayerHaveItem())
                    {
                        case false:
                            {
                                //アイテムの取得
                                itembase.GetItem();
                                itembase.SetPlayerHaveItem(true);
                                Debug.Log("ゲット！！");
                            }
                            break;
                        case true:
                            {
                                //アイテムを投げる
                                itembase.ThrowItem();
                                itembase.SetPlayerHaveItem(false);
                                Debug.Log("投擲！！");
                            }
                            break;
                    }
                }
            }
        }
    }
}

