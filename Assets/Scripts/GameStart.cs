using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameStart : MonoBehaviour
{

    public float TimeCount = 0;
    public static Player Player1_Resource { get; set; }
    public static Player Player2_Resource { get; set; }

    public ManageHealth ManageHealth;
    // Start is called before the first frame update
    void Start()
    {
        Player1_Resource = new Player(500, 100);
        Player2_Resource = new Player(500, 100);
    }

    // Update is called once per frame
    void Update()
    {
        //Plus 5 Mana after 1s
        TimeCount += Time.deltaTime;
        if (TimeCount > 1)
        {
            if (Player1_Resource.Mana <= 95) Player1_Resource.Mana += 5;
            if (Player2_Resource.Mana <= 95) Player2_Resource.Mana += 5;
            TimeCount = 0;
            ManageHealth.Reset_Resouce();
        }
    }
}

public class Player
{
    public float HP { get; set; }
    public float Mana { get; set; }

    public Player(int HP, int Mana)
    {
        this.HP = HP;
        this.Mana = Mana;
    }
}
