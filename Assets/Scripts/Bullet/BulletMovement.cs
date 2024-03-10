using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BulletMovement : MonoBehaviour
{
    private float speed = 10f;
    [SerializeField] private int BulletDamage; 
    [SerializeField] Vector2 velocity;
    [SerializeField] Vector2 direction = new Vector2(0, 1);
    [SerializeField] int timeDestroySelf;
    [SerializeField] private string comparador;
    [SerializeField] private string comparador2;

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
        //if (collision.CompareTag(comparador))
        //{
        //    Player player = collision.GetComponent<Player>();
        //    if (player != null)
        //    {
        //        player.TomarDaņo(daņoDeLaBala); 
        //    }

        //    Destroy(gameObject);
        //}

        //if (collision.CompareTag(comparador2))
        //{
        //    Player2 player2 = collision.GetComponent<Player2>();
        //    if (player2 != null)
        //    {
        //        player2.TomarDaņo(daņoDeLaBala); // Usa daņoDeLaBala en lugar de daņoGolpe
        //    }

        //    Destroy(gameObject);
        //}
    }
}
