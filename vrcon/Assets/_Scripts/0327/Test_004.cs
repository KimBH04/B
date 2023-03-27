using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_004 : MonoBehaviour
{
    public int hp = 180;
    public Text hpText;
    public Text hpStatus;

    void Update()
    {
        hpStatus.text = hp.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            hp++;
        }
        if (Input.GetMouseButtonDown(1))
        {
            hp--;
        }

        if (hp <= 50)
        {
            //Debug.Log("run");
            hpText.text = "run";
        }
        else if (hp >= 200)
        {
            //Debug.Log("attack");
            hpText.text = "attack";
        }
        else
        {
            //Debug.Log("defense");
            hpText.text = "defense";
        }
    }
}
