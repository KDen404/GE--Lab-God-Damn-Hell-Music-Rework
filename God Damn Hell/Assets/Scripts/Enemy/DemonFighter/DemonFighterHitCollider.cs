using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Activate and deactivate the respective colliders at specific times of the animation
// Functions get called in the animation event system
public class DemonFighterHitCollider : MonoBehaviour
{
    public BoxCollider leftHandCollider;
    public BoxCollider rightHandCollider;

    public void ActivateLeftHandCollider()
    {
        leftHandCollider.enabled = true;
    }

    public void ActivateRightHandCollider()
    {
        rightHandCollider.enabled = true;
    }

    public void DeactivateLeftHandCollider()
    {
        leftHandCollider.enabled = false;
    }

    public void DeactivateRightHandCollider()
    {
        rightHandCollider.enabled = false;
    }
}
