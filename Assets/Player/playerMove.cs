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
    public float runSpeed;  //走る
    public float walkSpeed; //歩く
    public float slowwalkSpeed;//ゆっくり歩く
    public float orgspeed1;    //スピードが入る

    //視点移動変数
    public float mauseSensitivti; //マウスの感度
    public Transform cam;
    private float xRotation;
    private bool PlayerSound;

    //レイで使う変数
    public Camera Camera;
    public string hitTag;

    //プレイヤーが音を立てているか
    public bool IsPlayerSound() {  return PlayerSound; }

    //隠れているかいないか
    private bool Ishide=false;
    Vector3 woldPos;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //マウスカーソルを中央に固定して非表示   
    }

    void Update()
    {
        //入力キーの判定
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //プレイヤーが向いている向きに併せて進む
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical)*Time.deltaTime;
        //移動するためのキーが押されているか
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        //移動スピード
        //遅く歩く
        if (Input.GetKey(KeyCode.LeftControl))    
        {
            orgspeed1 = slowwalkSpeed;
            PlayerSound = false;
        }
        //後ろ向きで移動
        else if (Input.GetKey(KeyCode.S))
        {
            
            orgspeed1 = 1.0f;
        }
       //走る
        else if (Input.GetKey(KeyCode.LeftShift))
        {
           
            orgspeed1 = runSpeed;
        }
       //横向きに移動
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            orgspeed1 = 2.0f;
        }
        //歩く(通常)
       else 
        {
            orgspeed1 = walkSpeed;
        }
       
        //歩く音の処理
        if (!isMoving || orgspeed1==slowwalkSpeed)
        {
            PlayerSound = false;
            Debug.Log("fff");
        }
        else
        {
            PlayerSound = true;
            Debug.Log("ttt");
        }

        //移動する処理
        movement = transform.rotation * movement * orgspeed1;
        if(characterController.enabled==true)
        {
			characterController.Move(movement);
		}

		if (Input.GetKey(KeyCode.N))
        {
			transform.position = woldPos;
		}
			

		MoveCamera();   //カメラの上下左右の動き(視点)
        GetItem();      //Eを押したらアイテムを取得、投擲する処理
        //Haid();
    }

    //Eを押したらアイテムを取得、投擲する処理
    void GetItem()
    {
        //Eを押したら
        if (Input.GetKeyDown(KeyCode.E))
        {
            //レイを使っての選択
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //アイテムを持っていなかったら
            if (!itembase.GetIsPlayerHaveItem())
            {
                //レイの感知する範囲
                if (Physics.Raycast(ray, out hit, 3.0f))
                {
                    //タグをstring型で管理
                    hitTag = hit.collider.gameObject.tag;
                    //そのタグごとの処理
                    switch (hitTag)
                    {
                        case "Testitem":
                        {
                            //アイテムの取得
                            itembase.GetItem();
                            itembase.SetPlayerHaveItem(true);
                            Debug.Log("ゲット！！");
                        }
                        break;
                    }
                }
            }
            else
            {
                //アイテムを投げる
                itembase.ThrowItem();
                itembase.SetPlayerHaveItem(false);
                Debug.Log("投擲！！");
            }
        }
    }
   
    //private void Haid()
    //{
      
    //}

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
	
    //タグのオブジェクトにワープする処理
 //   private void warp(string Tag)
 //   {
 //       if(Ishide==false)
 //       {
 //           //隠れる前のプレイヤーの位置を保存
 //           woldPos = transform.position;
 //           characterController.enabled = false;
	//		GameObject haidpos = GameObject.FindGameObjectWithTag(Tag);
	//		transform.position = haidpos.transform.position;
 //           Debug.Log("warp!");
 //           //隠れている
 //           Ishide = true;
	//	}     
 //   }

 //   //外に出る処理
 //   private void Endwarp(Vector3 Ppos)
 //   {
 //       Ishide = false;
 //       transform.position = Ppos;
 //       characterController.enabled = true;
 //       Debug.Log("WarpEnd");
	//} 
}

