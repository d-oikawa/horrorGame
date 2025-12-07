using UnityEngine;

public class debag_va : MonoBehaviour
{
    public GameObject playerObj;
    private Vector3 offset;

    private Quaternion initialRot;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("enemy");
        offset = transform.position - playerObj.transform.position;

        initialRot = transform.rotation;
    }

    void LateUpdate()
    {
        transform.position = playerObj.transform.position + offset;
        transform.rotation = initialRot;
    }
}
