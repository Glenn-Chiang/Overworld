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
        // Look in direction of cursor
        var cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var lookDir = cursorPos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
        rb.MovePosition(rb.position + moveDir * speed * Time.deltaTime);
    }
}
