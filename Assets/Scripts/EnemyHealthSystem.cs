using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealthSystem : MonoBehaviour
{

    public double maxHealth = 5;
    public TextMeshProUGUI healthText;
    private double currentHealth;
    private bool _dead = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        setHealthText();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_dead){
            EnemyDefeated();
        }
    }

    void EnemyDefeated(){
        healthText.text = "";
        // Mato lähtee kurkkuun
    }

    // Decreases current health (e.g. when hit by something that damages player)
    public void decreaseHealth(){
        currentHealth-= 0.5;
        setHealthText();
        if (currentHealth <=0){
            _dead = true;
        }
    }

    // Increases current health (e.g. when player touches a health-restoring item)
    public void addHealth(){
        currentHealth++;
        setHealthText();
    }

    // Sets or updates the health text 
    public void setHealthText(){
        healthText.text = "Enemy Health: " + currentHealth;
    }
}
