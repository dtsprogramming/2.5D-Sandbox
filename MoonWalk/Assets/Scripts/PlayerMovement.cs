using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

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
        xMove = Input.GetAxis("Horizontal") * Time.deltaTime;
    }

    private void MovePlayer()
    {
        tf.Translate(xMove * moveSpeed, 0, 0);
    }
}
