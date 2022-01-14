using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonFighterAnimationSounds : MonoBehaviour
{
    public void DemonFighterRunSound()
    {
        AkSoundEngine.PostEvent("DemonFighterRun", gameObject);
    }

    public void DemonFighterDeathSound()
    {
        AkSoundEngine.PostEvent("DemonFighterDeath", gameObject);
    }

    public void DemonFighterGotHitSound()
    {
        AkSoundEngine.PostEvent("DemonFighterGotHit", gameObject);
    }

    public void DemonFighterWalkSound()
    {
        AkSoundEngine.PostEvent("DemonFighterWalk", gameObject);
    }
}
