using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void PlayerGotHit()
    {
        AkSoundEngine.PostEvent("PlayerGotHit", gameObject);
    }

    public void AttackBlockSound()
    {
        AkSoundEngine.PostEvent("AttackBlocked", gameObject);
    }
}

