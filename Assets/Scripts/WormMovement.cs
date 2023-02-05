using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : MonoBehaviour
{
    private GameObject[] nodes1;
    // Start is called before the first frame update
    private GameObject node;
    private int nodeNmr;
    private float speed = 0.08f;
    private bool start;
    private int exitNodeNmr;
    private bool exiting;
    private EnemyHealthSystem _enemyHealthSystem;
    [SerializeField] private GameObject ranskalainen;

    private void Start()
    {
        StartCoroutine(StartDelay());
        GameObject rata = GameObject.Find("Rata");
        Rata rata1 = rata.GetComponent<Rata>();
        nodes1 = rata1.getNodes();
        node = nodes1[0];
        exitNodeNmr = rata1.getExitNodeNmr();
        _enemyHealthSystem = GetComponentInParent<EnemyHealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if(Vector3.Distance(node.transform.position,transform.position) < 0.1)
        {
            if (nodeNmr +1 != nodes1.Length - exitNodeNmr)
            {
                nodeNmr++;
            }
            else if(!_enemyHealthSystem.checkIfDead())
            {
                nodeNmr = 0;
            }
            else
            {
                exitNodeNmr = 0;
            }
            node = nodes1[nodeNmr];
        } 
            var step = speed; //* Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, node.transform.position, step);
        //Vector3 direction =  Vector3.RotateTowards(transform.forward, node.transform.position, 90, 90.0f);
        Vector3 targ = node.transform.position;
        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;
 
        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
       
    }
    private IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(1);
        start = true;
    }

    public void SetEnd()
    {
        exiting = true;
        if (ranskalainen != null)
        {
            ranskalainen.SetActive(false);
        }
    }

}
