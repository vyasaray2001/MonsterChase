using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveForce = 10f;
    [SerializeField] AudioSource playerdies;
    [SerializeField] AudioSource playerjumps;
    [SerializeField] AudioSource playerentry;
    [SerializeField] float jumpForce = 12f;
    private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;
    private bool isGrounded;
    private string animationName = "walk";
    float movementX;

    private void Awake()
    {
        
        rigidbody=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite=GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerKeyboardMovement();
        AnimatePlayer();
        JumpPlayer();

    }
    private void FixedUpdate()
    {
    }

    void PlayerKeyboardMovement()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f)*Time.deltaTime*moveForce;
        
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            
            sprite.flipX = false;
            animator.SetBool(animationName, true);
        }
        else if (movementX < 0)
        {
            
            sprite.flipX = true;
            animator.SetBool(animationName, true);
        }
        else
        {
           // playerruns.Stop();
            animator.SetBool(animationName, false);
        }
    }

    void JumpPlayer()
    {
        if (Input.GetButtonDown("Jump")&&isGrounded)
        {
            playerjumps.Play();
            isGrounded = false;
            rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerdies.Play();
            transform.position = new Vector3(70f,70f,0f);
            Invoke("destroy", 2);
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy")){
            Destroy(gameObject);
        }
    }

    private void Destroy()
    {
         Destroy(gameObject);
    }
}
