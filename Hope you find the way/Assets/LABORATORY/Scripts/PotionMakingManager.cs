using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PotionMakingManager : MonoBehaviour
{
    [SerializeField] private GameObject potionBoiler;
    [SerializeField] private List<GameObject> ingredients;

    public void MakePotion() {
        potionBoiler.gameObject.GetComponent<Rigidbody2D>().DORotate( 360f, 2f );

        for ( int i = 0; i < ingredients.Count; i++ ){
            if ( !ingredients[i].activeSelf ) {
                ingredients[i].SetActive( true );
                return; // comment
            }
        }
    }
}
