using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;

public class Sinkoilu : MonoBehaviour
{
    public GameObject character;
    public Image arrow;
    public float grabProtectionTime = 0.2f;
    public float grabTime = 5.0f;
    private bool _attached = false;
    private float _protectionTimer;
    private float _grabTimer;
    private Rigidbody2D rigid;
    private float _angle = 0;
    private bool forward = false;
    private bool backwards = true;
    private Vector3 lDirection;


    // Start is called before the first frame update
    void Start()
    {
        _protectionTimer = grabProtectionTime;
        _grabTimer = grabTime;
        rigid = character.GetComponent<Rigidbody2D>();
        arrow.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_attached && rigid.velocity.y > 0 && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))){
            grabToCeiling();
        }

        if (_attached){
            _grabTimer -= Time.deltaTime;
        
            if(_protectionTimer > 0){
                _protectionTimer -= Time.deltaTime;
            }
            else if((Input.anyKey && !(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))) || (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) || _grabTimer <= 0){
                unGrab();
            }
        }

        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
            aimSinkous();
        }

        if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)){
            Sinkouta();
        }
    }

    // Turns the player around and makes it grab to the ceiling
    void grabToCeiling(){
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

    void aimSinkous(){
        arrow.enabled = true;
        lDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * _angle), Mathf.Sin(Mathf.Deg2Rad * _angle), 0);
        
            if (forward && _angle < 180){
                lDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * _angle), Mathf.Sin(Mathf.Deg2Rad * _angle), 0);
                _angle = _angle + 0.5f;
            }
            else if(backwards && _angle > -180){
                lDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * _angle), Mathf.Sin(Mathf.Deg2Rad * _angle), 0);
                _angle = _angle - 0.5f;
            }
            else if(_angle == 180){
                forward = false;
                backwards = true;
            }
            else if(_angle == -180){
                forward = true;
                backwards = false;
            }
            //Debug.Log(lDirection);

        if(_angle % 10 == 0){
            arrow.transform.Rotate(0, 0, _angle);
        }
    }

    void Sinkouta(){
        arrow.enabled = false;
        lDirection.y = Mathf.Abs(lDirection.y);
        if (!_attached) rigid.AddForce(lDirection*10, ForceMode2D.Impulse);
        else if (_attached) rigid.AddForce(lDirection*-10, ForceMode2D.Impulse);
        Debug.Log(lDirection*10);
    }
}
