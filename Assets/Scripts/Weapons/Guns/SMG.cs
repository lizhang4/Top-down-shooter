using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SMG", menuName = "Assets/Guns/SMG")]
public class SMG : Gun
{
    public override void PlaySound()
    {
        base.PlaySound();
        AudioManager.Instance.Play("Shoot");
    }
}
