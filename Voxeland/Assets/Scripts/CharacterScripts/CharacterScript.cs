using UnityEngine;


public class CharacterScript : MonoBehaviour
{
    public float velocity;
    public float turnSpeed;

    public float angle;

    public Quaternion targetRotation;
    public Transform cam;

    public Animator anim;

    public bool isJumping;
    public bool isTalking;
    public bool isAttacking;

    public float damageTime;
    public float time2Damage;

    public int maxHp;
    public int hp;

    HPBar hpBar;

    PauseMenu pause;

    Rigidbody body;


    public void Start()
    {
        velocity = 10;
        turnSpeed = 10;
        cam = Camera.main.transform;
        body = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        pause = FindObjectOfType<PauseMenu>();
        hpBar = FindObjectOfType<HPBar>();
        hp = maxHp;
        isJumping = false;
        isTalking = false;
    }

    private void Update()
    {

        if (isTalking)
            return;
        if (pause.isPaused)
            return;
        if (isAttacking)
            return;

        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            anim.SetBool("IsJumping", true);
            anim.SetTrigger("Jump");
            isJumping = true;
        }

        if(Input.GetButton("Fire1"))
        {
            anim.SetTrigger("Attack");
            isAttacking = true;
            return;
        }

        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");

        angle = Mathf.Rad2Deg * Mathf.Atan2(xMove, yMove);
        angle += cam.eulerAngles.y;

        if (Mathf.Abs(xMove) < 1 && Mathf.Abs(yMove) < 1)
        {
            anim.SetBool("isWalking", false);
            return;
        };

        targetRotation = Quaternion.Euler(0, angle, 0);

        body.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        body.MovePosition(transform.position + transform.forward * Time.deltaTime * velocity);
        anim.SetBool("isWalking", true);
    }

    void ReceiveDamage(int ammount)
    {
        this.hp -= ammount;
        hpBar.UpdateValues(hp, maxHp);
    }

}