using UnityEngine;

public class testItem_drop : MonoBehaviour
{    
    public enemy_move enemy_Move;

    public player_chase player_Chase;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;

        GameObject enemy = GameObject.FindGameObjectWithTag("enemy");
        enemy_Move = enemy.GetComponent<enemy_move>();

        player_Chase = enemy.GetComponent<player_chase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Ground")
        {
            player_Chase.target = transform.position;
            enemy_Move.item_drop = true;
			Debug.Log("ゴクマジオス");
			Destroy(gameObject);
        }
    }
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Ground")
        {
        }
    }
}
