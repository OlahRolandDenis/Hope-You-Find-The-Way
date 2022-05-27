using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class DistanceManagerCM : MonoBehaviour
{
    
    [SerializeField] private Transform cashier;
    [SerializeField] private Transform player;

    [SerializeField] private Canvas dialogue_canvas;
    [SerializeField] private Image dialogue_bg;
    [SerializeField] private TextMeshProUGUI text;

    private float distance;

    void Update() {
        CheckDistance();

        if ( distance <= 4 )
            Dialogue();
    }

    void CheckDistance() {
        distance = Vector2.Distance( cashier.transform.position, player.transform.position );
    }

    void Dialogue() {
        dialogue_canvas.gameObject.SetActive( true );
        dialogue_bg.DOFade( 0.7f, 1.5f );

        StartCoroutine( ShowText() );
    }

    IEnumerator ShowText() {
        yield return new WaitForSeconds( 1.8f );
        text.gameObject.SetActive( true );
    }

}
