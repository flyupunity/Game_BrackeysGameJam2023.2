 using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour 
{
	public float walkSpeed = 30f;

	public float horizontalMove;
	public float verticalMove;

	public Vector3 Move; 
	private Rigidbody _rigidBody; 

    #region GameOver
    public GameObject GameOverPanel;
    #endregion

    void Awake(){
		_rigidBody = GetComponent<Rigidbody>();
    }
    void Update() {

        horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * walkSpeed;

        if (Input.GetAxisRaw("Horizontal") < 0) { transform.localScale = new Vector3(100, 100, 100); }
        else if (Input.GetAxisRaw("Horizontal") > 0) { transform.localScale = new Vector3(100, 100, -100); }

        Move = new Vector3(transform.position.x, verticalMove, -horizontalMove);
        _rigidBody.MovePosition(_rigidBody.position + Move * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other){
		if (other.GetComponent<Enemy>()){
			GameOver();
        }
        if (other.gameObject.GetComponent<NPC>() && Input.GetMouseButton(0))
        {
            //anim.Play("UpScale");
            other.gameObject.SetActive(false);
        }

    }
	void OnCollisionEnter(Collision other){
		if (other.gameObject.GetComponent<Enemy>()){
			GameOver();
        }
        if (other.gameObject.GetComponent<NPC>() && Input.GetMouseButton(0))
        {
            //anim.Play("UpScale");
            //other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }
    public void Win()
    {
        SceneManager.LoadScene("Win");
    }
    public void GameOver()
	{
        GameOverPanel.SetActive(true);
    }
}