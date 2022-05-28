using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;
public class StoryManagerCM : MonoBehaviour
{
    
    private string readFromFilePath;
    public List<string> dialogue;

    public void SetStory() {
        if ( SceneManager.GetActiveScene().name == "Story")
            if ( Application.systemLanguage == SystemLanguage.Romanian )
                readFromFilePath = Application.streamingAssetsPath + "/Recall_Chat/" + "ChatRO" + ".txt";
            else
                readFromFilePath = Application.streamingAssetsPath + "/Recall_Chat/" + "ChatEN" + ".txt";
        if ( SceneManager.GetActiveScene().name == "Puzzle" || SceneManager.GetActiveScene().name == "Shop")
            if( Application.systemLanguage == SystemLanguage.Romanian )
                readFromFilePath = Application.streamingAssetsPath + "/Recall_Chat/" + "ChatPuzzleRO" + ".txt";
            else
                readFromFilePath = Application.streamingAssetsPath + "/Recall_Chat/" + "ChatPuzzleEN" + ".txt";

        if ( SceneManager.GetActiveScene().name == "ShopCM" )
            if ( Application.systemLanguage == SystemLanguage.Romanian )
                readFromFilePath = Application.streamingAssetsPath + "/Recall_Chat/" + "ChatPuzzleRO" + ".txt";
            else
                readFromFilePath = Application.streamingAssetsPath + "/Recall_Chat/" + "ChatPuzzleEN" + ".txt";


        dialogue = File.ReadAllLines( readFromFilePath ).ToList();
    }

}
