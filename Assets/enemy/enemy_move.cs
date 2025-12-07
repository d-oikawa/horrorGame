using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Splines;

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
    spline_system splineAnimate;

    //音のなる方向に
    //private bool searchw;

    //enemy_move.cs
    spline_system spline_System;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //角度を初期化
        //localAngle = this.transform.localEulerAngles;

        spline_System = GetComponent<spline_system>();

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

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!spline_System.spline_flg)
            {
                spline_System.spline_flg = true;
            }
            else
            {
                spline_System.spline_flg = false;
            }
        }

        //通常時
        if (spline_System.spline_flg)
        {
            return;
        }
        //音を聞いたら
        else
        {
            normal_move();           
        }

        /*
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("aaa");
            localAngle.y = 90.0f;
            this.transform.localEulerAngles = localAngle;
            this.transform.Translate(Vector3.right * -0.5f);
        }
        */
    }
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
                this.transform.Rotate(0f, 5f, 0f);
                Debug.Log("方向転換");
                //レイの正面を更新
                direction = transform.forward;
            }
        }
    }
}
