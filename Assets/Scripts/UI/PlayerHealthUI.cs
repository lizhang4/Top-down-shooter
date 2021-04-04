using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public PlayerStats playerStats;
    public Text healthText;

    private void Start() {
        maxHealth = playerStats.maxHealth;
        currentHealth = playerStats.currentHealth;

        healthText.text = "Health: " + currentHealth +"/"+ maxHealth;
    }

    private void Update() {
        if (currentHealth != playerStats.currentHealth) {
            maxHealth = playerStats.maxHealth;
            currentHealth = playerStats.currentHealth;

            healthText.text = "Health: " + currentHealth +"/"+ maxHealth;
        }

    }
}
