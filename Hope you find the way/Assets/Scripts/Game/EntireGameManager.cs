using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntireGameManager : MonoBehaviour
{
    
    public string[] levels = {
        "Crabs",
        "Carpark Maze"
    };

    public void setLevels() {
        for ( int i = 0; i < levels.Length; i++ ) {
            PlayerPrefs.SetString("level " + i, levels[i]);
        }
    }
    
}
