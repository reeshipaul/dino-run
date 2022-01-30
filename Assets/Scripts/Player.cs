using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    
    [SerializeField]
    private float jumpForce = 11f;
    private float movementX;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string RUN_ANIM = "Running";
    private bool isGrounded;
    private string GROUND_TAG = "Ground";
    
     [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;


    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }
    private void FixedUpdate()
    {
        
    }
    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        if (transform.position.x < minX) 
        {
            transform.position = new Vector3(minX, 0f, 0f);
        }
        else if (transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX, 0f, 0f);
        }
        else
        {
            transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
        }
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(RUN_ANIM, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(RUN_ANIM, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(RUN_ANIM, false);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
    }
}
