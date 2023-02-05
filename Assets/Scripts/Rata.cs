using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rata : MonoBehaviour
{
    [SerializeField] private GameObject[] nodes;
    [SerializeField] private int ExitnodeNmr;

    public GameObject[] getNodes()
    {
        return nodes;
    }
    
    public int getExitNodeNmr()
    {
        return ExitnodeNmr;
    }
}
