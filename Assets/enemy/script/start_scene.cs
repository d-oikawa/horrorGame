using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class enemy_eventscene : MonoBehaviour
{
    //sound_Evect.cs
    public Event eVent;

    public GameObject se;

    //NavMeshhAgent
    private NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.transform.position = new Vector3(27.75f, transform.position.y, 4.92f);

        se = GameObject.FindGameObjectWithTag("Event");
        eVent = se.GetComponent<Event>();

    }

    // Update is called once per frame
    void Update()
    {
        if (eVent.Event_scene && eVent.start_soene)
        {
            //agent.speed = 5.0f;

            GetComponent<NavMeshAgent>().SetDestination(new Vector3(2.97f, 10.51f, 14.4f));
        }
    }
}
