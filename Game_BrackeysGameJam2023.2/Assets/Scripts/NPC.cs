using UnityEngine;

public class NPC : MonoBehaviour
{
	public float Speed;
    public Transform target;

    //public Sprite[] sprites;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Random Sprite
        //transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length - 1)];
        //Random Scale
        float scale = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector3(transform.localScale.x * scale, transform.localScale.y * scale, transform.localScale.z * scale);
    }

    void Update ()
    {
        //Move to target
        rb.MovePosition(transform.position - transform.forward * Time.deltaTime * Speed * -1);

        //Turning towards the target
        transform.LookAt(target.position);

    }
           
    void OnTriggerEnter(Collider other)
    {
        //If collision with target, rename in "Creater.cs"
        if (other.gameObject.name == gameObject.name)
        {
            RandomTargetPosition();
        }
        //If the NPC touched the borders, the target moves to a random position
        if (other.gameObject.name == "Dno" || other.gameObject.name == "Border")
        {
            RandomTargetPosition();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //If collision with target, rename in "Creater.cs"
        if (other.gameObject.name == gameObject.name)
        {
            RandomTargetPosition();
        }
        //If the NPC touched the borders, the target moves to a random position
        if (other.gameObject.name == "Dno" || other.gameObject.name == "Border")
        {
            RandomTargetPosition();
        }
    }
    public void RandomTargetPosition()
    {
        //the target moves to a random position
        target.position = new Vector3(0, Random.Range(GameObject.Find("Manager").GetComponent<border>().points[0].position.y, GameObject.Find("Manager").GetComponent<border>().points[2].position.y),
                                                                                Random.Range(GameObject.Find("Manager").GetComponent<border>().points[0].position.z, GameObject.Find("Manager").GetComponent<border>().points[1].position.z));
    }
}
