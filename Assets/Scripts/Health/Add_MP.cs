using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Add_MP : MonoBehaviour
{
    public ManageHealth ManageHealth;
    [SerializeField] private int AddMP;
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
            ManageHealth.Manage_Mana(1, AddMP);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player2"))
        {
            ManageHealth.Manage_Mana(2, AddMP);
            Destroy(gameObject);
        }
    }
}
