using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    // Once actual enemies exist this should be changed to protected
    public int healthPoints = 10;

    public float movementspeed = 2.5f;

    public float aggroRange;
}
