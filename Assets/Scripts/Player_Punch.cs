using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Punch : MonoBehaviour
{
    public ManageHealth ManageHealth;
    public float facingThreshold = 0.9f; // Threshold for facing direction

    public float reloadTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        reloadTime += Time.deltaTime;

        //Player 1 punch
        if (Input.GetKeyDown(KeyCode.J) && reloadTime>=0.5 && GameStart.Player1_Resource.Mana>0)
        {
            //Minus mana
            ManageHealth.Manage_Mana(1, -5);

            // Find all GameObjects with the specified tag
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player2");

            foreach (GameObject player in players)
            {
                if (player != gameObject)
                {
                    // Determine if the other player is within punching range and in front of the current player
                    Vector2 directionToPlayer = player.transform.position - transform.position;
                    Vector2 facingDirection = transform.right; // Assuming the player's facing direction is along the right vector

                    // Calculate dot product to check if the other player is in front
                    float dotProduct = Vector2.Dot(directionToPlayer.normalized, facingDirection.normalized);

                    if (Vector2.Distance(transform.position, player.transform.position) <= 1 && dotProduct >= facingThreshold)
                    {
                        ManageHealth.Manage_HP(2, -10);
                    }
                }
            }
            //Reset reloadTime 
            reloadTime = 0;

        }
        if (Input.GetKeyDown(KeyCode.K) && reloadTime >= 0.5 && GameStart.Player1_Resource.Mana > 0)
        {
            //Minus mana
            ManageHealth.Manage_Mana(1, -7.5f);

            // Find all GameObjects with the specified tag
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player2");

            foreach (GameObject player in players)
            {
                if (player != gameObject)
                {
                    // Determine if the other player is within punching range and in front of the current player
                    Vector2 directionToPlayer = player.transform.position - transform.position;
                    Vector2 facingDirection = transform.right; // Assuming the player's facing direction is along the right vector

                    // Calculate dot product to check if the other player is in front
                    float dotProduct = Vector2.Dot(directionToPlayer.normalized, facingDirection.normalized);

                    if (Vector2.Distance(transform.position, player.transform.position) <= 1.2 && dotProduct >= facingThreshold)
                    {
                        ManageHealth.Manage_HP(2, -15);
                    }
                }
            }
            //Reset reloadTime 
            reloadTime = 0;
        }

        //Player 2 punch
        if (Input.GetKeyDown(KeyCode.Alpha1) && reloadTime >= 0.5 && GameStart.Player2_Resource.Mana > 0)
        {
            //Minus mana
            ManageHealth.Manage_Mana(2, -5);

            // Find all GameObjects with the specified tag
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player1");

            foreach (GameObject player in players)
            {
                if (player != gameObject)
                {
                    // Determine if the other player is within punching range and in front of the current player
                    Vector2 directionToPlayer = player.transform.position - transform.position;
                    Vector2 facingDirection = -transform.right; // Assuming the player's facing direction is along the right vector

                    // Calculate dot product to check if the other player is in front
                    float dotProduct = Vector2.Dot(directionToPlayer.normalized, facingDirection.normalized);

                    if (Vector2.Distance(transform.position, player.transform.position) <= 1 && dotProduct >= facingThreshold)
                    {
                        ManageHealth.Manage_HP(1, -10);
                    }
                }
            }
            //Reset reloadTime 
            reloadTime = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && reloadTime >= 0.5 && GameStart.Player2_Resource.Mana > 0)
        {
            //Minus mana
            ManageHealth.Manage_Mana(2, -7.5f);

            // Find all GameObjects with the specified tag
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player1");

            foreach (GameObject player in players)
            {
                if (player != gameObject)
                {
                    // Determine if the other player is within punching range and in front of the current player
                    Vector2 directionToPlayer = player.transform.position - transform.position;
                    Vector2 facingDirection = -transform.right; // Assuming the player's facing direction is along the left vector

                    // Calculate dot product to check if the other player is in front
                    float dotProduct = Vector2.Dot(directionToPlayer.normalized, facingDirection.normalized);

                    if (Vector2.Distance(transform.position, player.transform.position) <= 1.2 && dotProduct >= facingThreshold)
                    {
                        ManageHealth.Manage_HP(1, -15);
                    }
                }
            }
            //Reset reloadTime 
            reloadTime = 0;
        }

    }
}
