using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLogic : MonoBehaviour
{
    public GameObject[] gates;
    public float duration = 10;

    private void OpenGates()
    {
        for (int i = 0; i < gates.Length; i++)
        {
            iTween.MoveTo(gates[i], new Vector3(gates[i].transform.position.x, gates[i].transform.position.y + 20, gates[i].transform.position.z), duration);
        }
    }

    private void CloseGates()
    {
        for (int i = 0; i < gates.Length; i++)
        {
            iTween.MoveTo(gates[i], new Vector3(gates[i].transform.position.x, gates[i].transform.position.y - 20, gates[i].transform.position.z), duration);
        }
    }
}
