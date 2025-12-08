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
		m_IsActive = false;

		// アイテムのタグの設定 
	
	}

	// Update is called once per frame
	public virtual void Update()
	{
		GameObject.SetActive(m_IsVisible);
	}
	// アイテムの座標情報
	public Vector3 m_Position = new Vector3(0f, 0f, 0f);

	// アイテムがアクティブかどうか
	public bool m_IsActive = false;

	// アイテムを表示されているか
	public bool m_IsVisible = true;

	// プレイヤーがアイテムをとれるかどうか
	public bool IsGetItem() { return m_IsActive; }

	// アイテムがアクティブかどうかの情報を設定
	public void SetActive(bool _IsActive) { m_IsActive = _IsActive; }

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
			// 非アクティブにする
			m_IsActive = false;
		}
	}
}
