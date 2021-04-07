using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Destroy");
        Destroy(other.gameObject);
    }

    private void Update() {
        
    }
}
