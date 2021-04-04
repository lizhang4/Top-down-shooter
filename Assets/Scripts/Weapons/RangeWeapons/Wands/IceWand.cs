using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IceWand", menuName = "Assets/RangeWeapon/IceWand")]
public class IceWand : NormalWand
{
    public float spellDuration = 0.5f;
    public float spellRadius = 5f;

    private GameObject spellTempObj;
    public override void ApplyDebuff(ref AttackDetails attackDetails)
    {
        base.ApplyDebuff(ref attackDetails);
    }

    public override void SpellEnter(Player player, PlayerSpellState playerSpellState)
    {
        base.SpellEnter(player, playerSpellState);

        lastSpellTime = playerSpellState.startTime + spellDuration;
        spellTempObj = Instantiate(spellEffect[0], player.transform);

        spellTempObj.GetComponent<Skill>().skill.attackDetails = attackDetails;
        spellTempObj.GetComponent<Skill>().skill.duration = spellDuration;
        spellTempObj.GetComponent<Skill>().skill.spellRadius = spellRadius;
        spellTempObj.GetComponent<Skill>().skill.player = player;
        

        // player.StartCoroutine(player.ImmuneDamageOn(spellDuration));
        
    }

    public override void SpellExit(Player player, PlayerSpellState playerSpellState)
    {
        //base.SpellExit(player, playerSpellState);
    }

    public override void SpellLogicUpdate(Player player, PlayerSpellState playerSpellState)
    {
        base.SpellLogicUpdate(player, playerSpellState);


        // if (player.GetHit()) {
        //     Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(player.transform.position, spellRadius, whatIsDamagable);

        //     attackDetails.freeze = true;
        //     foreach (Collider2D enemy in enemiesHit) {
        //         enemy.transform.SendMessage("Damage", attackDetails);
        //     }

        //     Destroy(spellTempObj);
        //     player.StateMachine.ChangeState(player.IdleState);
        // }

        if(player.GetHit()) {
            player.StateMachine.ChangeState(player.IdleState);
        }

        if (playerSpellState.startTime + spellDuration <= Time.time) {

            player.StateMachine.ChangeState(player.IdleState);


        }

        
    }


    public override void WeaponGizmos(Player player)
    {
        base.WeaponGizmos(player);

        Gizmos.DrawWireSphere(player.transform.position, spellRadius);

    }
}
