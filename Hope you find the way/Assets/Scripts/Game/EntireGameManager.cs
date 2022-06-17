using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntireGameManager : MonoBehaviour
{
    
    public string[] levels = {
        "Crabs",
        "Carpark Maze"
    };

    public string[] ingredients = {
        "",
        ""
    };

    public void setIngredients()
    {
        for ( int i = 0; i < ingredients.Length; i++ ) { 
            PlayerPrefs.SetString("Ingredient " + (i + 1), ingredients[i] );
        }
    }

    public void setLevels() {
        for ( int i = 0; i < levels.Length; i++ ) {
            PlayerPrefs.SetString("level " + i, levels[i]);
        }
    }
}
