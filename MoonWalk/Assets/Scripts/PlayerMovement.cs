using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float moveSpeed = 10f;

    [Header("Player Animation")]
    [SerializeField] private Animator anim;

    private Rigidbody2D rb2d;
    private Transform tf;
    private SpriteRenderer sr;
    private float xMove;
    private float yMove;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInput();
        FlipSpriteToWalkDirection();
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        MovePlayer();
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

    private void CheckForInput()
    {
        xMove = Input.GetAxis("Horizontal");
        yMove = rb2d.velocity.y;
    }

    private void MovePlayer()
    {
        rb2d.velocity = new Vector2((xMove * moveSpeed) *  Time.deltaTime, rb2d.velocity.y);
    }

    private void AnimatePlayer()
    {
        if (xMove != 0)
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }
}
