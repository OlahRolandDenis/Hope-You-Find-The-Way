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

    public void MakePotion() {
        potionBoiler.gameObject.GetComponent<Rigidbody2D>().DORotate( 360f, 2f );

        for ( int i = 0; i < ingredients.Count; i++ ){
            if ( !ingredients[i].activeSelf ) {

                foreach (Transform child in ingredients[i].gameObject.GetComponent<Transform>()) {
                    foreach (Transform ingredient_name in child.GetComponent<Transform>()) {
                        ingredient_name.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("current_ingredient");
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
