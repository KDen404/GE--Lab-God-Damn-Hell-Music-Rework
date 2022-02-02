using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Activate and deactivate the spear collider at specific times of the animation
// Functions get called in the animation event system
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
