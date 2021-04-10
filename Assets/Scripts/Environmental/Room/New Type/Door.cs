using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public List<Animator> animators;
    private void Start() {
        foreach(Animator animator in GetComponentsInChildren<Animator>()){
            animators.Add(animator);
            animator.SetBool("Open", true);
        }
    }
    public void OpenDoor() {
        foreach (Animator animator in animators) {
            animator.SetBool("Open", true);  
        }
    }

    public void CloseDoor() {
        foreach (Animator animator in animators) {
            animator.SetBool("Open", false);  
        }
    }
}
