using UnityEngine;

public class move_bookstand : MonoBehaviour
{
    public GameObject ply;
    public PlayerMove pm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ply = GameObject.FindWithTag("Player");
        pm = ply.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.books_move)
        {
            this.gameObject.transform.rotation = new Quaternion(0, 90, 0, 0);
            this.gameObject.transform.position = new Vector3(-59.65f, 7.01f, 5.6f);
        }
    }
}
