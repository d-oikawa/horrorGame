using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
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
    public float walkSpeed=4.0f; //歩く
    public float slowwalkSpeed;//ゆっくり歩く
    public float orgspeed1;    //スピードが入る
    public float moveHorizontal;
    public float moveVertical;

    //視点移動変数
    public float SensitivtiR; //向きを変えるスピード
    public float SensitivtiUp; //向きを変えるスピード
    public Transform cam;
    private float xRotation;
    private bool PlayerSound;
    float mauseX;
    float mauseY;
    float vvv;
    float timEv;

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
    public AudioClip sound3;
    public AudioClip sound4;
    float timer1 = 0.0f;
    float timer2 = 0.0f;
    float timer3 = 0.0f;
   public float timer4 = 0.0f;
    public int ct = 0;
    public int ct2 = 0;

    //マップを開く時に使う変数
    public GameObject map;
    public int count;
    public bool IsLook;
    public RectTransform Mapobj;

    //鍵を持っている(髙山)
    public bool have_key;

    //マップを持っている
    public bool have_map;

    //キャンバスそのもの(髙山)
    [SerializeField]
    public GameObject canvas;

    //本棚を動かす判定(髙山)
    public bool books_move;

    //金庫を上げる判定(髙山)
    public bool kinko;

    //金庫のCSファイル内の変数を使うため(髙山)
    public kinko Kinko;

    public GameObject kk;


	public GameObject dotPrefab; // 先ほど作ったSphereのプレハブ
	private GameObject _dotInstance;

    //イベントシーン
    //Event_sceneを呼ぶと制御出来る
    public Event sound_Event1;
    public GameObject se;
    public int ctEv;
    public float TTEv;

    //UIマネージャ
    public NEW_UI1 new_ui;


    //カメラ回転(イベント)
    float speed;
    Vector3 relativePos;
    Quaternion rotation;

    public GameObject targetObject; // 注視したいオブジェクトをInspectorから入れておく

    //敵出現のため一度だけ使用(髙山)
    private bool C;

    //タンスから脱出を制限(髙山)
    public bool closet_Exit;

    void Start()
    {
        SensitivtiR = 200;
        SensitivtiUp = 180;

        //Componentを取得(サウンド)
        audioSource = GetComponent<AudioSource>();
        map.SetActive(false);

        //チェックポイント
        checkpointtag = checkpointtag.GetComponent<CheckpointTag>();

        se = GameObject.FindGameObjectWithTag("Event");
        sound_Event1 = se.GetComponent<Event>();

        new_ui = new_ui.GetComponent<NEW_UI1>();

        kk = GameObject.FindWithTag("cashcase");
        Kinko = kk.GetComponent<kinko>();

        //髙山作boolたち
        have_key = false;   //鍵
        have_map = false;   //マップ
        books_move = false; //本棚
        kinko = false;      //金庫
        C = false;

        closet_Exit = false;
    }

    void Update()
    {
        //マウスカーソルを中央に固定して非表示
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

        //入力キーの判定
        moveHorizontal = Input.GetAxis("Horizontal");
         moveVertical = Input.GetAxis("Vertical");
        //プレイヤーが向いている向きに併せて進む
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical)*Time.deltaTime;
        //移動するためのキーが押されているか
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        //イベントの時動かない
        if (sound_Event1.Event_scene == false)
        {
            //移動スピード
            //走る
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey("joystick button 5"))
            {

                orgspeed1 = runSpeed;
            }
            //遅く歩く
            else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey("joystick button 4"))
            {
                orgspeed1 = slowwalkSpeed;
                PlayerSound = false;
            }
            //後ろ向きで移動
            else if (Input.GetKey(KeyCode.S) || moveVertical <= 0)
            {

                orgspeed1 = 2.0f;
            }
            //歩く(通常)
            else if (moveVertical >= 0)
            {
                orgspeed1 = walkSpeed;
            }
            //横向きに移動
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || moveHorizontal >= -1 || moveHorizontal <= 1 && moveHorizontal != 0)
            {
                orgspeed1 = 3.0f;
            }

            //歩く音の処理
            if (!Ishide)//(高山)
            {
                if (Input.GetKey("joystick button 5"))
                {
                    PlayerSound = true;
                    Debug.Log("ttt");
                }
                else if (moveVertical == 0 && moveHorizontal == 0 || Input.GetKey("joystick button 4"))
                {
                    PlayerSound = false;
                    Debug.Log("fff");
                }
                else
                {
                    PlayerSound = true;
                    Debug.Log("ttt");
                }
            }

            //移動する処理
            movement = transform.rotation * movement * orgspeed1;
            if (characterController.enabled == true)
            {
                characterController.Move(movement);
            }

            if (Input.GetKey(KeyCode.N))
            {
                transform.position = woldPos;
            }

            MoveCamera();   //カメラの上下左右の動き(視点)
            GetItem();      //Eを押したらアイテムを取得、投擲する処理

            onSaund();      //音の処理
            if (have_map)
            {
                LookMap();
            }
        }
        Event1();
       
    }

    //Eを押したらアイテムを取得、投擲する処理
    void GetItem()
    {
        //Eを押したら　コントローラーならB
        //マップを見ている最中は押せない様に変更(髙山)
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 1")) && count == 0)
        {
            //レイを使っての選択
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //アイテムを持っていなかったら
            if (!itembase.GetIsPlayerHaveItem())
            {
                //レイの感知する範囲
                if (Physics.Raycast(ray, out hit, 5.0f) )
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
                                //本を動かすまでclosetに入れない(髙山)
                                if (books_move)
                                {
                                    warp(hitTag);
                                }
                        }
                        break;
                        case "door":
                        {
                                //敵が消えるまで黒－ゼットから出れない(髙山)
                                if (closet_Exit)
                                {
                                    Endwarp(woldPos);
                                }
                        }
                        break;
                        //進行に必要なアイテムｚ
                        //鍵を取った際の処理(髙山)
                        case "Key":
                        {
                                GetKey(hitTag);
                        }
                        break;
                        //マップを取ったとき(髙山)
                        case "Map":
                        {
                                GetMap();
                                Pointyecu(hitTag);
                        }
                        break;
                        //脱出口に触れたとき(髙山)
                        case "Exit":
                        {
                                Exit();
                        }
                        break;
                        //本棚をどかす
                        case "bookstand":
                            {
                                if (!books_move && have_map)
                                {
                                    bookstand_move();
                                }
                        }
                        break;

                        //金庫を開ける(髙山)
                        case "cashcase":
                        {
                   　　        if (books_move　&& !kinko)
             　　               {
              　　                 kinko = true;
                                   Kinko.Open(); 
                            }
                   　   }
                        break;



                        //チェックポイント
                        case "None":
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
						case "Exit_1":
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
        //カメラの動き(コントローラー)
         mauseX = Input.GetAxisRaw("Horizontal2") * SensitivtiR * Time.deltaTime; //X
        transform.Rotate(Vector3.up *mauseX);
         mauseY = Input.GetAxisRaw("Vertical2") * SensitivtiUp * Time.deltaTime; //Y
        xRotation += mauseY;
		

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
            //音が消滅(高山)
            PlayerSound = false;
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
		
        //checkpointtagobj.GetComponent<CheckpointTag>();
       
        //もし前のミッションクリアしていたら
        if (Ishide==false)
        {
            for(int i=0; i<4; i++)
            {
				if (tag == checkpointtag.chekepointTag[i])
                {
                    
                    checkpointtag.SetfetchedCheckpointTag(checkpointtag.chekepointTag[i]);
                    Debug.Log("チェックポイント通過"+i);
                }
            }
		}
    }

    //SEを鳴らす処理(歩く、走る)
    void onSaund()
    {
        //タイマーは発動する時の時間temer秒たったら発動

        if (!Ishide)
        {
            if (moveVertical != 0 || moveHorizontal != 0)
            {
                //走る時の
                if (Input.GetKey("joystick button 5"))
                {
                    timer2 += Time.deltaTime;
                    if (timer2 > 1.2f)
                    {
                        audioSource.PlayOneShot(sound2);
                        timer2 = 0.0f;
                    }

                }
                //ゆっくり歩く時の
                else if (Input.GetKey("joystick button 4"))
                {
                    audioSource.mute = false;
                }
                //歩く時の
                else
                {
                    timer1 += Time.deltaTime;
                    if (timer1 > 1.5f)
                    {
                        audioSource.PlayOneShot(sound1);
                        timer1 = 0.0f;
                    }
                }
            }
        }

        //ドアをガチャする音
        if (Input.GetKey("joystick button 1"))
        {           
            timer3 += Time.deltaTime;
            if ((hitTag == "Day2_Start" || hitTag == "Exit") && timer3>=0.1f)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(sound3);
                }
                timer3 = 0.0f;
                hitTag = null;               
            }
        }
        
        if(checkpointtag.fetchedCheckpointTag=="Day2_Start")
        {
            Debug.Log("www");
            timer4 += Time.deltaTime;
            if( timer4 > 1.0f && ct==0)
            {
                audioSource.PlayOneShot(sound4);
                timer4 = 0.0f;
                ct = 1;
            }
        }
    }

    //マップを見る処理
    void LookMap()
    {
      Mapobj = GetComponent<RectTransform>();

        if ( Input.GetKeyDown("joystick button 0") && count != 1)
        {
            map.SetActive(!IsLook);
            count++;
            Debug.Log("M押されたよ");
            characterController.enabled = false;

        }
        else if ( Input.GetKeyDown("joystick button 0") && count == 1)
        {
            map.SetActive(IsLook);
            count = 0;
            Debug.Log("M押されたよ2");
            characterController.enabled = true;
        }
    }
    //鍵を持っているか否か(髙山)
    void GetKey(string tag)
    {
        GameObject Key = GameObject.FindGameObjectWithTag("Key");
        //鍵を持っている事を判定
        have_key = true;
        //鍵を消す
        Key.gameObject.SetActive(false);
    }
    //出口へ到達した時の処理
    void Exit()
    {
        UI uI = canvas.GetComponent<UI>();
                
        if (have_key)
        {
            Pointyecu("Exit_1");
        }
        else
        {
            if (!C)
            {
                C = true;
                targetObject.SetActive(true);
            }
            uI.DontKey();
        }
    }
    //マップをゲットした時の処理
    void GetMap()
    {
        GameObject Map = GameObject.FindGameObjectWithTag("Map");
        //マップを持つ
        have_map = true;
        //マップオブジェを消す
        Map.gameObject.SetActive(false);
    }
    //本棚を移動する処理
    void bookstand_move()
    {
        books_move = true;
    }
    
    void Event1()
    {
        if (hitTag=="Day2_Start" && ctEv == 0)
        {
            sound_Event1.Event_scene = true;
            sound_Event1.start_soene = true;
            if (new_ui.Word == 2)
            {
                TTEv += Time.deltaTime;
            }    
        }
        if (sound_Event1.Event_scene == true && sound_Event1.start_soene == true && TTEv>=2.0f)
        {
            // 補完スピードを決める
            speed = 0.1f;
            // ターゲット方向のベクトルを取得
            relativePos = targetObject.transform.position - this.transform.position;
            // 方向を、回転情報に変換
            rotation = Quaternion.LookRotation(relativePos);
            // 現在の回転情報と、ターゲット方向の回転情報を補完する
            transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, speed);
           cam.transform.Rotate(0, 0, 0);
            ctEv = 1;
        } 
    }
}

