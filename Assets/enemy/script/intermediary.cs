using UnityEngine;

public class intermediary : MonoBehaviour
{
    //PlayerMove.CS
    private PlayerMove Player_Move;
    private GameObject PM;

    //enemy_move.cs
    [SerializeField]
    private enemy_move enemy_Move;
    //private GameObject em;

    //ItemBase.cs
    private ItemBase Item_Base;
    private GameObject ib;

    //Event.cs
    private Event Event;
    private GameObject ev;


    //プレイヤーの音が鳴っているかどうか
    public bool player_sound;

    //アイテムの音が鳴っているかどうか
    public bool Item_sound;

    //プレイヤーのポジション
    public Vector3 player_position;

    //アイテムのポジション
    public Vector3 Item_position;

    //プレイヤーが隠れているかどうか
    public bool player_hide;

    //イベントシーンかどうか
    public bool isevent_Scene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //別オブジェクトの変数や関数を使うために
        {
            PM = GameObject.FindWithTag("Player");
            Player_Move = PM.GetComponent<PlayerMove>();

            //em = GameObject.FindWithTag("enemy");
            enemy_Move = GetComponent<enemy_move>();

            ib = GameObject.FindWithTag("Testitem");
            Item_Base = ib.GetComponent<ItemBase>();

            ev = GameObject.FindWithTag("Event");
            Event = ev.GetComponent<Event>();
        }



        //player関連
        {
            //playerの音のフラグを初期化
            player_sound = false;

            //プレイヤーの位置の代入を初期化
            player_position = Vector3.zero;

            //playerが隠れているフラグを初期化
            player_hide = false;
        }


        //アイテム関連
        {
            //アイテムの音のflagを初期化
            Item_sound = false;

            //アイテムが落ちた位置の代入の初期化
            Item_position = Vector3.zero;
        }

        //イベントScene関連
        {
            //イベントシーンであるかどうかの初期化
            isevent_Scene = false;
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの仲介
        player_interm();

        //アイテムの仲介
        Item_interm();

        //イベントシーンの仲介
        Event_interm();
    }

    //プレイヤーの仲介
    private void player_interm()
    {
        //プレイヤーがいたら
        if (PM != null)
        {
            Debug.Log("プレイヤーが存在");

            //プレイヤーから音を鳴らしたかどうか受け取る
            player_sound = Player_Move.IsPlayerSound();

            //プレイヤーのポジションを受け取る
            player_position = PM.gameObject.transform.position;

            //プレイヤーが隠れているかどうか受け取る
            player_hide = Player_Move.Ishide;
        }
        //いなかったら
        else
        {
            //全部false
            player_sound = false;

            player_position = Vector3.zero;

            player_hide = false;
        }
    }

    //アイテムの仲介
    private void Item_interm()
    {
        //アイテムがあったら
        if (ib != null)
        {
            Debug.Log("アイテムが存在");

            //アイテムが音を鳴らしているか受け取る
            Item_sound = Item_Base.IsItemOnGround;

            //アイテムがおちた位置を受け取る
            Item_position = Item_Base.gameObject.transform.position;
        }
        else
        {
            Debug.Log("アイテムがないよ");

            //全部false
            Item_sound = false;

            Item_position = Vector3.zero;
        }
    }

    //イベントへの仲介
    private void Event_interm()
    {
        //イベントシーン管理のオブジェクトが存在していたら
        if (ev != null)
        {
            Debug.Log("イベントシーンに遷移可能");
            isevent_Scene = Event.Event_scene;
        }
        else
        {
            Debug.Log("イベントシーンに遷移不可能");
            isevent_Scene = false;
        }

        }

    }
