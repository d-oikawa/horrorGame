using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem.Switch;
using UnityEngine.UIElements;

public class PlayerMove:MonoBehaviour
{
    //アイテムベースの変数
   public GameObject Itemobj;
   public ItemBase itembase;

    //チェックポイントの変数
    public CheckpointTag checkpointtag;
    public GameObject checkpointtagobj;

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
    float mauseX;
    float mauseY;

	//レイで使う変数
	public Camera Camera;
    public string hitTag;

    //プレイヤーが音を立てているか
    public bool IsPlayerSound() {  return PlayerSound; }

    //隠れているかいないか
    public bool Ishide=false;
    Vector3 woldPos;

    //サウンドで使う変数
    public AudioSource audioSource;
    public AudioClip sound1;
    public AudioClip sound2;
    float timer1 = 0.0f;
    float timer2 = 0.0f;

    void Start()
    {
		UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        //マウスカーソルを中央に固定して非表示

        //Componentを取得(サウンド)
        audioSource = GetComponent<AudioSource>();

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
        onSaund();
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
                    //違うスクリプトの変数を使えるように
                    //アイテム
					itembase = itembase.GetComponent<ItemBase>();
                    gameObject.GetComponent<ItemBase>();

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
                        case "warp":
                        {
                                warp(hitTag);
                        }
                        break;
                        case "door":
                        {
                                Endwarp(woldPos);
                        }
                        break;

                        //チェックポイント
                        case "None":
                        {
								Pointyecu(hitTag);
						}
                        break;
						case "Start":
						{
								Pointyecu(hitTag);
						}
						break;
                        case "Day1_end":
                        {
								Pointyecu(hitTag);
                                
						}
                        break;
                        //逃げ道探し
						case "Day2_Start":
						{
								Pointyecu(hitTag);
						}
						break;
                         //地図探し
						case "Search_1":
						{
								Pointyecu(hitTag);
						}
						break;
						case "Runaway":
						{
								Pointyecu(hitTag);
						}
						break;
						case "Search_2":
						{
								Pointyecu(hitTag);
						}
						break;
						case "Day2_end":
						{
								Pointyecu(hitTag);
						}
						break;
						case "Day3_start":
						{
								Pointyecu(hitTag);
							}
						break;
						case "Exit_1":
						{
								Pointyecu(hitTag);
						}
						break;
						case "Exit_2":
						{
                                Pointyecu(hitTag);
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

    //カメラの動き
    void MoveCamera()
    {
        //カメラの動き
         mauseX = Input.GetAxisRaw("Mouse X") * mauseSensitivti * Time.deltaTime; //X
        transform.Rotate(Vector3.up *mauseX);
         mauseY = Input.GetAxisRaw("Mouse Y") * mauseSensitivti * Time.deltaTime; //Y
        xRotation -= mauseY;

        //振り向き制限
        xRotation = Mathf.Clamp(xRotation, -60.0f, 60.0f);
         cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        if(Ishide==true)
        {
            mauseX = 0.0f;
			xRotation = Mathf.Clamp(xRotation, 0.0f, 0.0f);
		}
    }
	
    //タグのオブジェクトにワープする処理
    private void warp(string Tag)
    {
        if (Ishide == false)
        {
            //隠れる前のプレイヤーの位置を保存
            woldPos = transform.position;
            characterController.enabled = false;
			//隠れている
			Ishide = true;
			GameObject haidpos = GameObject.FindGameObjectWithTag(Tag);
            transform.position = haidpos.transform.position;
            Debug.Log("warp!");
           
        }
    }

    //外に出る処理
    private void Endwarp(Vector3 Ppos)
    {
        Ishide = false;
        transform.position = Ppos;
        characterController.enabled = true;
        Debug.Log("WarpEnd");
    }

    //チェックポイントの処理
    public void Pointyecu(string tag)
    {
		//チェックポイント
		checkpointtag = checkpointtag.GetComponent<CheckpointTag>();
        //checkpointtagobj.GetComponent<CheckpointTag>();
       
        //もし前のミッションクリアしていたら
        if (Ishide==false)
        {
            for(int i=0; i<10; i++)
            {
				if (tag == checkpointtag.chekepointTag[i])
                {
                    
                    checkpointtag.SetfetchedCheckpointTag(checkpointtag.chekepointTag[i]);
                    Debug.Log("チェックポイント通過"+i);
                }
            }

			//if (tag == checkpointtag.chekepointTag[pointNum])
			//{
			//	++pointNum;
			//	cleatag = false;
			//             checkpointtag.SetfetchedCheckpointTag(checkpointtag.chekepointTag[pointNum]);
			//	Debug.Log("=1");
			//}
			//else if (tag == checkpointtag.chekepointTag[pointNum])
			//{
			//	++pointNum;
			//	cleatag = false;
			//	checkpointtag.SetfetchedCheckpointTag(checkpointtag.chekepointTag[pointNum]);
			//	Debug.Log("=2");
			//}
			//else if (tag == checkpointtag.chekepointTag[pointNum])
			//{
			//	++pointNum;
			//	cleatag = false;
			//	checkpointtag.SetfetchedCheckpointTag(checkpointtag.chekepointTag[pointNum]);
			//	Debug.Log("=3");
			//}
			//else if (tag == checkpointtag.chekepointTag[pointNum])
			//{
			//	++pointNum;
			//	cleatag = false;
			//	checkpointtag.SetfetchedCheckpointTag(checkpointtag.chekepointTag[pointNum]);
			//	Debug.Log("=4");
			//}
			//else if (tag == checkpointtag.chekepointTag[pointNum])
			//{
			//	++pointNum;
			//	cleatag = false;
			//	checkpointtag.SetfetchedCheckpointTag(checkpointtag.chekepointTag[pointNum]);
			//	Debug.Log("=5");
			//}
			//else if (tag == checkpointtag.chekepointTag[pointNum])
			//{
			//	++pointNum;
			//	cleatag = false;
			//	checkpointtag.SetfetchedCheckpointTag(checkpointtag.chekepointTag[pointNum]);
			//	Debug.Log("=6");
			//}
			//else if (tag == checkpointtag.chekepointTag[pointNum])
			//{
			//	++pointNum;
			//	cleatag = false;
			//	checkpointtag.SetfetchedCheckpointTag(checkpointtag.chekepointTag[pointNum]);
			//	Debug.Log("=7");
			//}
			//else if (tag == checkpointtag.chekepointTag[pointNum])
			//{
			//	++pointNum;
			//	cleatag = false;
			//	checkpointtag.SetfetchedCheckpointTag(checkpointtag.chekepointTag[pointNum]);
			//	Debug.Log("=8");
			//}
			//else if (tag == checkpointtag.chekepointTag[pointNum])
			//{
			//	++pointNum;
			//	cleatag = false;
			//	checkpointtag.SetfetchedCheckpointTag(checkpointtag.chekepointTag[pointNum]);
			//	Debug.Log("=9");
			//}
			//else if (tag == checkpointtag.chekepointTag[pointNum])
			//{
			//	++pointNum;
			//	cleatag = false;
			//	checkpointtag.SetfetchedCheckpointTag(checkpointtag.chekepointTag[pointNum]);
			//	Debug.Log("=10");
			//}
			//else if (tag == checkpointtag.chekepointTag[pointNum])
			//{
			//	++pointNum;
			//	cleatag = false;
			//	checkpointtag.SetfetchedCheckpointTag(checkpointtag.chekepointTag[pointNum]);
			//	Debug.Log("=11");
			//}
		}
    }

    //SEを鳴らす処理(歩く、走る)
    void onSaund()
    {

        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            //走る時の
            if (Input.GetKey(KeyCode.LeftShift))
            {
                timer2 += Time.deltaTime;
                if (timer2 > 1.2f)
                {
                    audioSource.PlayOneShot(sound2);
                    timer2 = 0.0f;
                }

            }
            //ゆっくり歩く時の
            else if(Input.GetKey(KeyCode.LeftControl))
            {
                audioSource.mute = false;
            }
            //歩く時の
            else
            { 
                timer1 += Time.deltaTime;
                if(timer1>1.5f)
                {
                    audioSource.PlayOneShot(sound1);
                    timer1 = 0.0f;
                }
            }
        }
    }
}

