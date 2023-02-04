using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumplingPlatform : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"));
        StartCoroutine(destroyDelay());
    }
    
    private IEnumerator destroyDelay()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(spawnDelay());
    }
    
    private IEnumerator spawnDelay()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(5);
        gameObject.GetComponent<Renderer>().enabled = true;
    }
}
