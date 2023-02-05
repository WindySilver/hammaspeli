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
        SceneManager.LoadScene("SuoliScene");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("SuoliScene"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
