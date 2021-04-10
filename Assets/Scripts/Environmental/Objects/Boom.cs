using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : Destructible
{
    public GameObject explosion;
    public override void Destruct()
    {
        Debug.Log("Explode!");
        // Instantiate boom effect
        base.Destruct();

    }
}
