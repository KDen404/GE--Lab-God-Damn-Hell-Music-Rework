using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonFighterAnimationSounds : MonoBehaviour
{
    public void DemonFighterRun()
    {
        AkSoundEngine.PostEvent("DemonFighterRun", gameObject);
    }

    public void DemonFighterDeath()
    {
        AkSoundEngine.PostEvent("DemonFighterDeath", gameObject);
    }

    public void DemonFighterGotHit()
    {
        AkSoundEngine.PostEvent("DemonFighterGotHit", gameObject);
    }

    public void DemonFighterWalk()
    {
        AkSoundEngine.PostEvent("DemonFighterWalk", gameObject);
    }
}
