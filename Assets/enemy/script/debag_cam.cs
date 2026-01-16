using Unity.VisualScripting;
using UnityEngine;

public class debag_va : MonoBehaviour
{
    public GameObject playerObj;
    private Vector3 offset;

    private Quaternion initialRot;
    

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("enemy");
        if (playerObj != null)
        {
            offset = transform.position - playerObj.transform.position;
        }
        else
        {
            return;
        }
            initialRot = transform.rotation;
    }

    void LateUpdate()
    {
        if (playerObj != null)
        {
            transform.position = playerObj.transform.position + offset;
            transform.rotation = initialRot;
        }
    }
}
