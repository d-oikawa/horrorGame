using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEmptyCSharpScript:MonoBehaviour
{
    //キャラクタコントローラーを使う為の変数
    public CharacterController characterController;

    //動く速さ変数
    public float walkSpeed;
    public float slowwalkSpeed;
    public float runSpeed;

   //視点移動変数
    public float mauseSensitivti; //マウスの感度
    public Transform cam;
    private float xRotation;

    public Camera PlayerCamera;

    void Start()
    {
      
    }

    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * Time.deltaTime;

        //歩き・走り・ゆっくり歩き
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement = transform.rotation * movement * runSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            movement = transform.rotation * movement * slowwalkSpeed;
        }
        else
        {
            movement = transform.rotation * movement * walkSpeed;
        }
        characterController.Move(movement);

        //カメラの動き
        float mauseX = Input.GetAxisRaw("Mouse X") * mauseSensitivti * Time.deltaTime; //X
        transform.Rotate(Vector3.up * mauseX);
        float mouseY = Input.GetAxisRaw("Mouse Y") * mauseSensitivti * Time.deltaTime; //Y
        xRotation -= mouseY;
        //振り向き制限
        xRotation = Mathf.Clamp(xRotation, -60.0f, 60.0f);
        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //レイを使っての選択
        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Testitem")) // タグが Testitem かどうかをチェック
            {
                Debug.Log("ゲット！！");
            }
        }

        //アイテムを投げる



    }
}
