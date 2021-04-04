using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Weapon weapon;

    private void Start() {
        if (weapon != null) {
            this.name = weapon.name;
        }
    }
}
