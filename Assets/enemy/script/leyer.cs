using UnityEngine;

public class leyer : MonoBehaviour
{

    public GameObject pl;

    public PlayerMove pm;

    [SerializeField]
    public GameObject ey;

    private int cont;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player");

        pm = pl.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {        
        if(other.tag == "enemy")
        {
            pm.closet_Exit = true;
        }
    }

}
