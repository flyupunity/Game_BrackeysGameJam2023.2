 using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Move Player")]
    [Space(5)]
    #region Move Player

    public bool isMove = true;
    public float walkSpeed = 3f;

    public float horizontalMove;
    public float verticalMove;

    public Vector3 Move;
    private Rigidbody _rigidBody;
    #endregion
    [Space(10)]

    [Header("Health")]
    [Space(5)]
    #region Health
    [Min(0)]public float maxHP = 5;
    [Min(0)] public float HP = 5;
    #endregion
    [Space(10)]

    [Header("Game Over Atributs")]
    [Space(5)]
    #region GameOver

    public GameObject GameOverPanel;
    #endregion

    void Awake(){
        HP = maxHP;
        _rigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(HP <= 0)
        { GameOverAnimation(); }
    }
    void FixedUpdate() {
        if (isMove)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;
            verticalMove = Input.GetAxisRaw("Vertical") * walkSpeed;

            if (Input.GetAxisRaw("Horizontal") < 0) { transform.localScale = new Vector3(100, 100, 100); }
            else if (Input.GetAxisRaw("Horizontal") > 0) { transform.localScale = new Vector3(100, 100, -100); }

            Move = new Vector3(transform.position.x, verticalMove, -horizontalMove);
            _rigidBody.MovePosition(_rigidBody.position + Move * Time.deltaTime);
        }

    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.GetComponent<NPC>() && Input.GetMouseButton(0))
        {
            //anim.Play("UpScale");
            //other.gameObject.SetActive(false);
        }

    }
	void OnCollisionEnter(Collision other){
        if (other.gameObject.GetComponent<NPC>() && Input.GetMouseButton(0))
        {
            //anim.Play("UpScale");
            //other.gameObject.SetActive(false);
            //Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Rock")
        {
            HP -= 1;
        }
    }
    public void Win()
    {
        SceneManager.LoadScene("Win");
    }
    public void GameOverAnimation()
    {
        isMove = false;
        GetComponent<Animator>().SetTrigger("Crash");
    }
    public void GameOverPanel_()
	{
        GameOverPanel.SetActive(true);
    }
}