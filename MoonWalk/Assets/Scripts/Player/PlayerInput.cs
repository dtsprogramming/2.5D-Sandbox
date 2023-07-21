using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float xMove {  get; private set; }
    public float zMove { get; private set; }
    public bool isDashing { get; private set; }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");
        isDashing = Input.GetKey(KeyCode.LeftShift);
    }
}
