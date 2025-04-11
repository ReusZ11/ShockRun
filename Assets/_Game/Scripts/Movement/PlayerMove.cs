//make sure to add a CharacterController to the thing that you want to move
using CnControls;

using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    CharacterController characterController;

    public GameObject Joystick;
    public float speed = 5.0f;
    private bool boosting = false;
    private float boostTimer = 0f;
    private Rigidbody rb;
    private Animator anim;
    private Enemy enemy;

    public GameObject enemyPref;

    [SerializeField] private GameObject UIAttack;
    [SerializeField] private GameObject UIRestart;


    private bool isRunning;

    private Vector3 _inputs = Vector3.zero;

    private void Start()
    {
        enemy = enemyPref.GetComponent<Enemy>();

        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        anim.SetBool("Idle", true);
        isRunning = false;
        UIAttack.GetComponent<Button>().interactable = false;

    }

    void Update()
    {





        if (boosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 3)
            {
                speed = 5.0f;
                boostTimer = 0;
                boosting = false;
            }
        }
    }


    void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {

        _inputs = Vector3.zero;
        _inputs.x = CnInputManager.GetAxis("Horizontal");
        _inputs.z = CnInputManager.GetAxis("Vertical");
        if (_inputs != Vector3.zero)
            transform.forward = _inputs;
        rb.MovePosition(rb.position + _inputs * speed * Time.fixedDeltaTime);
        isRunning = true;

        if(_inputs.x == 0 && _inputs.y == 0)
        {
            anim.SetBool("Running", false);
            anim.SetBool("Idle", true);
            anim.SetBool("Attack", false);

        }

        else
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Running", true);
            anim.SetBool("Attack", false);

        }

    }


    public void PlayerDeath()
    {
        Joystick.SetActive(false);
        anim.SetBool("Die", true);
    }

    public void PlayerAttack()
    {
        anim.SetBool("Attack", true);
        anim.SetBool("Idle", false);
        anim.SetBool("Running",false);


        enemy.GetComponent<BoxCollider>().enabled = false;
        transform.LookAt(enemyPref.transform.position);
        enemy.Death();
        UIAttack.GetComponent<Button>().interactable = false;
        UIRestart.SetActive(true);

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boost")
        {
            boosting = true;
            speed = 10.0f;
            Destroy(other.gameObject);

        }



    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            PlayerAttack();
            UIAttack.GetComponent<Button>().interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {

        if (other.tag == "Enemy")
        {
            anim.SetBool("Attack", false);
            anim.SetBool("Idle", true);

        }

    }

}
