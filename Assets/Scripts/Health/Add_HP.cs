using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Add_HP : MonoBehaviour
{
    public ManageHealth ManageHealth;
    [SerializeField] private int AddHP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            ManageHealth.Manage_HP(1, AddHP);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player2"))
        {
            ManageHealth.Manage_HP(2, AddHP);
            Destroy(gameObject);
        }
    }
}
