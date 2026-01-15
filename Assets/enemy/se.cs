using UnityEngine;


public class se : MonoBehaviour
{

    public ItemBase Itembasee;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Itembasee = GetComponent<ItemBase>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Itembasee.IsItemOnGround)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
