using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class FadeSceneCB : MonoBehaviour
{
    
    [SerializeField] private Canvas image_parent;
    [SerializeField] private Image image;

    [SerializeField] private Canvas minimap;

    private Scene current_scene;

    void Start() {
        current_scene = SceneManager.GetActiveScene();
        Fade();
        StartCoroutine( WaitandDisable() );
    }

    private void Fade() {
        image.DOFade(0f, 3f);
    }

    IEnumerator WaitandDisable() {
        yield return new WaitForSeconds( 3f );
        image_parent.gameObject.SetActive( false );

        if ( current_scene.name != "Puzzle" )
            minimap.gameObject.SetActive( true );
    }
}
