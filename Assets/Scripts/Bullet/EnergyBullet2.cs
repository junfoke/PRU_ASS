using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBullet2 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    public ManageHealth ManageHealth;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            ManageHealth.Manage_HP(1, damage);
            Destroy(gameObject);
        }
    }
}
