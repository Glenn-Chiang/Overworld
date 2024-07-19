using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 moveDir;

    void Update()
    {
        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");
        moveDir.x = moveX;
        moveDir.y = moveY;
        moveDir.Normalize();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir * speed * Time.deltaTime);
    }
}
