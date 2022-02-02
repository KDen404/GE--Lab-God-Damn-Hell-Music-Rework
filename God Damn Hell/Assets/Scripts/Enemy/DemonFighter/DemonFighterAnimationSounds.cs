using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sound events that get called in the animation event system
public class DemonFighterAnimationSounds : MonoBehaviour
{
    public void DemonFighterRunSound()
    {
        AkSoundEngine.PostEvent("DemonFighterRun", gameObject);
    }

    public void DemonFighterClawSwingSound()
    {
        AkSoundEngine.PostEvent("FighterSwing", gameObject);
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
