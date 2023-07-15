using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
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

    private PlayerInput pInput;

    private float yMove;

    #endregion Variables


    #region Unity Methods

    void Start()
    {
        pInput = GetComponent<PlayerInput>();
        rb2d = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
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

    private void MovePlayer()
    {
        yMove = rb2d.velocity.y;

        float boost = dashBoost;

        if (!pInput.isDashing)
        {
            rb2d.velocity = new Vector2(pInput.xMove * moveSpeed * Time.deltaTime, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(pInput.xMove * (moveSpeed * boost) * Time.deltaTime, rb2d.velocity.y);
        }
        
    }

    private bool PlayerAttack()
    {
        return Input.GetKeyDown("mouse 0");
    }

    private void FlipSpriteToWalkDirection()
    {
        if (pInput.xMove > 0)
        {
            sr.flipX = false;
        }
        else if (pInput.xMove < 0)
        {
            sr.flipX = true;
        }
    }

    private void AnimatePlayer()
    {
        anim.SetBool("IsMoving", pInput.xMove != 0);
        anim.SetBool("IsAttacking", PlayerAttack());
        anim.SetBool("IsDashing", pInput.isDashing);
    }

    #endregion Self-defined Methods
}
