using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderCB: MonoBehaviour
{
    private string INGREDIENT_NAME = "BAC";

    public void LoadLevel() {
        SceneManager.LoadScene("CrabsLevel");
    }

    public void LoadStory() {
        SceneManager.LoadScene("0");
    }

    public void LoadPuzzle() {
        SceneManager.LoadScene("CrabsPuzzle");
    }

    public void GoToLab() { 
        PlayerPrefs.DeleteKey("level 0" );
        PlayerPrefs.SetString("current_ingredient", INGREDIENT_NAME);
        SceneManager.LoadScene("Laborator");
    }

    public void SaveAndQuit() { 
        Application.Quit();
    }

}
