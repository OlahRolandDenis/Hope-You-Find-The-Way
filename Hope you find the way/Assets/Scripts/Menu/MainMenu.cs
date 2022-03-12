using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string firstlevel, menu;
    public GameObject OptionsScreen;
    private string levelToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;
    public void NewGameDialogYes()
    {
        SceneManager.LoadScene("Intro");
    }
    public void LoadGameDialogYes()
    {
        if(PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("Saved");
            SceneManager.LoadScene(levelToLoad);
            
        }
        else
        {
            noSavedGameDialog.SetActive(true);
        }

    }
    

    public void CloseGame()
    {
        SceneManager.LoadScene(menu);
    }
    public void OpenOptions()
    {
        OptionsScreen.SetActive(true);
    }
    public void CloseOptions()
    {
        OptionsScreen.SetActive(false);
    }
     public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
    
}
