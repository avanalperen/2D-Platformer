using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D playerRB;
    Animator playerAnimator;

    public float moveSpeed = 1f;
    public float jumpSpeed = 1f;

    public float jumpFrequency = 1f;
    public float nextJumpTime;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayerMask;

    bool facingRight=true;
    public bool isGrounded = false;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRB= GetComponent<Rigidbody2D>();
        playerAnimator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();
        OnGroundCheck();

        if (playerRB.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }
        else if(playerRB.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }

        VerticalMove();


    }

    void FlipFace()
    {
        facingRight= !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale= tempLocalScale;
    }

    void FixedUpdate()
    {

    }

    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
        playerAnimator.SetFloat("playerSpeed",Mathf.Abs(playerRB.velocity.x));
    }

    void VerticalMove()
    {
        if(Input.GetAxis("Vertical")>0 && isGrounded && (nextJumpTime<Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }
    }

    void Jump()
    {
        playerRB.AddForce(new Vector2(0f, jumpSpeed));
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position,groundCheckRadius,groundCheckLayerMask);
        playerAnimator.SetBool("isGroundedAnim", isGrounded);
    }

}
