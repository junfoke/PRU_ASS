using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;


    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, left, right, dam, da }
    private enum MovementStateShoot { idle, kame, banChuong }
    private MovementState state = MovementState.idle;
    float action = 0f;
    float shootAction = 0f;

    [SerializeField] ManageHealth ManageHealth;

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
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player_1_Idle"))
        {
            action = 0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            dirX = -1f; // Di chuyển sang trái
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dirX = 1f; // Di chuyển sang phải
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            action = -1f; // Hành động dam
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            action = 1f; // Hành động da
        }

        if (Input.GetKey(KeyCode.W) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKey(KeyCode.L))
        {
            shootAction = 1f;
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            shootAction = 2f;
        }
        // Thay đổi vận tốc của đối tượng
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        // Cập nhật trạng thái hoạt hình của đối tượng
        UpdateAnimationState(dirX, action, shootAction);
    }

    private void UpdateAnimationState(float dirX, float action, float shootAction)
    {
        MovementState state;
        MovementStateShoot shootState;

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

        if (shootAction == 1f)
        {
            shootState = MovementStateShoot.kame;
        }
        else if (shootAction == 2f)
        {
            shootState = MovementStateShoot.banChuong;
        }
        else
        {
            shootState = MovementStateShoot.idle;
        }


        anim.SetInteger("shootState", (int)shootState);
        anim.SetInteger("state", (int)state); // Cập nhật trạng thái hoạt hình
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}

