using UnityEngine;

public class Event : MonoBehaviour
{
    public ItemBase iitem;

    public GameObject itflg;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itflg = GameObject.FindWithTag("Testitem");
        iitem = GetComponent<ItemBase>();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
