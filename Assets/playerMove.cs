using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEmptyCSharpScript:MonoBehaviour
{
    //キャラクタコントローラーを使う為の変数
    public CharacterController characterController;
    //動く速さ
    public float walkSpeed;
    public float slowwalkSpeed;
    public float runSpeed;

    //マウスの感度
    public float mauseSensitivti;
    //kamera
    public Transform cam;

    private float xRotation;


    void Start()
    {

    }

    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical)*Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement = transform.rotation*movement*runSpeed;
        }
        else if(Input.GetKey(KeyCode.LeftControl))  
        {
            movement = transform.rotation * movement * slowwalkSpeed;
        }
        else
        {
            movement = transform.rotation * movement * walkSpeed;
        }

        characterController.Move(movement);



        //カメラの動き
        //X
        float mauseX = Input.GetAxisRaw("Mouse X") * mauseSensitivti*Time.deltaTime;
        transform.Rotate(Vector3.up * mauseX);
        //Y
        float mouseY= Input.GetAxisRaw("Mouse Y") * mauseSensitivti * Time.deltaTime;
        xRotation -= mouseY;
        //振り向き制限
        xRotation = Mathf.Clamp(xRotation, -60.0f, 60.0f);
        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }
}
