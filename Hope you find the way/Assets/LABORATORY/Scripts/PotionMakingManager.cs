using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class PotionMakingManager : MonoBehaviour
{
    [SerializeField] private GameObject potionBoiler;
    [SerializeField] private Button add_ingredient_button;
    [SerializeField] private List<GameObject> ingredients;

    void Start()
    {
       for ( int i = 0; i < ingredients.Count; i++ )
        {
            if ( PlayerPrefs.GetString("Ingredient " + (i+1) ) != "")
            {
                foreach (Transform child in ingredients[i].gameObject.GetComponent<Transform>()) {
                    foreach (Transform ingredient_name in child.GetComponent<Transform>()) {
                        ingredient_name.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("Ingredient " + (i+1));
                    }
                }

                ingredients[i].SetActive( true );
            }
        }
    }

    public void MakePotion() {
        potionBoiler.gameObject.GetComponent<Rigidbody2D>().DORotate( 360f, 2f );

        for ( int i = 0; i < ingredients.Count; i++ ){
            if ( !ingredients[i].activeSelf ) {
                foreach (Transform child in ingredients[i].gameObject.GetComponent<Transform>()) {
                    foreach (Transform ingredient_name in child.GetComponent<Transform>()) {
                        ingredient_name.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("current_ingredient");
                        PlayerPrefs.SetString("Ingredient " + (i+1), PlayerPrefs.GetString("current_ingredient"));
                        for ( int j = 0; j < ingredients.Count; j++) {
                            print( PlayerPrefs.GetString("Ingredient " + (j + 1)));
                        }
                    }
                }

                ingredients[i].SetActive( true );
                PlayerPrefs.DeleteKey("current_ingredient");
                add_ingredient_button.interactable = false;
                return; // comment
            }
        }
    }
}
