using NUnit.Framework.Constraints;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created

	// 表示等をするためにGameObjectをSeriaLizeField
	[SerializeField] GameObject GameObject;
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
		GameObject.SetActive(m_IsVisible);

		// アイテムが地面に落ちているかどうか
	}
	// アイテムの座標情報
	public Vector3 m_Position = new Vector3(0f, 0f, 0f);

	// アイテムがアクティブかどうか
	public bool m_IsActive = false;

	// アイテムを表示されているか
	public bool m_IsVisible = true;

	// プレイヤーがアイテムをとれるかどうか
	public bool IsGetItem() { return m_IsActive; }

	// アイテムが地面に落ちているかどうか
	public bool IsItemOnGround = false;

	// プレイヤーがアイテムを持っているか
	public bool IsPlayerHaveItem = false;

    // アイテムがアクティブかどうかの情報を設定
    public void SetActive(bool _IsActive) { m_IsActive = _IsActive; }

	// アイテムが地面に落ちたかを取得
	public bool GetIsItemOnGround() { return IsItemOnGround; }

    // アイテムが地面に落ちたかを設定
	// 敵が取得しTrueであればfalseにする
	public void SetIsItemOnGround(bool _IsItemOnGround) { IsItemOnGround = _IsItemOnGround; }

    // プレイヤーがアイテムを持っているかを設定
    public void SetPlayerHaveItem(bool _IsPlayerHaveItem) { IsPlayerHaveItem = _IsPlayerHaveItem; }

    // プレイヤーがアイテムをとった時の処理
    public virtual void GetItem()
	{
		// アイテムがアクティブであれば処理
		if(m_IsActive)
		{
			// アイテムを取得した時のサウンドを鳴らす
			// まだない 12/3

			// アイテムを非表示
			m_IsVisible = false;

			Debug.Log("hange");
			// 非アクティブにする
			m_IsActive = false;

            // アイテムが地面に落ちていないことを設定
			IsItemOnGround = false;
        }
    }

	// プレイヤーがアイテムを投擲したときの処理
	public virtual void ThrowItem(Vector3 _Position)
	{
		// アイテムを投擲した時のサウンドを鳴らす
		// まだない 12/3
		// アイテムの位置を設定
		m_Position = _Position;
		// アイテムを表示
		m_IsVisible = true;
		// アイテムをアクティブにする
		m_IsActive = true;
    }
}
