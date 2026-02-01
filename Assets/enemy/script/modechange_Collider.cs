using UnityEngine;
using UnityEngine.Animations;

public class modechange_Collider : MonoBehaviour
{
    public ParentConstraint parent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetParent(ParentConstraint p)
    {
        parent = p;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //parent.OnHit(other, this);
        }
    }

}
