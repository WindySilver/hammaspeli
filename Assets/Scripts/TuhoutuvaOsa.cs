using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuhoutuvaOsa : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }
}
