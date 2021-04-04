using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSO : ScriptableObject
{
    public float duration;
    public int damage;

    public AttackDetails attackDetails;
    public float damageCooldown;
    public float spellRadius;
    public Player player;


    // public bool spin;

    // public Transform sprite;
    public virtual void SkillStart(Skill skill) {

    }

    public virtual void SkillUpdate(Skill skill) {

        //Spin();
    }

    // private void Spin() {
    //     if(spin && sprite != null){
    //         sprite.transform.Rotate(Vector3.forward, 100f * Time.deltaTime);
    //     }
        
    // }

    public virtual void OnDrawSkillGizmos(Skill skill) {
        
    }
}
