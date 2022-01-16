using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour
{
    public BoxCollider swordCollider;

    public void enableSwordCollider()
    {
        swordCollider.enabled = true;
    }

    public void disableSwordcollider()
    {
        swordCollider.enabled = false;
    }
}
