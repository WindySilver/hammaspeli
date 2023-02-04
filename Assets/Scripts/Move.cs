using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    public float speed = 2.0f;
    public GameObject character;
    private bool isGrounded;
    private float jumpPower = 20f;
    private float jumpModifier = 0;
    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
	    rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
	    if (Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left* speed * Time.deltaTime;
		}
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			CheckIfOnTheGround();
			if (isGrounded)
			{
				//audio.Play();
				float jumpBoost = math.clamp(jumpModifier, 0f, 4f);
				rigidbody2d.AddForce(new Vector2(0f, jumpPower + jumpBoost), ForceMode2D.Impulse);
				isGrounded = false;
				jumpModifier = 0;
			}
		}
		// See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
		void CheckIfOnTheGround()
		{
			//Vector3 blw = transform.TransformDirection(Vector3.down);
			RaycastHit2D hitHead = Physics2D.Raycast(transform.position+ new Vector3(0.09f,0f,0), -Vector2.up);
			RaycastHit2D hitTail = Physics2D.Raycast(transform.position- new Vector3(0.09f,0f,0), -Vector2.up);
			float distanceHead = 90f;
			float distanceTail = 90f;
			if (hitHead.collider != null ){
				distanceHead= Mathf.Abs(transform.position.y -hitHead.point.y);
				Debug.DrawRay(transform.position+ new Vector3(0.09f,0f,0), new Vector2(0f,-0.45f), Color.green, 10f);
				Debug.DrawRay(transform.position- new Vector3(0.09f,0f,0), new Vector2(0f,-0.45f), Color.green, 10f);
			}
			if (hitTail.collider != null ){
				distanceTail= Mathf.Abs(transform.position.y -hitTail.point.y);
			}   
			if (distanceHead < 1f || distanceTail < 1f) isGrounded = true;
            
                    
			Debug.Log(isGrounded);
		}
    }
}