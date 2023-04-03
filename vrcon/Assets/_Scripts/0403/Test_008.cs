using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    private int hp = 100;
    private int Pow = 50;

    public void Attack()
    {
        Debug.Log("hit " + this.Pow);
    }

    public void Damage(int damage)
    {
        this.hp -= damage;
        Debug.Log(damage + "auch");
    }

    public int GetHP()
    {
        return this.hp;
    }
}

public class Test_008 : MonoBehaviour
{
    Player player_01 = new();
    Player player_02 = new();
    public Text player01HP;
    public Text player02HP;

    void Start()
    {
        player_01.Attack();
        player_01.Damage(30);
    }

    // Update is called once per frame
    void Update()
    {
        player01HP.text = "Player 01 HP : " + player_01.GetHP();
        player02HP.text = "Player 02 HP : " + player_02.GetHP();

        if (Input.GetMouseButtonDown(0))
        {
            player_01.Damage(1);
        }

        if (Input.GetMouseButtonDown(1))
        {
            player_02.Damage(1);
        }
    }
}
