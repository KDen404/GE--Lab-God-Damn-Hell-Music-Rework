using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonMageInstantiateProjectile : MonoBehaviour
{
    public Transform fireball;
    public Transform fireballEmpty;
    public Transform pyroball;
    public Transform pyroballEmpty;

    public void InstantiateFireball()
    {
        Instantiate(fireball, new Vector3(fireballEmpty.position.x, fireballEmpty.position.y, fireballEmpty.position.z), transform.parent.rotation);
    }

    public void InstantiatePyroball()
    {
        Instantiate(pyroball, new Vector3(pyroballEmpty.position.x, pyroballEmpty.position.y, pyroballEmpty.position.z), transform.parent.rotation);
    }
}
