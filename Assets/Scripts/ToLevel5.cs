using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToLevel5 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    void OnCollisionEnter2D(Collision2D collision)
    {
        _text.text = "You Won!";
    }
}
