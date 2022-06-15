using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PuzzleManagerCM : MonoBehaviour
{

    [SerializeField] private Canvas puzzleCanvas, queryCanvas, wonCanvas, failedCanvas;
    [SerializeField] private GameObject player, cashier;

    [SerializeField] private GameObject generated_potion;
    [SerializeField] private TextMeshProUGUI generated_potion_text;

    [SerializeField] private List<GameObject> potions;

    private string INGREDIENT_NAME = "pink";
    private string GENERATED_POTION;

    public void StartPuzzle() {
        queryCanvas.gameObject.SetActive( false );
        player.gameObject.SetActive( false );
        cashier.gameObject.SetActive( false );
        puzzleCanvas.gameObject.SetActive( true );

        GeneratePotion();
    }

    public void GeneratePotion() {
        var index = Random.Range( 0, potions.Count );
        generated_potion_text.text = potions[index].name;
        generated_potion.GetComponent<SpriteRenderer>().sprite = potions[index].gameObject.GetComponent<SpriteRenderer>().sprite;

        GENERATED_POTION = generated_potion_text.text;
    }

    public void CheckIngredient() {
        if ( GENERATED_POTION == INGREDIENT_NAME )
            Win();    
        else
            Lose();

        puzzleCanvas.gameObject.SetActive( false );
    }

    private void Win() {
        wonCanvas.gameObject.SetActive( true );
    }

    private void Lose() {
        failedCanvas.gameObject.SetActive( true );
    }


    // for testing only
    public void GoToLab() {
        PlayerPrefs.DeleteKey( "level 1" );
        PlayerPrefs.SetString("current_ingredient", INGREDIENT_NAME.ToUpper() );
        SceneManager.LoadScene("Laborator");
    }

    public void SaveAndQuit() {
        Application.Quit();
        print("quitting");
    }
}
