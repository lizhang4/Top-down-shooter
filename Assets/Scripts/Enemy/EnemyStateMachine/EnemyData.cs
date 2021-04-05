using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NewEnemyData", menuName = "Data/Enemy Data/Base Data")]
public class EnemyData : ScriptableObject
{
    [Header("Stats Data")]
    public int maxHealth = 10;
    public int baseDamage = 1;
    public float moveSpeed = 5f;
    public GameObject projectile;
    public bool moveWhileAttack;
    


    public GameObject hitParticle;


    [Header("Checks Data")]
    public float playerDetectedRadius = 5f;
    public float maxAgroRadius = 8f;
    public float closeRangeActionRadius = 2f;
    public float midRangeActionRadius = 5f;
    public float retreatRangeRadius = 3f;


    [Header("Attacks")]

    [Header("Layer Masks")]
    public LayerMask whatIsPlayer;
}
