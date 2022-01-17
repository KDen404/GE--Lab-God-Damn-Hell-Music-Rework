using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipColliders : MonoBehaviour
{
    public BoxCollider swordCollider;
    public BoxCollider shieldCollider;

    public void EnableSwordCollider()
    {
        swordCollider.enabled = true;
    }

    public void DisableSwordCollider()
    {
        swordCollider.enabled = false;
    }

    public void EnableShieldCollider()
    {
        shieldCollider.enabled = true;
    }
}
