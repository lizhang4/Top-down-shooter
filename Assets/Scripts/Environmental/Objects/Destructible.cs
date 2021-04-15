using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public virtual void Destruct() {
        Destroy(gameObject);
    }
}
