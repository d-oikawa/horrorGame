using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.UI.Image;

public class player_chase : MonoBehaviour
{
    enemy_move en;

    //追跡するオブジェクト
    [SerializeField]
    private GameObject target;

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

		if (chase_flg /*= !chase_stop*/)
        {
            Debug.Log("追跡中");
            agent.enabled = true;
            agent.destination = target.transform.position;
        }
        else
        {
            //agent.enabled = false;
        }
                //スプラインに沿って移動しておらず、音源を追ってもいない場合 
        if (!spline_system2.spline_flg  && !chase_flg)
        {
            agent.destination = enemy_Move.start_pos;
            Debug.Log("元の場所に移動中");
            //もとの位置に移動

            //float multiplier =Mathf.Pow(10f,2);

            //元の位置と現在地の小数点2まで一致したら
            /*
            if ((this_transform = new Vector3(Mathf.Floor(this_transform.x * multiplier) / multiplier,
                                               Mathf.Floor(this_transform.y * multiplier) / multiplier,
                                                    Mathf.Floor(this_transform.z * multiplier) / multiplier))
              ==
              (enemy_Move.start_pos = new Vector3(Mathf.Floor(enemy_Move.start_pos.x * multiplier) / multiplier,
                                               Mathf.Floor(enemy_Move.start_pos.y * multiplier) / multiplier,
                                                    Mathf.Floor(enemy_Move.start_pos.z * multiplier) / multiplier))
                                                    )*/

            //var a = this_transform;
            //var b = enemy_Move.start_pos;
            
			if (Areerror(this_transform,enemy_Move.start_pos,0.1f))
            {
                Debug.Log("スプライン移動に変更");
                //スプライン上を動くflagをture
                spline_system2.spline_flg = true;
                //agentを殺す
                //agent.enabled = false;
            }
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
	public static bool Areerror(Vector3 v1, Vector3 v2, float tolerance)
	{
		// 距離の二乗が許容誤差の二乗以下であれば一致とみなす
		return Vector3.SqrMagnitude(v1 - v2) <= tolerance * tolerance;
	}

    // ゲームオーバーシーンへ遷移する関数
    // 敵がプレイヤーと接触したときに呼び出してください おいかわ
    public void TransitionGameOverScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }
}
