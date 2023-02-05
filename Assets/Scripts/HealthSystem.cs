using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthSystem : MonoBehaviour
{

    public int maxHealth = 5;
    public TextMeshProUGUI healthText;
    public MusicHandler music;
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
            Defeated();
        }
    }

    void Defeated(){
        music.PlayDeath();
        healthText.text = "You has been vanquished!";
        Object.Destroy(this.gameObject);
    }

    // Decreases current health (e.g. when hit by something that damages player)
    public void decreaseHealth(){
        currentHealth--;
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
        healthText.text = "Tooth Health: " + currentHealth;
    }
}
