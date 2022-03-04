using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeTransition : MonoBehaviour
{

    [SerializeField] private Image img;
    [SerializeField] private GameObject img_parent;


    void Start()
    {
        Fade();
        StartCoroutine( WaitAndDisable() );
    }

    void Fade() {
        // GetComponent<MeshRenderer>().material.DOFade(0.0f, 1.5f);
        img.DOFade(0.0f, 1.5f);
    }

    void setActiveFalse() {
        img_parent.SetActive(false);
    }

    IEnumerator WaitAndDisable() {
        yield return new WaitForSeconds(1.5f);
        img_parent.SetActive(false);
    }

}