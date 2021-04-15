using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NewPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Stats Data")]
    public int maxHealth = 5;
    public int maxShield = 5;
    public int baseDamage = 1;
    public float moveSpeed = 15f;


    public float shieldRecoveryTimeAfterDamage = 2f;
    public float shieldRecoveryTime = 1f;
    


    public GameObject hitParticle;



    [Header("Attacks")]
    public int critChance = 10;

    [Header("Layer Masks")]
    public LayerMask whatIsDamagable;
}
