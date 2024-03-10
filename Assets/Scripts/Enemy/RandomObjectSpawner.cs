using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToSpawn;
    [SerializeField] Transform[] spawnLocations;

    [SerializeField] float spawnTime;
    [SerializeField] float spawnRate;

    [SerializeField] Transform leftBoundary;
    [SerializeField] Transform rightBoundary;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateObjects", spawnTime, spawnRate);
    }

    // Update is called once per frame
    private void GenerateObjects()
    {
        for (int i = 0; i < objectsToSpawn.Length; i++)
        {
            int randomIndex = Random.Range(0, spawnLocations.Length);
            Vector2 randomLocation = spawnLocations[randomIndex].position;

            Vector2 moveDirection = Vector2.right; 
            if (randomLocation.x < leftBoundary.position.x)
            {
                moveDirection = Vector2.right; 
            }
            else if (randomLocation.x > rightBoundary.position.x)
            {
                moveDirection = Vector2.left; 
            }

            GameObject spawnedObject = Instantiate(objectsToSpawn[i], randomLocation, Quaternion.identity);
            Enemy enemigoScript = spawnedObject.GetComponent<Enemy>();
            if (enemigoScript != null)
            {
                enemigoScript.SetMoveDirection(moveDirection);
            }
        }
    }
}
