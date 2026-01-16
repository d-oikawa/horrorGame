using UnityEngine;

public class Event : MonoBehaviour
{
    public ItemBase iitem;

    public GameObject itflg;

    public bool enemy_sound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy_sound = false;
        itflg = GameObject.FindWithTag("Testitem");
        iitem = itflg.GetComponent<ItemBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if(iitem.IsItemOnGround)
        {
            enemy_sound = true;
        }
    }
}
