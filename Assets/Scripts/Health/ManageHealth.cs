using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ManageHealth : MonoBehaviour
{
    public Image HP_Player1_Image;
    public Image HP_Player2_Image;
    public Image Mana_Player1_Image;
    public Image Mana_Player2_Image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Manage_HP(int player_number, float amount)
    {
        if (player_number == 1)
        {
            //Player 1
            if (GameStart.Player1_Resource.HP + amount > 100) return;
            if (GameStart.Player1_Resource.HP + amount < 0) 
            { 
                GameStart.Player1_Resource.HP = 0;
            }
            else
            {
                GameStart.Player1_Resource.HP += amount;
            }
        }
        else
        {
            //Player 2
            if (GameStart.Player2_Resource.HP + amount > 100) return;
            if (GameStart.Player2_Resource.HP + amount < 0) 
            { 
                GameStart.Player2_Resource.HP = 0;
            }
            else
            {
                GameStart.Player2_Resource.HP += amount;
            }
        }
        Reset_Resouce();
    }

    public void Manage_Mana(int player_number, float amount)
    {
        if (player_number == 1)
        {
            //Player 1
            if (GameStart.Player1_Resource.Mana + amount > 100) return;
            if (GameStart.Player1_Resource.Mana + amount < 0) 
            { 
                GameStart.Player1_Resource.Mana = 0;
            }
            else
            {
                GameStart.Player1_Resource.Mana += amount;
            }
        }
        else
        {
            //Player 2
            if (GameStart.Player2_Resource.Mana + amount > 100) return;
            if (GameStart.Player2_Resource.Mana + amount < 0)
            {
                GameStart.Player2_Resource.Mana = 0;
            }
            else
            {
                GameStart.Player2_Resource.Mana += amount;
            }
        }
        Reset_Resouce();
    }

    public void Reset_Resouce()
    {
        HP_Player1_Image.fillAmount = GameStart.Player1_Resource.HP / 100;
        HP_Player2_Image.fillAmount = GameStart.Player2_Resource.HP / 100;
        Mana_Player1_Image.fillAmount = GameStart.Player1_Resource.Mana / 100;
        Mana_Player2_Image.fillAmount = GameStart.Player2_Resource.Mana / 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
