using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private int lives = 5;
    [SerializeField] private float jumpForce = 8f;

    public static Hero Instance { get; set; }
    public const int HealtDefault = 5;
    public static int Health = HealtDefault;
    private Animator anim;
    private bool isGrounded = false;
    private int curCount = 0;
    private int prevCount = 0;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    public void GetDamage()
    {
        lives -= 1;
        Debug.Log($"Lives: {lives}");
    }
    private States State
    {
        get { return (States)anim.GetInteger("State"); }
        set { anim.SetInteger("State", (int)value); }
    }
    private void Awake()
    {
        //if (Hero.Instance == null)
        //{
        //    Hero.Instance = this;
        //}
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        State = States.idle;
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
        if (isGrounded) State = States.run;
        //Debug.Log($"State: {State}");
    }

    public void SceneLoad_2(int index)
    {
        SceneManager.LoadScene(index);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("ESCAPE");
            Application.Quit();
        }
        if (transform.position.y < -20.0f)
        {
            SceneLoad_2(1);
        }
        LogChangingColliders(curCount);
        if (Input.GetButton("Horizontal"))
            Run();
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || 
            Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            State = States.idle;
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Jump()
    {
        rb.AddForce(transform.up * 8f, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 1.0f);
        isGrounded = collider.Length > 1;
        curCount = collider.Length;
    }

    private void LogChangingColliders(int curCount)
    {
        if (prevCount != curCount)
        {
            //Debug.Log($"Quantity colliders: {curCount}");
            prevCount = curCount;
        }
    }
}

public enum States
{
    idle,
    run,
}
