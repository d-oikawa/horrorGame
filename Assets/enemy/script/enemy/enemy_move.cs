using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

public class enemy_move : MonoBehaviour
{
    //intermediary.cs
    private intermediary inter;
    private GameObject id;

    //プレイヤーの音がなったの感知した時のフラグ
    private bool player_sound;

    //アイテムの音が鳴ったのを感知したときのフラグ
    private bool item_sound;

    //サブジェクト「sound_Event」から信号を受け取る
    //[SerializeField]
    //private Event Sound_Event;

    //移動する速度
    [SerializeField]
    public float speed;

    //現在の角度
    [SerializeField]
    private Vector3 localAngle;

    //レイ開始位置
    private Vector3 origin;

    //レイの向き
    private Vector3 direction;

    //レイの長さ
    [SerializeField]
    public float rayDistance;

    [SerializeField]
    public spline_system splineAnimate;

    //音のなる方向に
    private bool searchw;

    //enemy_move.cs
    public spline_system spline_System;

    //player_chase.cs
    public player_chase player_Chase;

    //音源へに移動する際の最初の座標
    [SerializeField]
    public Vector3 start_pos;

    //PlayerMove.cs
    //public PlayerMove PlayerMove;

    //プレイヤーを発見した瞬間好きだと気付いた
    public bool The_moment_our_eyes_meet;

    //ItemBase.cs
    //public ItemBase ItemBase;

    public GameObject pl;

    //public GameObject itm;

    ////sound_Evect.cs
    public Event eVent;

    public GameObject se;

    //つうじょう時鳴らす音
    [SerializeField]
    public AudioClip sound1;

    //追跡時鳴らす音
    [SerializeField]
    public AudioClip sound2;


    public AudioSource AudioSource;

    private Renderer[] rnd;

    //プレイヤーとエネミーの距離を測る
    public float distance;

    private Vector3 v;

    //playerが隠れているか
    public bool player_ishade; 

    //testItem_drop.cs(デバッグ)
    //public testItem_drop testItem_Drop;

    //アイテムが落ちた時のフラグ
    //public bool item_drop;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        id = GameObject.FindWithTag("intermediary");
        inter = id.GetComponent<intermediary>();

        v = Vector3.zero;
         
        //角度を初期化
        //localAngle = this.transform.localEulerAngles;

        spline_System = GetComponent<spline_system>();

        player_Chase = GetComponent<player_chase>();

        //pl = GameObject.FindGameObjectWithTag("Player");
        //PlayerMove = pl.GetComponent<PlayerMove>();

        //itm = GameObject.FindGameObjectWithTag("Testitem");
        //if (itm != null)
        //{
        //    ItemBase = itm.GetComponent<ItemBase>();
        //}

        //GameObject tesit = GameObject.FindGameObjectWithTag("Testitem");
        //testItem_Drop = tesit.GetComponent<testItem_drop>();

        //player_Chase.chase_flg = false;

        //フラグ初期化
        //searchw = false;

        The_moment_our_eyes_meet = false;

        //item_drop = false;

        se = GameObject.FindGameObjectWithTag("Event");
        eVent = se.GetComponent<Event>();

        //if (Sound_Event != null)
        //{
        //    Sound_Event.TheSound += test;
        //}

        AudioSource = GetComponent<AudioSource>();

        rnd = GetComponentsInChildren<Renderer>();
        foreach (var r in rnd)
        {
            r.enabled = false;
        }

        distance = 20;

        player_ishade = false;

        player_sound = false;

