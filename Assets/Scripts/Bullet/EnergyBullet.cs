using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnergyBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Jugador2"))
    //    {
    //        other.GetComponent<Player2>().TomarDaño(damage);
    //        Destroy(gameObject);
    //    }


    //}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bala2"))
        {
            Debug.Log("La bala 2 colisionó con otra bala");
            Destroy(gameObject);
            Destroy(other.gameObject); // Destroy the other bullet here
            Destroy(this.gameObject);
        }
    }
}
