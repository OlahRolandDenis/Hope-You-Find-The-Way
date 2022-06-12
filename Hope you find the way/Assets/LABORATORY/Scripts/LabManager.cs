using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LabManager : MonoBehaviour
{
    
    [SerializeField] private GameObject potionEntry, portalEntry, player, portal, potionBoiler;
    [SerializeField] private Canvas potionMakingCanvas, portalQuestionCanvas, noMoreLevels;
    private float portal_distance, boiler_distance;

    void Update() {

        GetDistance();

        if ( portal_distance <= 2f )
            DisablePortal();

        if ( portal_distance <= 0.5f )
            OpenPortalQuestion();

        if ( boiler_distance <= 2f  )
            DisablePotion();

    }

    void DisablePotion() {
        potionEntry.gameObject.SetActive( false );
        EnablePotion();
    }

    void DisablePortal() {
        portalEntry.gameObject.SetActive( false );
        EnablePortal();
    }

    public void EnablePotion() {
        StartCoroutine( WaitAndEnablePotion() );
    }

    IEnumerator WaitAndEnablePotion() {
        yield return new WaitForSeconds( 30f );
        potionEntry.gameObject.SetActive( true );
    }

    public void EnablePortal() {
        StartCoroutine( WaitAndEnablePortal() );
    }

    IEnumerator WaitAndEnablePortal() {
        yield return new WaitForSeconds( 30f );
        portalEntry.gameObject.SetActive( true );
    }

    private void GetDistance() {
        portal_distance = Vector2.Distance( portalEntry.transform.position, player.transform.position );
        boiler_distance = Vector2.Distance( potionEntry.transform.position, player.transform.position );
    }

    public void OpenPotionMaking() {
        potionMakingCanvas.gameObject.SetActive( true );
    }

    private void OpenPortalQuestion() {
        portal.transform.DOScale( new Vector3( 10f, 4f, 0f ), 1f );
        // portalQuestionCanvas.gameObject.SetActive( true );
    }

    public void ScaleBackPortal() {
        portal.transform.DOScale( new Vector3( 6f, 2f, 0f), 1f );
    }

    public void NextLevel() {
        for ( int i = 0; i < 3; i++ ) {
            if ( PlayerPrefs.HasKey("level " + i ) ) {
                SceneManager.LoadScene( "" + i );
                return;
            } else {
                print( "no level " + i );
                noMoreLevels.gameObject.SetActive( true );
                portalQuestionCanvas.gameObject.SetActive( false );
            }
        }
    }

}
