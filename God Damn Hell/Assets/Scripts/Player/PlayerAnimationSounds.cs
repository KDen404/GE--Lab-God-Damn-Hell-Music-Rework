using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sound Events that get called in the animation event system
public class PlayerAnimationSounds : MonoBehaviour
{
    public void RunSound()
    {
        AkSoundEngine.PostEvent("PlayerRun", gameObject);
    }

    public void SwordSwingSound()
    {
        AkSoundEngine.PostEvent("SwordSwing", gameObject);
    }

    public void DeathSound()
    {
        AkSoundEngine.PostEvent("PlayerDeath", gameObject);
    }

    public void PlayerGotHitSound()
    {
        AkSoundEngine.PostEvent("PlayerGotHit", gameObject);
    }

    public void AttackBlockSound()
    {
        AkSoundEngine.PostEvent("AttackBlocked", gameObject);
    }
}

