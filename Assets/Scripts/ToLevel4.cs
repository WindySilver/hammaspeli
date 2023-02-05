using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel4 : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene("SuuScene");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("SuuScene"));
    }
}
