using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
      private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX ;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATON = "Walk";
    private bool isGrounded = true;
    private string Ground_Tag = "Ground";
    private string Enemy_Tag = "Enemy";

    // Start is called before the first frame update
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
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
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }
    void AnimatePlayer()
    {     
       if (movementX>0)
        {
            anim.SetBool(WALK_ANIMATON, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATON, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATON, false);
        }

    }
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump")&& isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Ground_Tag))
        {
            isGrounded = true;
          
        }
           if (collision.gameObject.CompareTag(Enemy_Tag))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Enemy_Tag))
            Destroy(gameObject);
    }
}
