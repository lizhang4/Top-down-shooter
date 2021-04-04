using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTrigger : MonoBehaviour
{
    public GameObject playerCharacter;
    public Player player;
    private void Start() {
        playerCharacter = GameObject.Find("Player");
        player = playerCharacter.GetComponent<Player>();
    }
    public void AttackAnimationTrigger(){
        player.AttackAnimationTrigger();
    }

    public void AttackAnimationFinishTrigger(){
        player.AttackAnimationFinishTrigger();
    }

    public void SpellAnimationTrigger(){
        player.SpellAnimationTrigger();
    }

    public void SpellAnimationFinishTrigger(){
        player.SpellAnimationFinishTrigger();
    }
}
