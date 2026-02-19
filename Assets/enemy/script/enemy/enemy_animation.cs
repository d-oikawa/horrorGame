using UnityEngine;

public class enemy_animation : MonoBehaviour
{
    //アニメーター
    private Animator anim;

    //enemy_move.cs
    private player_chase pc;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //アニメーターコンポーネントを取得
        anim = GetComponent<Animator>();
        //enemy_moveを取得
        pc = GetComponent<player_chase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pc.chase_flg)
        {
            anim.SetBool("Teke 001", true);
        }
    }
}
