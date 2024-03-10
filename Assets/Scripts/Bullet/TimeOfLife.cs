using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfLife : MonoBehaviour
{
    [SerializeField] private float timeOfLife;
    void Start()
    {
        Destroy(gameObject, timeOfLife);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
