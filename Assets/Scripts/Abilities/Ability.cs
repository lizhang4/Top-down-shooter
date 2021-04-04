using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public float abilityCooldown;

    public float lastAbilityTime {get; private set;}
    public virtual void AbilityEnter(Player player, PlayerAbilityState playerAbilityState) {

    }

    public virtual void AbilityLogicUpdate(Player player, PlayerAbilityState playerAbilityState) {
        
    }

    public virtual void AbilityExit(Player player, PlayerAbilityState playerAbilityState) {
        lastAbilityTime = Time.time;
    }

    public virtual void AbilityTrigger(Player player, PlayerAbilityState playerAbilityState) {
        
    }

    public virtual void AbilityFinishTrigger(Player player, PlayerAbilityState playerAbilityState) {
        
    }

    public void InitializeAbility() {
        lastAbilityTime = -10f;
    }
}
