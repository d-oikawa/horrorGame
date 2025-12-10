using NUnit.Framework.Constraints;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // 表示等をするためにGameObjectをSeriaLizeField
    [SerializeField] GameObject GameObject;
    [SerializeField] Renderer ItemRenderer;

    // Rigidbody
    Rigidbody ItemRb;

    //初期化処理
    public virtual void Start()
    {
        // アイテムの初期位置の設定
        // アイテムの表示の設定
        m_IsVisible = true;

        // アイテムがアクティブかの設定
        m_IsActive = true;

    }

    // Update is called once per frame
    public virtual void Update()
    {
        // アイテムのアクティブ情報を更新
        GameObject.SetActive(m_IsActive);

        // プレイヤーがアイテムを持っている間プレイヤーの位置にアイテムを追従させる
        if (IsPlayerHaveItem)
        {
            // 視点の前方にアイテムを投げたいためプレイヤーカメラの位置を取得
            GameObject player = GameObject.FindWithTag("PlayerCamera");
            m_Position = player.transform.position;
            if (player != null)
            {
                // アイテムの位置をプレイヤーの位置に設定
                transform.position = m_Position + transform.forward * 2f;

                //回転も追従させる
                transform.rotation = player.transform.rotation;

                IsItemOnGround = false;
            }
        }

        // プレイヤーがアイテムを投擲したらRigidbodyの力を加える
        if (IsPlayerThrowItem)
        {
            // Rigidbodyを取得w
            ItemRb = GetComponent<Rigidbody>();
            if (ItemRb != null)
            {
                // 力を加える
                ItemRb.AddForce(transform.forward * 1000f, ForceMode.Acceleration);
                // 投擲したフラグをfalseにする
                IsPlayerThrowItem = false;
            }
        }

        // アイテムが地面に落ちているかどうか
    }
    // アイテムの座標情報
    public Vector3 m_Position = new Vector3(0f, 0f, 0f);

    // アイテムがアクティブかどうか
    public bool m_IsActive = true;

    // アイテムを表示されているか
    public bool m_IsVisible = true;

    // プレイヤーがアイテムをとれるかどうか
    public bool IsGetItem() { return m_IsActive; }

    // アイテムが地面に落ちているかどうか
    public bool IsItemOnGround = false;

    // プレイヤーがアイテムを持っているか
    public bool IsPlayerHaveItem = false;

    // プレイヤーがアイテムを投擲したか
    public bool IsPlayerThrowItem = false;

    // アイテムの位置をプレイヤーの位置に設定
    public void SetItemPosition(Vector3 _Position) { m_Position = _Position; }

    // アイテムがアクティブかどうかの情報を設定
    public void SetActive(bool _IsActive) { m_IsActive = _IsActive; }

    // アイテムが地面に落ちたかを取得
    public bool GetIsItemOnGround() { return IsItemOnGround; }

    // アイテムが地面に落ちたかを設定
    // 敵が取得しTrueであればfalseにする
    public void SetIsItemOnGround(bool _IsItemOnGround) { IsItemOnGround = _IsItemOnGround; }

    // プレイヤーがアイテムを持っているかを設定
    public void SetPlayerHaveItem(bool _IsPlayerHaveItem) { IsPlayerHaveItem = _IsPlayerHaveItem; }

    // プレイヤーがアイテムを持っているかを取得
    public bool GetIsPlayerHaveItem() { return IsPlayerHaveItem; }

    // プレイヤーがアイテムをとった時の処理
    public virtual void GetItem()
    {
        // アイテムがアクティブであれば処理
        if (m_IsActive)
        {
            // アイテムを取得した時のサウンドを鳴らす
            // まだない 12/3

            // アイテムを非表示
            m_IsVisible = false;

            // IshaveItemをtrueにする
            IsPlayerHaveItem = true;

            // アイテムが地面に落ちていないことを設定
            IsItemOnGround = false;
        }
    }

    // プレイヤーがアイテムを投擲したときの処理
    public virtual void ThrowItem()
    {
        // アイテムを投擲した時のサウンドを鳴らす
        // まだない 12/3
        // アイテムを表示
        m_IsVisible = true;

        // プレイヤーがアイテムを持っていないことを設定
        IsPlayerHaveItem = false;

        IsPlayerThrowItem = true;

    }

    // ゲームオブジェクト同士が接触したタイミングで実行
    void OnCollisionEnter(Collision collision)
    {
        IsItemOnGround = true;
    }
}
