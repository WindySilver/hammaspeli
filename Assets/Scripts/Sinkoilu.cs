using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;

public class Sinkoilu : MonoBehaviour
{
    public GameObject character;
    public SpriteRenderer arrow;
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
	private PlayerAudioHandler _audioHandler;
    [SerializeField] private GameObject aimPoint;
    
    public float speed = 2.0f;
    private bool isGrounded;
    private float jumpPower = 20f;
    private float jumpModifier = 0;
    private Rigidbody2D rigidbody2d;
    float smooth = 5.0f;
    float tiltAngle = 60.0f;
    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        _protectionTimer = grabProtectionTime;
        _grabTimer = grabTime;
        rigid = character.GetComponent<Rigidbody2D>();
        arrow.enabled = false;
		_audioHandler = GetComponent<PlayerAudioHandler>();
        //transform.forward = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            transform.position += Vector3.right * speed * Time.deltaTime;
            if(!_audioHandler.isPlaying) _audioHandler.PlaySquelch();
            if (_attached){
                _grabTimer -= Time.deltaTime;
        
                if(_protectionTimer > 0){
                    _protectionTimer -= Time.deltaTime;
                }
                else if((Input.anyKey && !(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))) || (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) || _grabTimer <= 0){
                    unGrab();
                }
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
            transform.position += Vector3.left* speed * Time.deltaTime;
            if(!_audioHandler.isPlaying)_audioHandler.PlaySquelch();
            if (_attached){
                _grabTimer -= Time.deltaTime;
        
                if(_protectionTimer > 0){
                    _protectionTimer -= Time.deltaTime;
                }
                else if((Input.anyKey && !(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))) || (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) || _grabTimer <= 0){
                    unGrab();
                }
            }
        }
        
        if (!_attached && rigid.velocity.y > 0 && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))){
            grabToCeiling();
        }
        /*
        if (_attached){
            _grabTimer -= Time.deltaTime;
        
            if(_protectionTimer > 0){
                _protectionTimer -= Time.deltaTime;
            }
            else if((Input.anyKey && !(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))) || (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) || _grabTimer <= 0){
                unGrab();
            }
        }
        

        if (Input.GetKeyUp(KeyCode.Space))
        {
            CheckIfOnTheGround();
            if (isGrounded)
            {
                Sinkouta2();
                isGrounded = false;
                _angle = 0;
            }
        }
        */
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CheckIfOnTheGround();
            if (isGrounded)
            {
                Sinkouta3();
                isGrounded = false;
                //_angle = 0;
            }
        }
    }

    // Turns the player around and makes it grab to the ceiling
    public void grabToCeiling(){
        _audioHandler.PlaySplat();
        _attached = true;
        character.transform.Rotate(0, 0, 180);
        rigid.gravityScale = 0;
        rigid.velocity = Vector2.zero;
        rigid.angularVelocity = 0;
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
        //if(!_audioHandler.isPlaying) _audioHandler.PlayAim();
        arrow.enabled = true;
        lDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * _angle), Mathf.Sin(Mathf.Deg2Rad * _angle), 0);


        if (forward && _angle < 90){
            lDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * _angle), Mathf.Sin(Mathf.Deg2Rad * _angle), 0);
            _angle = _angle + 1f;
        }
        else if(backwards && _angle > -90){
            lDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * _angle), Mathf.Sin(Mathf.Deg2Rad * _angle), 0);
            _angle = _angle - 1f;
        }
        else if(_angle == 90){
            forward = false;
            backwards = true;
        }
        else if(_angle == -90){
            forward = true;
            backwards = false;
        }
        //Debug.Log(lDirection);

        // Smoothly tilts a transform towards a target rotation.


        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(0, 0, _angle);

        // Dampen towards the target rotation
        arrow.transform.rotation = Quaternion.Slerp(arrow.transform.rotation, target,  Time.deltaTime * smooth);

    }
    void aimSinkous2(){
        //if(!_audioHandler.isPlaying) _audioHandler.PlayAim();
        arrow.enabled = true;
        if (forward){
            //lDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * _angle), Mathf.Sin(Mathf.Deg2Rad * _angle), 0);
            //lDirection = lDirection + new Vector3();
            _angle = _angle + 0.1f;
            //rotation = rotation + new Vector3(arrow.transform.rotation.x, arrow.transform.rotation.y, -0.1f);
            arrow.transform.Rotate(new Vector3(arrow.transform.rotation.x, arrow.transform.rotation.y, -0.1f));
        }
        else if(backwards){
            //lDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * _angle), Mathf.Sin(Mathf.Deg2Rad * _angle), 0);
            _angle = _angle - 0.1f;
            arrow.transform.Rotate(new Vector3(arrow.transform.rotation.x, arrow.transform.rotation.y,  +0.1f));
        }
        else if(_angle == 90){
            forward = false;
            backwards = true;
        }
        else if(_angle == -90){
            forward = true;
            backwards = false;
        }
        //Debug.Log(lDirection);

        // Smoothly tilts a transform towards a target rotation.
        //Vector3 rotationToAdd = new Vector3(0, 90, 0);

        //transform.Rotate(rotationToAdd);

        // Rotate the cube by converting the angles into a quaternion.
        //Quaternion target = Quaternion.Euler(0, 0, _angle);
        //transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);

        // Dampen towards the target rotation
        //arrow.transform.rotation = Quaternion.Slerp(arrow.transform.rotation, target,  Time.deltaTime * smooth);
        arrow.transform.Rotate(rotation);
    }

    void Sinkouta(){
        _audioHandler.PlayYippee();
        arrow.enabled = false;
        lDirection.y = Mathf.Abs(lDirection.y);
        if (!_attached) rigid.AddForce(lDirection*20, ForceMode2D.Impulse);
        else if (_attached) rigid.AddForce(lDirection*-20, ForceMode2D.Impulse);
        Debug.Log(lDirection*10);
    }
    
    void Sinkouta2(){
        //_audioHandler.PlayYippee();
        arrow.enabled = false;
        lDirection.y = Mathf.Abs(lDirection.y);
        //transform.position = Vector3.MoveTowards(transform.position, aimPoint.transform.position, 0.1f);
        rigid.AddForce(aimPoint.transform.position- transform.position, ForceMode2D.Impulse);
       /*
        Vector3 targ = aimPoint.transform.position;
        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;
 
        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        */
        //Debug.Log(lDirection*10);
    }
    
    void Sinkouta3(){
        _audioHandler.PlayYippee();
        
        Vector3 mousePos = Input.mousePosition;
        mousePos.z=Camera.main.nearClipPlane;
        Vector3 Worldpos=Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 Worldpos2D = new Vector2(Worldpos.x, Worldpos.y);
        Vector2 pos2D = new Vector2(transform.position.x, transform.position.y);
        float maxSpeed = 24;
        float forceX = Mathf.Clamp((Worldpos.x - transform.position.x) *3, -maxSpeed, maxSpeed);
        float forceY = Mathf.Clamp((Worldpos.y - transform.position.y) *3, -maxSpeed, maxSpeed);
        rigid.AddForce((new Vector2(forceX, forceY)), ForceMode2D.Impulse);
        //rigid.AddForce(((Worldpos2D - pos2D) *3), ForceMode2D.Impulse);
        transform.up = Worldpos2D - pos2D; 
        //Debug.Log(lDirection*10);
    }

    public void rebelDown()
    {
        Vector2 pos2D = new Vector2(transform.position.x, transform.position.y);
        //Vector2 down2D = new Vector2(transform.up.x, transform.up.y);
        rigid.AddForce(((Vector2.down - pos2D)), ForceMode2D.Impulse);
    }
    
    public void rebelUp()
    {
        Vector2 pos2D = new Vector2(transform.position.x, transform.position.y);
        //Vector2 down2D = new Vector2(transform.up.x, transform.up.y);
        rigid.AddForce(((Vector2.up - pos2D)), ForceMode2D.Impulse);
    }
    
    // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
    void CheckIfOnTheGround()
    {
        //Vector3 blw = transform.TransformDirection(Vector3.down);
        RaycastHit2D hitHead = Physics2D.Raycast(transform.position + new Vector3(0.09f, 0f, 0), -transform.up);
        RaycastHit2D hitTail = Physics2D.Raycast(transform.position - new Vector3(0.09f, 0f, 0), -transform.up);
        float distanceHead = 90f;
        float distanceTail = 90f;
        if (hitHead.collider != null)
        {
            distanceHead = Mathf.Abs(transform.position.y - hitHead.point.y);
            Debug.DrawRay(transform.position + new Vector3(0.09f, 0f, 0), new Vector2(0f, -0.45f), Color.green, 10f);
            Debug.DrawRay(transform.position - new Vector3(0.09f, 0f, 0), new Vector2(0f, -0.45f), Color.green, 10f);
        }

        if (hitTail.collider != null)
        {
            distanceTail = Mathf.Abs(transform.position.y - hitTail.point.y);
        }

        if (distanceHead < 1f || distanceTail < 1f)
        {
            isGrounded = true;
           // _audioHandler.PlaySplat();
        }
    }
}
