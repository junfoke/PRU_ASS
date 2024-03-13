using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_HP_MP : MonoBehaviour
{
    [SerializeField] GameObject objectsToSpawn;
    [SerializeField] Transform[] spawnLocations;

    [SerializeField] float spawnTime;
    [SerializeField] float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateObjects", spawnTime, spawnRate);
    }

    private void GenerateObjects()
    {
        int randomNumber = Random.Range(0, spawnLocations.Length);
        GameObject newObject =  Instantiate(objectsToSpawn, spawnLocations[randomNumber].position, Quaternion.identity);
        Destroy(newObject, spawnRate);
    }



}
