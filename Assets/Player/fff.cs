using UnityEngine;

public class fff : MonoBehaviour
{
	public GameObject dotPrefab; // 先ほど作ったSphereのプレハブ
	private GameObject _dotInstance;
	public GameObject obj;
	public Event eee;

	public Camera Camera;

	void Start()
	{
		
		_dotInstance = Instantiate(dotPrefab);
	}

	void Update()
	{
		Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 5.0f))
		{
			if (eee.Event_scene==false)
			{
				_dotInstance.SetActive(true);
				_dotInstance.transform.position = hit.point; // 点を衝突地点へ移動
			}
		}
		else
		{
			_dotInstance.SetActive(false); // 当たっていなければ非表示
		}
	}
}
