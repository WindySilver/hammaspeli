using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel3 : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene("KurkkuScene");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("KurkkuScene"));
    }
}
