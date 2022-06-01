using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderCB: MonoBehaviour
{
    public void LoadLevel() {
        SceneManager.LoadScene("CrabsLevel");
    }

    public void LoadStory() {
        SceneManager.LoadScene("CrabsStory");
    }

    public void LoadPuzzle() {
        SceneManager.LoadScene("CrabsPuzzle");
    }

    public void GoToLab() { 
        SceneManager.LoadScene("Laborator");
    }

    public void SaveAndQuit() { 
        Application.Quit();
    }

}
