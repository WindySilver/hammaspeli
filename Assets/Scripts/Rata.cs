using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rata : MonoBehaviour
{
    [SerializeField] private GameObject[] nodes;

    public GameObject[] getNodes()
    {
        return nodes;
    }
}
