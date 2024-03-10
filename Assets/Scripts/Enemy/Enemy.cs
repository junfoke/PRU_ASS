using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed; // Agregar esta línea para definir la velocidad
    private Rigidbody2D rb;
    private Vector2 moveDirection = Vector2.right; // Dirección predeterminada
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = moveDirection * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
    public void SetMoveDirection(Vector2 direction)
    {
        moveDirection = direction;
    }
}
