using UnityEngine;

public class kinko : MonoBehaviour
{
    private Animator animator;

    //永遠にアニメーションさせない
    public bool a;

    //アニメーションさせる
    public bool open;

    public GameObject Keybject;

    public BoxCollider boxCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

        open = false;

        a = false;

        Keybject = GameObject.FindWithTag("Key");

        boxCollider = Keybject.GetComponent<BoxCollider>();

        boxCollider.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha2) && !a)
        {
            Open(); 
        }
    }

    public void Open()
    {
        Debug.Log("刺身");
        if (!a)
        {
            animator.SetBool("New Bool", true);

            boxCollider.enabled = true;

            a = true;
            Debug.Log("洋が");
        }
    }
}
