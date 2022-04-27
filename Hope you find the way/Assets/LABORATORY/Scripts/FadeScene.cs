using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class FadeScene : MonoBehaviour
{
    
    [SerializeField] private Canvas image_parent;
    [SerializeField] private Image image;

    void Start() {
        FadeOut();
    }

    private void FadeOut() {
        image.DOFade(0f, 1f);
        StartCoroutine( SetCanvas( 1f, false ) );
    }

    public void FadeIn() {
        StartCoroutine( SetCanvas( 0f, true ) );
        image.DOFade( 1f, 0.5f );
    }

    IEnumerator SetCanvas( float time, bool active ) {
        yield return new WaitForSeconds( time );
        image_parent.gameObject.SetActive( active );
    }
}