        item_sound = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!eVent.Event_scene)
        {
            //interからプレイヤーの音が鳴ったかどうかを受け取る
            player_sound = inter.player_sound;

            //interからアイテムの音が鳴ったかどうかを受け取る
            item_sound = inter.Item_sound;

            //playerが隠れているかどうか受け取る
            player_ishade = inter.player_hide;

            /*
            //デバッグFキー入力
            if (Input.GetKeyDown(KeyCode.F))
            {
                //スプライン上を移動していないとき
                if (!spline_System.spline_flg)
                {               
                    //spline上を移動するよう
                    spline_System.spline_flg = true;
                    //追跡をやめる
                    player_Chase.chase_flg = false;
                }
                //移動しているとき
                else
                {
                    player_Chase.target = new Vector3(-1f,4f,0.5f); 
                    //移動前のポジションを保存
                    start_pos = transform.position;
                    //スプライン上の移動をやめる
                    spline_System.spline_flg = false;
                    //追跡を開始
                    player_Chase.chase_flg = true;
                }
                Debug.Log(player_Chase.chase_flg);
            }

            /*
            //スプラインに沿って移動しておらず、音源を追ってもいない場合 
            if(!spline_System.spline_flg && !player_Chase.chase_flg)
            {
                Debug.Log("元の場所に移動中");
                //もとの位置に移動
                this.transform.position = Vector3.MoveTowards(transform.position, start_pos, speed * Time.deltaTime);
                if(this.transform.position == start_pos)
                {
                    spline_System.spline_flg = true;
                }
            }
            */


            /*
            if (spline_System.spline_nextmove)
            {
                nextSplineMove();
            }
            */

            ////通常時
            //if (spline_System.spline_flg)
            //{
            //    //return;
            //}
            ////音を聞いたら
            //else
            //{
            //    //normal_move();
            //}

            //通常移動時音を鳴らす
            if (!player_Chase.chase_flg && !AudioSource.isPlaying && v != this.transform.position)
            {
                AudioSource.PlayOneShot(sound1);
                v = this.transform.position;
            }

            //追跡時音を鳴らす
            if (!player_Chase.stop && player_Chase.chase_flg && !AudioSource.isPlaying)
            {
                AudioSource.PlayOneShot(sound2);
            }
            //Debug.Log(eVent.enemy_sound);


        }
        //else
        //{
        //    if (spline_System.tim < spline_System.stopd_time && spline_System.splines_Percentage < 1)
        //    {
        //        AudioSource.PlayOneShot(sound1);
        //    }

        //    if (tim > stopd_time)
        //    {

        //    }
        //}
        //distance_visible();
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (!eVent.Event_scene)
        {
            if ((collider.tag == "Player" || collider.tag == "Testitem"))
            {
                The_moment_our_eyes_meet = true;

                Debug.Log("目と目が合う");
            }
            /*
            if (collider.tag == "Testitem" || collider.tag == "Player")
            {
                if (PlayerMove.IsPlayerSound())
                {
                    Debug.Log(spline_System.spline_flg);

                    if (spline_System.spline_flg)
                    {
                        //移動前のポジションを保存
                        start_pos = transform.position;
                    }
                }
            }
            */
        }
    }

    //プレイヤーもしくはアイテムが出す音を感知したらその音をターゲットにする
    public void OnTriggerStay(Collider collider)
    {
        if (!eVent.Event_scene)
        {
            chase(collider);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!eVent.Event_scene)
        {
            if (collision.gameObject.tag == "Player")
            {
                TransitionGameOverScene();
                Debug.Log("死亡");
            }
        }
    }

    /*
    void normal_move()
    {
        //エネミーの移動
        this.transform.Translate(Vector3.forward * Time.deltaTime * speed);


        //レイがコリジョンに当たったとき
        if (Physics.Raycast(origin, direction, out RaycastHit hit, rayDistance))
        {
            //レイが壁のコリジョンに当たったとき
            if (hit.collider.CompareTag("Wall"))
            {
                //Vector3 angle = transform.localEulerAngles;
                //回転
                this.transform.Rotate(0f, 10f, 0f);
                Debug.Log("方向転換");
                //レイの正面を更新
                direction = transform.forward;
            }
        }
    }

    void nextSplineMove()
    {
        //現在の座標を保存
        start_move = this.transform.position;
    }
    */

    public void TransitionGameOverScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

    private void test()
    {
        //Debug.Log("もずく");
    }

    private void OnTriggerExit(Collider other)
    {
        if (!eVent.Event_scene)
        {
            if (other.gameObject.tag == "Testitem")
            {
                foreach (var r in rnd)
                {
                    r.enabled = false;
                }
            }
        }
    }

    ////敵とプレイヤーの距離が一定以下なら姿が見える
    //private void distance_visible()
    //{
    //    float Distances;
    //    Distances = Vector3.Distance(this.transform.position,pl.transform.position);
    //    if(Distances <= distance)
    //    {
    //        foreach (var r in rnd)
    //        {
    //            r.enabled = true;
    //        }
    //    }
    //    else
    //    {
    //        foreach (var r in rnd)
    //        {
    //            r.enabled = false;
    //        }
    //    }
    //}

    public void chase(Collider collid)
    {
      
        //感知範囲内のオブジェクトを判別
        if (collid.tag == "Player")
        {
            //プレイヤー、もしくは落としたアイテムの音を検知したら
            if (inter.player_sound)
            {
                //playerを追っていないなら
                if (!player_Chase.chase_flg)
                {
                    //移動前のポジションを保存
                    start_pos = transform.position;
                    //The_moment_our_eyes_meet = false;
                }
                //追跡する音源の座標を代入
                player_Chase.target = inter.player_position;

                //追跡を開始
                player_Chase.chase_flg = true;
                //スプライン上の移動をやめる
                spline_System.spline_flg = false;

                Debug.Log("追跡" + player_Chase.chase_flg);
            }
        }
        if (collid.tag == "Testitem")
        {
            if (The_moment_our_eyes_meet && inter.Item_sound)
            {
                Debug.Log("アイテム");

                if (!player_Chase.chase_flg)
                {
                    //移動前のポジションを保存
                    start_pos = transform.position;
                    //The_moment_our_eyes_meet = false;
                }

                if (collid != null)
                {
                    player_Chase.target = collid.transform.position;
                    //collider.gameObject.SetActive(false);
                }

                //追跡を開始
                player_Chase.chase_flg = true;

                //スプライン上の移動をやめる
                spline_System.spline_flg = false;
                //
                Debug.Log("追跡" + player_Chase.chase_flg);
                foreach (var r in rnd)
                {
                    r.enabled = true;
                }
            }
        }
    }
}


