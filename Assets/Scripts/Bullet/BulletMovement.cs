using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BulletMovement : MonoBehaviour
{
    public ManageHealth ManageHealth;
    private float speed = 10f;
    [SerializeField] private int BulletDamage;
    [SerializeField] Vector2 velocity;
    [SerializeField] Vector2 direction = new Vector2(0, 1);
    [SerializeField] int timeDestroySelf;
    [SerializeField] private string Player1;
    [SerializeField] private string Player2;


    private void Start()
    {
        Destroy(gameObject, timeDestroySelf);
    }

    private void Update()
    {
        velocity = direction * speed;
    }

    private void FixedUpdate()
    {
        MoveBullet();
    }

    private void MoveBullet()
    {
        Vector2 pos = transform.position;
        pos += velocity * Time.fixedDeltaTime;
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Player1))
        {

            ManageHealth.Manage_HP(1, -BulletDamage);

            Destroy(gameObject);
        }

        if (collision.CompareTag(Player2))
        {
            ManageHealth.Manage_HP(2, -BulletDamage);

            Destroy(gameObject);
        }
    }
}
