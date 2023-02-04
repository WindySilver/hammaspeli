using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthSystem : MonoBehaviour
{

    public int maxHealth = 5;
    public TextMeshProUGUI healthText;
    private int currentHealth;
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
            Debug.Log("Pancakes did it.");
            // GAME OVER
        }
    }

    // Decreases current health (e.g. when hit by something that damages player)
    void decreaseHealth(){
        currentHealth--;
        setHealthText();
        if (currentHealth <=0){
            _dead = true;
        }
    }

    // Increases current health (e.g. when player touches a health-restoring item)
    void addHealth(){
        currentHealth++;
        setHealthText();
    }

    // Sets or updates the health text 
    void setHealthText(){
        healthText.text = "Health: " + currentHealth;
    }
}
