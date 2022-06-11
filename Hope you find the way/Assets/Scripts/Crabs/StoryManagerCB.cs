using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;
public class StoryManagerCB : MonoBehaviour
{
    
    private string readFromFilePath;
    public List<string> dialogue;

    void Start() {
        // LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
        // print( LocalizationSettings.SelectedLocale );
    }

    public void SetStory() {
        if ( SceneManager.GetActiveScene().name == "0")
            if ( Application.systemLanguage == SystemLanguage.Romanian )
                readFromFilePath = Application.streamingAssetsPath + "/Recall_Chat/" + "ChatCrabsStoryRO" + ".txt";
            else
                readFromFilePath = Application.streamingAssetsPath + "/Recall_Chat/" + "ChatCrabsStoryEN" + ".txt";

        if ( SceneManager.GetActiveScene().name == "CrabsPuzzle" )
            if ( Application.systemLanguage == SystemLanguage.Romanian )
                readFromFilePath = Application.streamingAssetsPath + "/Recall_Chat/" + "ChatCrabsPuzzleRO" + ".txt";
            else
                readFromFilePath = Application.streamingAssetsPath + "/Recall_Chat/" + "ChatCrabsPuzzleEN" + ".txt";

        if ( SceneManager.GetActiveScene().name == "Puzzle")
            if( Application.systemLanguage == SystemLanguage.Romanian )
                readFromFilePath = Application.streamingAssetsPath + "/Recall_Chat/" + "ChatPuzzleRO" + ".txt";
            else
                readFromFilePath = Application.streamingAssetsPath + "/Recall_Chat/" + "ChatPuzzleEN" + ".txt";

        dialogue = File.ReadAllLines( readFromFilePath ).ToList();
    }

}
