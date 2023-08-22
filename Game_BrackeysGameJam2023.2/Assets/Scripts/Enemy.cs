using System.Collections;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public float Speed;
    public Transform target;

    bool Player = false;
    Transform PlayerT;

    void Awake(){
		Player = false;
    }

	void Update (){
        //Find player
		if(GameObject.FindGameObjectWithTag("Player") != null) PlayerT = GameObject.FindGameObjectWithTag("Player").transform;

		if(Player == true){
            //Move to player
            GetComponent<Rigidbody2D>().MovePosition(transform.position - transform.right * Time.deltaTime * Speed * -1);

            //Turning towards the target
            Vector3 rotation = PlayerT.position - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        }
		if(Player == false){
            //if the distance between the enemy and the player is <= 2 * the size of the enemy,
            //then the player becomes the target of the enemy
            if (GameObject.FindGameObjectWithTag("Player") != null && Vector2.Distance(transform.position, PlayerT.position) <= 2f * transform.localScale.y)
            {
                Player = true;
                Speed *= 20;
            }
            //Move to target
            GetComponent<Rigidbody2D>().MovePosition(transform.position - transform.right * Time.deltaTime * Speed * -1);

            //Turning towards the target
            Vector3 rotation = target.position - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        }
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //If collision with target, rename in "Creater.cs"
        if (other.gameObject.name == gameObject.name)
        {
            RandomTargetPosition();

        }
        //If the Enemy touched the borders, the target moves to a random position
        if (other.gameObject.name == "Dno" || other.gameObject.name == "Border")
        {
            RandomTargetPosition();
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        //If the Enemy touched the borders, the target moves to a random position
        if (other.gameObject.name == "Dno" || other.gameObject.name == "Border")
        {
            RandomTargetPosition();
        }
        //If collision with target, renamed in "Creater.cs"
        if (other.gameObject.name == gameObject.name)
        {
            RandomTargetPosition();
        }
    }

    private void RandomTargetPosition()
    {
        //the target moves to a random position
        target.position = new Vector2(Random.Range(-16f, 25), Random.Range(-3f, 30f));
    }
}
