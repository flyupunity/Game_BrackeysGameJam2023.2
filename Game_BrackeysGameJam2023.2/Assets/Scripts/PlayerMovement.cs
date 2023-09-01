 using UnityEngine;
using TMPro;

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
    [Min(0)] public float maxHP = 5;
    [Min(0)] public float HP = 5;
    [Min(0)] private float scale;
    #endregion
    [Space(10)]

    [Header("Final Kat Scene Atributs")]
    [Space(5)]
    #region Final Kat Scene
    [SerializeField] private GameObject monsterAnimator;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject katSceneCamera;
    #endregion
    [Space(10)]

    [Header("Game Over Atributs")]
    [Space(5)]
    #region Game Over

    [SerializeField] private GameObject GameOverPanel;
    #endregion

    void Awake(){
        HP = maxHP;
        _rigidBody = GetComponent<Rigidbody>();
        scale = transform.localScale.x;
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

            if (Input.GetAxisRaw("Horizontal") < 0) { transform.localScale = new Vector3(scale, scale, scale); }
            else if (Input.GetAxisRaw("Horizontal") > 0) { transform.localScale = new Vector3(scale, scale, -scale); }

            Move = new Vector3(transform.position.x, verticalMove, -horizontalMove);
            _rigidBody.MovePosition(_rigidBody.position + Move * Time.deltaTime);
        }

    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.name == "Ask" || other.gameObject.tag == "Ask_?")
        {
            RandomBonus();
        }
        if (other.gameObject.name == "Trigger_3_Kat-Scene")
        {
            FinalKatScene();
        }
        if (other.gameObject.name == "Trigger_3_SwitchCamera")
        {
            SwitchCamera(mainCamera, katSceneCamera);
        }
        if (other.gameObject.tag == "Rock")
        {
            HP -= 1;
        }

    }
	void OnCollisionEnter(Collision other){
        if (other.gameObject.name == "Ask" && other.gameObject.tag != "Mem" || other.gameObject.tag == "Ask_?" && other.gameObject.tag != "Mem")
        {
            RandomBonus();

        }
        if (other.gameObject.tag == "Mem")
        {
            PlayerPrefs.SetInt("Mem", 1);
            GameObject.FindGameObjectWithTag("Manager").GetComponent<UGS_Analytics>().MemCustomEvent();

        }
        if (other.gameObject.name == "Trigger_3_Kat-Scene")
        {
            FinalKatScene();
        }
        /*if (other.gameObject.name == "Trigger_3_SwitchCamera")
        {
            SwitchCamera(mainCamera, katSceneCamera);
        }*/
        if (other.gameObject.tag == "Rock")
        {
            HP -= 1;
        }
    }

    public void FinalKatScene()
    {
        Destroy(GetComponent<Rigidbody>());
        isMove = false;
        monsterAnimator.SetActive(true);
    }
    public void SwitchCamera(GameObject offCamera, GameObject onCamer)
    {
        onCamer.SetActive(true);
        offCamera.SetActive(false);
    }
    public void GameOverAnimation()
    {
        isMove = false;
        GetComponent<Animator>().SetTrigger("Crash");
    }
    public void RandomBonus()
    {
        int r = Random.Range(0, 2);
        if(r == 0)
        {
            transform.localScale = new Vector3(transform.localScale.x / 1.01f, transform.localScale.y / 1.01f, transform.localScale.z / 1.01f);
            scale = transform.localScale.x;
        }
        if (r == 1)
        {
            walkSpeed *= 1.02f;
        }
    }
    public void GameOverPanel_()
	{
        GameOverPanel.SetActive(true);
    }
}