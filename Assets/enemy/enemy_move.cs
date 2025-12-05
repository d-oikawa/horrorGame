using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
    [SerializeField]
    public float speed;

    [SerializeField]
    private Vector3 localAngle;

    private Vector3 origin;

    private Vector3 direction;

    [SerializeField]
    public float rayDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        localAngle = this.transform.localEulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
        //ƒŒƒC‚ð”ò‚Î‚·ˆÊ’u
        origin = transform.position;


        direction = transform.forward;


        this.transform.Translate(Vector3.forward * Time.deltaTime * speed);

        Debug.DrawRay(origin, direction * rayDistance, Color.red);

        if (Physics.Raycast(origin, direction, out RaycastHit hit, rayDistance))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                //Vector3 angle = transform.localEulerAngles;
                localAngle.y += 5.0f;
                this.transform.localEulerAngles = localAngle;
                Debug.Log("aaa");
                direction = transform.forward;
            }
        }
    }
    
    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("aaa");
        localAngle.y = 90.0f;
        this.transform.localEulerAngles = localAngle;
        this.transform.Translate(Vector3.right * -0.5f);
    }
    */
}
