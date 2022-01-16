using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnStart : MonoBehaviour
{
    private uint IngameMusicEvent; 
    void Start()
    {
        IngameMusicEvent = AkSoundEngine.PostEvent("IngameMusic", gameObject);
    }

    public void stop_music()
    {
        AkSoundEngine.StopPlayingID(IngameMusicEvent, 1000, AkCurveInterpolation.AkCurveInterpolation_Constant);
    }

}
