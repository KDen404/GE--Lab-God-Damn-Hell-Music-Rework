using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour
{
    public BoxCollider swordCollider;

    public void EnableSwordCollider()
    {
        swordCollider.enabled = true;
    }

    public void DisableSwordcollider()
    {
        swordCollider.enabled = false;
    }
}
