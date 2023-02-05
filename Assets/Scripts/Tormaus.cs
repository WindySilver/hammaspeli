using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tormaus : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Sinkoilu _sinkoilu;
    // Start is called before the first frame update
    void Start()
    {
        _sinkoilu = player.GetComponent<Sinkoilu>();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _sinkoilu.rebelDown();
            //enemy loses health
        }
        else if(collision.gameObject.CompareTag("Acid"))
        {
            _sinkoilu.rebelUp();
            //player loses health
        }
        else
        {
            _sinkoilu.grabToCeiling();
        }
    }
}
