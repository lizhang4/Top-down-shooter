using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : Destructible
{
    public GameObject explosionGO;
    public int damage;
    public override void Destruct()
    {
        GameObject tempObj = Instantiate(explosionGO, transform.position, Quaternion.identity);
        tempObj.GetComponent<Explosion>().attackDetails.damageAmount = damage;
        base.Destruct();

    }
}
