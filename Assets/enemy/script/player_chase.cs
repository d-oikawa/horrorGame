using Unity.VisualScripting.Antlr3.Runtime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.UI.Image;

public class player_chase : MonoBehaviour
{
    enemy_move en;

    //追跡するオブジェクトの座標
    [SerializeField]
    public Vector3 target;

    //private GameObject target;

    private NavMeshAgent agent;

    //音の発生源の座標で停止し続ける時間
    [SerializeField]
    private float stop_time;

    //停止している時間
    public float stoping_time;

    //追従フラグ
    public bool chase_flg;

    public spline_system spline_system2;

    public enemy_move enemy_Move;

    public Vector3 this_transform;

	//追跡中だが停止しているflag
	//public bool chase_stop;

	//追跡するオブジェクトの座標
	//private Vector3 target_pos;

	//距離
	//Vector3 Distance;

	//vector
	//Vector3 chase_vector;　

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        //追跡するオブジェクトの座標を取得
        //target_pos =  target.transform.position;

        spline_system2 = GetComponent<spline_system>();

        enemy_Move = GetComponent<enemy_move>();

        agent = this.gameObject.GetComponent<NavMeshAgent>();

        //追跡するすぴーど
        agent.speed = 10.0f;

        stoping_time = 0f;

        this_transform = this.transform.position;

       // chase_stop = false;
    }

    // Update is called once per frame
    void Update()
    {
		//Distance = target_pos - this.transform.position;
		//chase_vector = Distance.normalized;

		this_transform = this.transform.position;

		if (chase_flg)
        {
            Debug.Log("追跡中");
            agent.enabled = true;
            agent.destination = target;
        }
        
        //スプラインに沿って移動しておらず、音源を追ってもいない場合 
        if (!spline_system2.spline_flg  && !chase_flg)
        {
            agent.destination = enemy_Move.start_pos;
            Debug.Log("元の場所に移動中");

            //var a = this_transform;
            //var b = enemy_Move.start_pos;
            
			if (Areerror(enemy_Move.start_pos, this_transform,0.001f))
            {
                Debug.Log("スプライン移動に変更");
				//スプライン上を動くflgをture
				spline_system2.spline_flg = true;
                agent.isStopped = true;
                //agent.isStopped = true;
				//agentを殺す
				//agent.enabled = false;
			}

		}

        //spline上を移動しておらず、追跡中であるとき
        else if(!spline_system2.spline_flg && chase_flg)
        {
            agent.isStopped = false;
            if( Areerror(this_transform, target, 1f))
            {
                stoping_time += 1f * Time.deltaTime;
                Debug.Log("停止中");
            }
            //chase_stop = true;
            
           
            if (stoping_time >= stop_time)
            {
                stoping_time = 0f;
                chase_flg = false;                
                //chase_stop = false;
            }
            Debug.Log(target);

        }

        /*
        if (target.transform.position == this.transform.position && chase_flg)
        {
            //chase_stop = true;
            stoping_time += 1f * Time.deltaTime;
            Debug.Log("停止中");
            if(stoping_time >= stop_time)
            {
                stoping_time = 0f;
                chase_flg = false;
                //chase_stop = false;
            }
        }
        else
        {
            stoping_time = 0f;
        }
        */

        //this.transform.position = target_pos;
    }
    /*
    private void OnTriggerStay(Collider other)
    {
        if((other.gameObject.tag == "Player" || other.gameObject.tag == "Item") && chase_flg)
        {
            //chase_stop = true;
            stoping_time += 1f * Time.deltaTime;
            Debug.Log("停止中");
            if (stoping_time >= stop_time)
            {
                stoping_time = 0f;
                chase_flg = false;
                //chase_stop = false;
            }
        }
        else
        {
            stoping_time = 0f;
        }
    }
    */
    public static bool Areerror(Vector3 v1, Vector3 v2, float tolerance)
    {
        // y を無視して x と z の差だけを見る
        float dx = v1.x - v2.x;
        float dz = v1.z - v2.z;

        // (dx^2 + dz^2) <= tolerance^2 なら一致
        return (dx * dx + dz * dz) <= tolerance * tolerance;
    }

    // ゲームオーバーシーンへ遷移する関数
    // 敵がプレイヤーと接触したときに呼び出してください おいかわ

}
