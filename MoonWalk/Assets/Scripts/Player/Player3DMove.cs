using UnityEngine;

[RequireComponent (typeof(PlayerInput))]
public class Player3DMove : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float dashBoost = 200f;

    private Rigidbody rb;
    private Transform tf;
    private SpriteRenderer sr;

    private float yMove = 0;

    private PlayerInput _input;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        tf = GetComponent<Transform> ();
        sr = GetComponent<SpriteRenderer> ();
        _input = GetComponent<PlayerInput> ();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        yMove = rb.velocity.y;

        float boost = dashBoost;

        if (!_input.isDashing)
        {
            rb.velocity = new Vector3(_input.xMove * moveSpeed * Time.deltaTime, 
                rb.velocity.y, _input.zMove * moveSpeed * Time.deltaTime);
        }
        else
        {
            rb.velocity = new Vector3(_input.xMove * moveSpeed * Time.deltaTime, 
                rb.velocity.y, _input.zMove * (moveSpeed * boost) * Time.deltaTime);
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
