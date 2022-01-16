using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
