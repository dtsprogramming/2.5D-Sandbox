using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    [Header("Player Movement")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float dashBoost = 200f;

    [Header("Player Animation")]
    [SerializeField] private Animator anim;

    private Rigidbody2D rb2d;
    private Transform tf;
    private SpriteRenderer sr;

    private float xMove;
    private float yMove;
    private bool isDashing;

    #endregion Variables


    #region Unity Methods

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput();
        PlayerAttack();
        FlipSpriteToWalkDirection();
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    #endregion Unity Methods


    #region Self-defined Methods


    private bool MoveInput()
    {
        xMove = Input.GetAxis("Horizontal");
        yMove = rb2d.velocity.y;
        isDashing = Input.GetKeyDown(KeyCode.LeftShift);

        return xMove != 0;
    }

    private void MovePlayer()
    {
        float boost = dashBoost;

        if (!isDashing)
        {
            rb2d.velocity = new Vector2((xMove * moveSpeed) * Time.deltaTime, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2((xMove * (moveSpeed * boost)) * Time.deltaTime, rb2d.velocity.y);
        }
        
    }

    private bool PlayerAttack()
    {
        return Input.GetKeyDown("mouse 0");
    }

    private void FlipSpriteToWalkDirection()
    {
        if (xMove > 0)
        {
            sr.flipX = false;
        }
        else if (xMove < 0)
        {
            sr.flipX = true;
        }
    }

    private void AnimatePlayer()
    {
        anim.SetBool("IsMoving", MoveInput());
        anim.SetBool("IsAttacking", PlayerAttack());
        anim.SetBool("IsDashing", isDashing);
    }

    #endregion Self-defined Methods
}
