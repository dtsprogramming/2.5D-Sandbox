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
        MovePlayer();
        FlipSpriteToWalkDirection();
        AnimatePlayer();
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
    }

    private void MovePlayer()
    {
        tf.Translate((xMove * moveSpeed) * Time.deltaTime, 0, 0);
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
