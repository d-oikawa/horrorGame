using UnityEngine;

public class move_bookstand : MonoBehaviour
{
    public GameObject ply;
    public PlayerMove pm;

    public Event Event;
    public GameObject ev;

    public float time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ply = GameObject.FindWithTag("Player");
        pm = ply.GetComponent<PlayerMove>();

        ev = GameObject.FindWithTag("Event");
        Event = ev.GetComponent<Event>();

        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = this.gameObject.transform.position;
        if (pm.books_move && vec.z >= 5.73f)
        {
            time += Time.deltaTime;            
            //this.gameObject.transform.rotation = new Quaternion(0, 90, 0, 0);
            vec.z -= 0.03f;
            this.transform.position = vec;
            Event.Event_scene = true; 
        }
        else
        {
            Event.Event_scene = false;
        }
    }
}
