using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinkoilu : MonoBehaviour
{
    public GameObject character;
    public float grabProtectionTime = 0.2f;
    public float grabTime = 5.0f;
    private bool _attached = false;
    private float _protectionTimer;
    private float _grabTimer;
    private Rigidbody2D rigid;


    // Start is called before the first frame update
    void Start()
    {
        _protectionTimer = grabProtectionTime;
        _grabTimer = grabProtectionTime;
        rigid = character.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!_attached && rigid.velocity.y > 0 && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))){
            grabToCeiling();
        }

        if (_attached){
            _grabTimer -= Time.deltaTime;
        
            if(_protectionTimer > 0){
                _protectionTimer -= Time.deltaTime;
            }
            else if(Input.anyKey || _grabTimer <= 0){
                unGrab();
            }
        }
    }

    // Turns the player around and makes it grab to the ceiling
    void grabToCeiling(){
        // If input happens or timer runs out,
        // flip back around and return gravity to normal

        _attached = true;
        character.transform.Rotate(0, 0, 180);
        rigid.gravityScale = -1;

    }

    // Player ungrabs and falls down
    void unGrab(){
        _attached = false;
        character.transform.Rotate(0, 0, 180);
        rigid.gravityScale = 1;
        _protectionTimer = grabProtectionTime;
        _grabTimer = grabTime;
    }
}
