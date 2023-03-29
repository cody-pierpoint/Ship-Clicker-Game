using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string sceneName;

    public void Start()
    {
        sceneName = "Game";
    }



    // create a new method to be used by the buttons
    public void Play()
    {
        //load the game scene (use exact name of scene
        LoadScene();


    }


    //method to load different scenes.
    public void LoadScene()
    {
        //load scene with scene name
        SceneManager.LoadScene(sceneName);
    }    

    //Create method to quit game


    public void QuitGame()
    {
        //Quit the application.

    }    


}
