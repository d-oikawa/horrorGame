using UnityEngine;
using UnityEngine.Animations;

public class modechange_Collider : MonoBehaviour
{
    public enemy_modechange parent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetParent(enemy_modechange p)
    {
        parent = p;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            parent.OnHit(other,this,true);
        }
    }
}
