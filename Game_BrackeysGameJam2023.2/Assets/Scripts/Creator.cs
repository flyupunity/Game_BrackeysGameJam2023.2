using UnityEngine;

public class Creator : MonoBehaviour
{
	public GameObject Turtle;
	public GameObject Fish;

    public float turtleScale;
    public float fishScale;

    void Start()
    {
        int num0 = Random.Range(3, 6);
        //Collider2D[] turtles = new Collider2D[num0];

        for (int i = 0; i < num0; i++)
        {
            GameObject newTurtle = Instantiate(Turtle, new Vector2(0, 0), Quaternion.identity);
            newTurtle.transform.GetChild(0).transform.position = new Vector3(0, Random.Range(GameObject.Find("Manager").GetComponent<border>().points[0].position.y, GameObject.Find("Manager").GetComponent<border>().points[2].position.y), 
                                                                                Random.Range(GameObject.Find("Manager").GetComponent<border>().points[0].position.z, GameObject.Find("Manager").GetComponent<border>().points[1].position.z));

            newTurtle.transform.GetChild(1).transform.position = new Vector3(0, Random.Range(GameObject.Find("Manager").GetComponent<border>().points[0].position.y, GameObject.Find("Manager").GetComponent<border>().points[2].position.y),
                                                                                Random.Range(GameObject.Find("Manager").GetComponent<border>().points[0].position.z, GameObject.Find("Manager").GetComponent<border>().points[1].position.z));
            newTurtle.transform.GetChild(0).name = i + "";
            newTurtle.transform.GetChild(1).name = i + "";
            newTurtle.transform.GetChild(0).transform.localScale = new Vector3(turtleScale, turtleScale, turtleScale);
            newTurtle.transform.GetChild(1).transform.localScale = new Vector3(turtleScale, turtleScale, turtleScale);
            //turtles[i] = newTurtle.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Collider2D>();
        }
        int num1 = Random.Range(20, 30);
        //Collider2D[] fishes = new Collider2D[num1];

        for (int i = 0; i < num1; i++)
        {
            GameObject newFish = Instantiate(Fish, new Vector2(0, 0), Quaternion.identity);
            newFish.transform.GetChild(0).transform.position = new Vector3(0, Random.Range(GameObject.Find("Manager").GetComponent<border>().points[0].position.y,GameObject.Find("Manager").GetComponent<border>().points[2].position.y),
                                                                                Random.Range(GameObject.Find("Manager").GetComponent<border>().points[0].position.z,GameObject.Find("Manager").GetComponent<border>().points[1].position.z));

            newFish.transform.GetChild(1).transform.position = new Vector3(0, Random.Range(GameObject.Find("Manager").GetComponent<border>().points[0].position.y, GameObject.Find("Manager").GetComponent<border>().points[2].position.y),
                                                                                Random.Range(GameObject.Find("Manager").GetComponent<border>().points[0].position.z, GameObject.Find("Manager").GetComponent<border>().points[1].position.z));
            newFish.transform.GetChild(0).name = i + "";
            newFish.transform.GetChild(1).name = i + "";
            newFish.transform.GetChild(0).transform.localScale = new Vector3(fishScale, fishScale, fishScale);
            newFish.transform.GetChild(1).transform.localScale = new Vector3(fishScale, fishScale, fishScale);
            //fishes[i] = newFish.transform.GetChild(0).gameObject.GetComponent<Collider2D>();
            /*for (int y = 0; y < num0; y++)
            {
                Physics2D.IgnoreCollision(fishes[i], turtles[y]);
            }*/
        }
    }
}
