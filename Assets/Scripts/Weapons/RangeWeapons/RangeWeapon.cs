using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangeWeapon", menuName = "Assets/RangeWeapon")]

public class RangeWeapon : Weapon
{
    public float projectileSpeed = 10f;
    public GameObject projectile;





    // public enum RangeType {
    //     straight, 
    //     shotgun,
    // }

    //public int bulletAmountPerShot = 1;
    //public RangeType rangeType;

    public override void AttackEnter(Player player, PlayerAttackState playerAttackState)
    {
        base.AttackEnter(player, playerAttackState);

        lastAttackTime = Time.time - (1/attackRate);
    }

    public override void AttackLogicUpdate(Player player, PlayerAttackState playerAttackState)
    {
        base.AttackLogicUpdate(player, playerAttackState);

        // if(rangeType == RangeType.straight){
        //     GameObject tempObj =  Instantiate(projectile, player.attackPoint.position, Quaternion.Euler(0,0,player.facingAngle));
        //     tempObj.GetComponent<Projectile>().facingDirection = player.facingDirection;
        //     tempObj.GetComponent<Projectile>().attackDetails.damageAmount = attackDamage;
        //     tempObj.GetComponent<Projectile>().speed = projectileSpeed;
        //     tempObj.GetComponent<Projectile>().playerAttack = true;
        // }

        // else if(rangeType == RangeType.shotgun) {
        //     for(int i = 0; i < 2; i++) {
        //         float spreadAngle = 10f;
        //         float spreadAngle2 = -spreadAngle;
        //         Vector2 facingDirection = player.facingDirection;
        //         float facingAngle = Vector2.SignedAngle(Vector2.up, facingDirection);

        //         //Debug.Log("Facing Direction: " + facingDirection + "Facing Angle:" + facingAngle);
        //         // float facingAngle = Vector2.Angle(Vector2.zero, facingDirection);
        //         // facingAngle = facingAngle + -i*
        //         spreadAngle = facingAngle + 90f - spreadAngle;
        //         spreadAngle2 = facingAngle + 90f - spreadAngle2;
        //         Debug.Log(facingAngle);
        //         Debug.Log(spreadAngle+ ","+spreadAngle2);

        //         // spreadAngle2 = playerAttack.facingAngle + spreadAngle2;
        //         float spreadRadian = spreadAngle*Mathf.Deg2Rad;
        //         float spreadRadian2 = spreadAngle2*Mathf.Deg2Rad;
        //         Debug.Log(spreadRadian + "," + spreadRadian2);
        //         ///Debug.Log("SpreadAngle: " + spreadAngle + "SpreadRadian" + spreadRadian);
        //         Vector2 spreadDirection = new Vector2(Mathf.Cos(spreadRadian), Mathf.Sin(spreadRadian));
        //         Vector2 spreadDirection2 = new Vector2(Mathf.Cos(spreadRadian2), Mathf.Sin(spreadRadian2));

        //         spreadDirection = spreadDirection.normalized;
        //         spreadDirection2 = spreadDirection2.normalized;

        //         Debug.Log(spreadDirection + "," + spreadDirection2);

        //         //Debug.Log("SpreadDirection:" + spreadDirection);



        //         if(i == 0) {
        //             GameObject tempObj =  Instantiate(projectile, player.attackPoint.position, Quaternion.Euler(0,0,player.facingAngle));
        //             tempObj.GetComponent<Projectile>().facingDirection = player.facingDirection ;
        //             tempObj.GetComponent<Projectile>().attackDetails.damageAmount = attackDamage;
        //             tempObj.GetComponent<Projectile>().speed = projectileSpeed;
        //             tempObj.GetComponent<Projectile>().playerAttack = true;
        //         }
        //         else {
        //             // GameObject tempObj = Instantiate(projectile, playerAttack.attackPoint.position, Quaternion.Euler(0,0,playerAttack.facingAngle));
        //             // tempObj.GetComponent<Projectile>().facingDirection = spreadDirection;
        //             // tempObj.GetComponent<Projectile>().attackDetails.damageAmount = attackDamage;
        //             // tempObj.GetComponent<Projectile>().speed = projectileSpeed;
        //             // tempObj.GetComponent<Projectile>().playerAttack = true;
        //             GameObject tempObj1 =  Instantiate(projectile, player.attackPoint.position, Quaternion.Euler(0,0,player.facingAngle));
        //             GameObject tempObj2 =  Instantiate(projectile, player.attackPoint.position, Quaternion.Euler(0,0,player.facingAngle));
        //             tempObj1.GetComponent<Projectile>().facingDirection = spreadDirection;
        //             tempObj1.GetComponent<Projectile>().attackDetails.damageAmount = attackDamage;
        //             tempObj1.GetComponent<Projectile>().speed = projectileSpeed;
        //             tempObj1.GetComponent<Projectile>().playerAttack = true;

        //             tempObj2.GetComponent<Projectile>().facingDirection = spreadDirection2;
        //             tempObj2.GetComponent<Projectile>().attackDetails.damageAmount = attackDamage;
        //             tempObj2.GetComponent<Projectile>().speed = projectileSpeed;
        //             tempObj2.GetComponent<Projectile>().playerAttack = true;
        //         }
        //     }
        // }



        
    }

    public virtual void SpawnProjectile(Player player, PlayerAttackState playerAttackState) {
        GameObject tempObj =  Instantiate(projectile, player.attackPoint.position, Quaternion.Euler(0,0,player.facingAngle));
        tempObj.GetComponent<Projectile>().facingDirection = player.facingDirection;
        tempObj.GetComponent<Projectile>().attackDetails.damageAmount = attackDamage;
        tempObj.GetComponent<Projectile>().speed = projectileSpeed;
        tempObj.GetComponent<Projectile>().playerAttack = true;
    }

    public virtual void SpawnProjectile(Player player, PlayerAttackState playerAttackState, AttackDetails attackDetails) {
        GameObject tempObj =  Instantiate(projectile, player.attackPoint.position, Quaternion.Euler(0,0,player.facingAngle));
        tempObj.GetComponent<Projectile>().facingDirection = player.facingDirection;
        tempObj.GetComponent<Projectile>().speed = projectileSpeed;
        tempObj.GetComponent<Projectile>().playerAttack = true;

        tempObj.GetComponent<Projectile>().attackDetails.damageAmount = attackDetails.damageAmount;
        tempObj.GetComponent<Projectile>().attackDetails.shock = attackDetails.shock;
        tempObj.GetComponent<Projectile>().attackDetails.burn = attackDetails.burn;
        tempObj.GetComponent<Projectile>().attackDetails.freeze = attackDetails.freeze;

    }

    public virtual void ApplyDebuff(ref AttackDetails attackDetails) {

    }




}
