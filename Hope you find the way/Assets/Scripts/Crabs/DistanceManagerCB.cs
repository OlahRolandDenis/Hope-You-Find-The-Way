using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Unity;
using TMPro;

public class DistanceManagerCB : MonoBehaviour
{
    [SerializeField] private Transform crab;
    [SerializeField] private Transform player;

    [SerializeField] private GameObject dialogue_box;
    [SerializeField] private TextMeshProUGUI dialogue_text;

    public float dist;

    void Update() {
        CheckDistance();

        if ( dist <= 3 ) {
            dialogue_box.gameObject.SetActive( true );

            if ( SceneManager.GetActiveScene().name == "Puzzle" )
                dialogue_box.gameObject.GetComponent<RectTransform>().DOMoveY( -2f, 1f );

            if ( SceneManager.GetActiveScene().name == "Story" )
                dialogue_box.gameObject.GetComponent<RectTransform>().DOMoveY( 2f, 1f );

            StartCoroutine( WaitAndShowText() );
        }
    }

    void CheckDistance()
    {
        if ( crab && player ) {
            dist = Vector3.Distance(crab.position, player.position);
        } else {
            print("no player / crab");
        }
    }

    IEnumerator WaitAndShowText() {
        yield return new WaitForSeconds( 1.5f );
        dialogue_text.gameObject.SetActive( true );
    }
}
