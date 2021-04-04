using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTrigger : MonoBehaviour
{
    private ParticleSystem pS;

    private GameObject playerCharacter;
    private Player player;

    private void Start() {
        if (GetComponent<ParticleSystem>() != null) {
            pS = GetComponent<ParticleSystem>();
        }

        playerCharacter = GameObject.Find("Player");
        player = playerCharacter.GetComponent<Player>();

    }

    private void Update() {
        if(pS.isStopped) {
            Debug.Log("Stop");
            EffectAnimationFinishTrigger();
        }

    }



    public void EffectAnimationTrigger(){

    }

    public void EffectAnimationFinishTrigger(){
        if(player.StateMachine.currentState == player.AttackState) {
            player.AttackAnimationFinishTrigger();

        }
        else if(player.StateMachine.currentState == player.SpellState){
            player.SpellAnimationFinishTrigger();
        }
        
        Destroy(gameObject);
        
    }
}
