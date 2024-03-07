using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private Animator anim;



    [SerializeField] private float moveSpeed = 7f;
    //[SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, left, right, dam, da }
    private MovementState state = MovementState.idle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = 0f; // Hướng di chuyển theo trục x
        float action = 0f; // Hành động

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dirX = -1f; // Di chuyển sang trái
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            dirX = 1f; // Di chuyển sang phải
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            action = -1f; // Hành động dam
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            action = 1f; // Hành động da
        }

        // Thay đổi vận tốc của đối tượng
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        // Cập nhật trạng thái hoạt hình của đối tượng
        UpdateAnimationState(dirX, action);
    }

    private void UpdateAnimationState(float dirX, float action)
    {
        MovementState state;

        if (action != 0f)
        {
            state = (action < 0f) ? MovementState.dam : MovementState.da; // Nếu action < 0, là 'dam', ngược lại là 'da'
        }
        else if (dirX != 0f)
        {
            state = (dirX < 0f) ? MovementState.right : MovementState.left; // Nếu dirX < 0, là 'trái', ngược lại là 'phải'
        }
        else
        {
            state = MovementState.idle; // Đứng yên
        }

        anim.SetInteger("state", (int)state); // Cập nhật trạng thái hoạt hình
    }
}
