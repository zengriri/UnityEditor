using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Range(0, 255)]
    public int fight;
    [Range(0, 99)]
    public int weapon;
    [Range(0, 99)]
    public int power;

    public int hp;

    public Example example;

    public int Atk
    {
        get
        {
            return fight + Mathf.FloorToInt(fight * (weapon + power - 8) / 16);
        }
    }
}
