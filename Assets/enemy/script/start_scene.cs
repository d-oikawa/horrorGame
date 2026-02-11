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

    Vector3 this_transform;

    public bool next_mode;

    public spline_system spline;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        next_mode = false;

        this_transform = this.transform.position;

        this_transform = new Vector3(27.75f, transform.position.y, 4.92f);

        agent = GetComponent<NavMeshAgent>();

        se = GameObject.FindGameObjectWithTag("Event");
        eVent = se.GetComponent<Event>();

        spline = GetComponent<spline_system>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eVent.Event_scene && eVent.start_soene)
        {
            spline.Event_Spline(3, "StarEvent_Spline",true);

            agent.enabled = false;

        }
    }



    //public static bool Areerror(Vector3 v1, Vector3 v2, float tolerance)
    //{
    //    // y Çñ≥éãÇµÇƒ x Ç∆ z ÇÃç∑ÇæÇØÇå©ÇÈ
    //    float dx = v1.x - v2.x;
    //    float dz = v1.z - v2.z;

    //    // (dx^2 + dz^2) <= tolerance^2 Ç»ÇÁàÍív
    //    return (dx * dx + dz * dz) <= tolerance * tolerance;
    //}

}
