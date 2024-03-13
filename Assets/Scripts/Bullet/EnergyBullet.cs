using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnergyBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    public ManageHealth ManageHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player2"))
        {
            ManageHealth.Manage_HP(2, damage);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bala2"))
        {
            Debug.Log("Bullet 2 collided with another bullet");
            Destroy(gameObject);
            Destroy(other.gameObject); // Destroy the other bullet here
            Destroy(this.gameObject);
        }
    }
}
