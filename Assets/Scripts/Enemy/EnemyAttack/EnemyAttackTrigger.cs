using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    public void AnimationTrigger(){
        this.GetComponentInParent<Enemy>().AnimationTrigger();
    }

    public void AnimationFinishTrigger(){
        this.GetComponentInParent<Enemy>().AnimationFinishTrigger();

        Destroy(gameObject);
    }
}
