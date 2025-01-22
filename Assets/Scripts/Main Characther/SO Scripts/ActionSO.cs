using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ActionSO : ScriptableObject
{
    public float attackSpeed, timeToCast, timeToHeal;
    public int damage, maxStamina, stamina, staminaToCast;
}
