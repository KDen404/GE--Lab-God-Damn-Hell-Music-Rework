using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonMageAnimationSounds : MonoBehaviour
{
    public void DemonMageRunSound()
    {
        AkSoundEngine.PostEvent("DemonMageRun", gameObject);
    }

    public void DemonMageDeathSound()
    {
        AkSoundEngine.PostEvent("DemonMageDeath", gameObject);
    }

    public void DemonMageGotHitSound()
    {
        AkSoundEngine.PostEvent("DemonMageGotHit", gameObject);
    }

    public void DemonMageWalkSound()
    {
        AkSoundEngine.PostEvent("DemonMageWalk", gameObject);
    }
}
