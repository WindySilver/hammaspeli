using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tormaus : MonoBehaviour
{
    [SerializeField] private int enemyImmunity = 2;
    [SerializeField] private int playerImmunity = 2;
    [SerializeField] private GameObject player;

    private Sinkoilu _sinkoilu;
    private PlayerAudioHandler _audioHandler;
    private float _immunityTimer;
    private float _playerTimer;
    

    // Start is called before the first frame update
    void Start()
    {
        _sinkoilu = player.GetComponent<Sinkoilu>();
        _audioHandler = player.GetComponent<PlayerAudioHandler>();
        _immunityTimer = 0;
        _playerTimer = 0;
    }

    void Update(){
        if(_immunityTimer > 0){
            _immunityTimer -= Time.deltaTime;
        }
        if(_playerTimer > 0){
            _playerTimer -= Time.deltaTime;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(_immunityTimer <= 0){
            _immunityTimer = enemyImmunity;
            _sinkoilu.rebelDown();
            collision.gameObject.transform.parent.GetComponent<EnemyHealthSystem>().decreaseHealth();
            _audioHandler.PlayImpact();
            }
        }
        else if(collision.gameObject.CompareTag("Acid"))
        {
            if(_playerTimer <= 0){
            _playerTimer = playerImmunity;
            _sinkoilu.rebelUp();
            player.GetComponent<HealthSystem>().decreaseHealth();
            }
        }
        else
        {
            _sinkoilu.grabToCeiling();
            _audioHandler.PlaySplat();
        }
    }
}
