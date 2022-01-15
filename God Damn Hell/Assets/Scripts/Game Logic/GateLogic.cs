using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLogic : MonoBehaviour
{
    public GameObject[] gates;
    public float duration = 10;

    public void OpenGates()
    {
        for (int i = 0; i < gates.Length; i++)
        {
            iTween.MoveTo(gates[i], iTween.Hash("y", gates[i].transform.position.y + 20, "time", duration));
            //iTween.MoveTo(gates[i], new Vector3(gates[i].transform.position.x, gates[i].transform.position.y + 20, gates[i].transform.position.z), duration);
            AkSoundEngine.PostEvent("GateOpen", gameObject);
        }
    }

    public void CloseGates()
    {
        for (int i = 0; i < gates.Length; i++)
        {
            iTween.MoveTo(gates[i], iTween.Hash("y", gates[i].transform.position.y - 20, "time", duration));
            //iTween.MoveTo(gates[i], new Vector3(gates[i].transform.position.x, gates[i].transform.position.y - 20, gates[i].transform.position.z), duration);
            AkSoundEngine.PostEvent("GateOpen", gameObject);
        }
    }
}
