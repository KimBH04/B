using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public int MonsterHp = 5;

    public void Damanged(int dam)
    {
        MonsterHp -= dam;
        if (MonsterHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
