using UnityEngine;
using UnityEngine.UI;

public class senter : MonoBehaviour
{
    public Camera cam;
    public GameObject ImHand;

    private void Start()
    {
        ImHand.SetActive(false);
    }

    void Update()
    {
        //レイを使っての選択
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        // レイの情報を格納する変数
        RaycastHit hit;

        // レイを飛ばす（最大距離100）
        if (Physics.Raycast(ray, out hit, 5.0f))
        {

            if(hit.collider.name=="coco" || hit.collider.name == "Plane (13)" || hit.collider.name == "花瓶" || hit.collider.name == "cashcase"
               || hit.collider.name == "古い鍵" || hit.collider.name == "pCube3" || hit.collider.name == "warp" || hit.collider.name == "bookstand_books(1)"
               || hit.collider.name == "door") 
            {
                ImHand.SetActive(true);
            }
           
            // 当たったオブジェクトの情報を取得
            Debug.Log("当たったオブジェクト: " + hit.collider.name);
            Debug.Log("当たった位置: " + hit.point);
            Debug.Log("当たった距離: " + hit.distance);
        }
        else
        {
            ImHand.SetActive(false);
        }
    }
}
