using UnityEngine;

public class enemy_move : MonoBehaviour
{
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
    //private bool searchw;

    //enemy_move.cs
    public spline_system spline_System;

    //player_chase.cs
    public player_chase player_Chase;

    //音源へに移動する際の最初の座標
    [SerializeField]
    public Vector3 start_pos;

    public PlayerMove PlayerMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //角度を初期化
        //localAngle = this.transform.localEulerAngles;

        spline_System = GetComponent<spline_system>();

        player_Chase = GetComponent<player_chase>();

        GameObject pl = GameObject.FindGameObjectWithTag("Player");
		PlayerMove = pl.GetComponent<PlayerMove>();

        player_Chase.chase_flg = false;

        //フラグ初期化
        //searchw = false;
    }

    // Update is called once per frame
    void Update()
    {

        //エネミーの中心位置からレイを飛ばす
        origin = transform.position;

        //レイの向きをエネミーが向いている向きに
        direction = transform.forward;


        //レイを描画(デバッグ)
        Debug.DrawRay(origin, direction * rayDistance, Color.red);

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
                player_Chase.target = PlayerMove.transform.position; 
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

        //通常時
        if (spline_System.spline_flg)
        {
            return;
        }
        //音を聞いたら
        else
        {
            //normal_move();           
        }       
    }

    
	public void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Testitem" || collider.tag == "Player")
        {
            if (PlayerMove.IsPlayerSound())
            {
                /*
				//スプライン上を移動していないとき
				if (!spline_System.spline_flg)
				{
					//spline上を移動するよう
					spline_System.spline_flg = true;
					//追跡をやめる
					player_Chase.chase_flg = false;
				}
                */
				//移動しているとき
				//else
				//{
                    //音源の位置保存
                    player_Chase.target = collider.transform.position;
					//移動前のポジションを保存
					start_pos = transform.position;
					//スプライン上の移動をやめる
					spline_System.spline_flg = false;
					//追跡を開始
					player_Chase.chase_flg = true;
				//}
				Debug.Log(player_Chase.chase_flg);
			}
        }        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            TransitionGameOverScene();
            Debug.Log("死亡");
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
}
