using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{

    public static PlayerStatsUI Instance {get ; private set;}

    private void Awake() {
        if(Instance == null)     {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else  {
            Destroy(gameObject);
        }
    }
    public int maxHealth;
    public int currentHealth;

    public int maxShield;
    public int currentShield;

    public int score;
    public PlayerStats playerStats;
    public PlayerData playerData;
    public Text healthText;
    public Text shieldText;
    public Text scoreText;


    private void Start() {
        maxHealth = playerData.maxHealth;
        currentHealth = playerStats.currentHealth;

        maxShield = playerData.maxShield;
        currentShield = playerStats.currentShield;

        score = 0;

        healthText.text = "Health: " + currentHealth +"/"+ maxHealth;
        shieldText.text = "Shield: " + currentShield +"/"+ maxShield;
        scoreText.text = "Score: " + score;
    }

    private void Update() {
        if (currentHealth != playerStats.currentHealth) {
            maxHealth = playerData.maxHealth;
            currentHealth = playerStats.currentHealth;

            healthText.text = "Health: " + currentHealth +"/"+ maxHealth;
        }

        if (currentShield != playerStats.currentShield) {
            maxShield = playerData.maxShield;
            currentShield = playerStats.currentShield;

            shieldText.text = "Shield: " + currentShield +"/"+ maxShield;
        }

        

    }

    public void AddScore() {
        score += 1;
        scoreText.text = "Score: " + score;


    }
}
