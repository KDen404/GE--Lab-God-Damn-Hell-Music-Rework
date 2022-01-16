using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonSpearHitColliders : MonoBehaviour
{
    public BoxCollider spearCollider;
    public void ActivateSpearCollider()
    {
        spearCollider.enabled = true;
    }

    public void DeactivateSpearCollider()
    {
        spearCollider.enabled = false;
    }
}
