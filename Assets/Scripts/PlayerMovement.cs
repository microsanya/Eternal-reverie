using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    private Vector2 moveVector;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        //moveVector.x = Input.GetAxisRaw("Horizontal");
        //moveVector.y = Input.GetAxisRaw("Vertical");
        //rb.MovePosition(rb.position + moveVector * speed);
        rb.linearVelocity = moveVector.normalized * speed;
    }

}
