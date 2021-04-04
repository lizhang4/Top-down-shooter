using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{

    public SkillSO skill;
    



    void Start()
    {
        skill.SkillStart(this);
    }

    void Update()
    {
        skill.SkillUpdate(this);
    }

    public void OnDrawGizmos() {
        if (skill != null) {
            skill.OnDrawSkillGizmos(this);
        }

        // Gizmos.color = Color.white;
        // Gizmos.DrawWireSphere(this.transform.position, 2);
    }

    
}
