using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadGame(){
        SceneManager.LoadScene("VatsaScene");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("VatsaScene"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
