using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlotCB: MonoBehaviour
{

    [SerializeField] private List<GameObject> placingSlots = new List<GameObject>();
    
    // for complete puzzle
    [SerializeField] private GameObject Puzzle;
    [SerializeField] private GameObject Complete;
    [SerializeField] private GameObject Fail;

    private string INGREDIENT_NAME = "BAC";
    private string INGREDIENT_FOUND = "";
    private string[] lettersInOrder = new string[3];

    private bool alreadyLetter;

    void OnTriggerEnter2D( Collider2D collider ) {
        BuildName( collider.gameObject, gameObject );
        if ( !alreadyLetter ){
            collider.gameObject.GetComponent<DragCB>().isPlaced = true;
            collider.gameObject.GetComponent<Transform>().parent = transform;
            collider.gameObject.GetComponent<DragCB>().dragging = false;
            collider.gameObject.GetComponent<Transform>().position = transform.position;
            gameObject.name = collider.gameObject.name;
        }
    }

    public void BuildName( GameObject placedLetter, GameObject slot ) {
        if ( slot.transform.childCount > 0 ) {
            alreadyLetter = true; 
            return;
        } else
            alreadyLetter = false;
        
    }

    public void CheckIngredient() {
        for ( int i = 0; i < placingSlots.Count; i++ ) {
            lettersInOrder[i] = placingSlots[i].gameObject.name;
        }

        for ( int i = 0; i < lettersInOrder.Length; i++ ) {
            INGREDIENT_FOUND += lettersInOrder[i];
        }

        if ( INGREDIENT_FOUND == INGREDIENT_NAME )
            CompletePuzzle();
        else
            FailPuzzle();
    }

    private void CompletePuzzle() {
        Puzzle.SetActive( false );
        Complete.SetActive( true );
    }

    private void FailPuzzle() {
        Puzzle.SetActive( false );
        Fail.SetActive( true );
    }


    public void GoToLab() {
        print("going to lab!");
    }
  
    public void SaveAndQuit() {
        print("quitting!");
    }

    public void TryAgain() {
        SceneManager.LoadScene("Puzzle");
    }

}
