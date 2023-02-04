using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] nodes1;
    // Start is called before the first frame update
    private GameObject node;
    private int nodeNmr;
    private float speed = 10;

    private void Start()
    {
        node = nodes1[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(node.transform.position,transform.position) < 0.1)
        {
            if (nodeNmr +1 != nodes1.Length)
            {
                nodeNmr++;
            }
            else
            {
                nodeNmr = 0;
            }
            node = nodes1[nodeNmr];
        }
        var step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, node.transform.position, step);
    }
}
