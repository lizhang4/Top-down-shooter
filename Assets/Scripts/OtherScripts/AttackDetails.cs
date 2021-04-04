using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AttackDetails
{
    public GameObject effect;
    public Vector2 effectPositionOffset;
    public Vector3 effectRotationOffset;


    public Vector2 position;
    public Vector2 attackPositionOffset;
    public float attackRadius;
    public Vector2 attackSize;
    public int damageAmount;

    #region Attack Effects
    public bool freeze;
    public bool shock;
    public bool burn;

    #endregion
    
    
}
