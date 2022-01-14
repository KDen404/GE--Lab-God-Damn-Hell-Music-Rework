using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSounds : MonoBehaviour
{
    public void RunSound()
    {
        AkSoundEngine.PostEvent("PlayerRun", gameObject);
    }
}

