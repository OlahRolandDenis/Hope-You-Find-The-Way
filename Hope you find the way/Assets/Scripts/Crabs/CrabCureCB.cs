using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CrabCureCB : MonoBehaviour
{
    [SerializeField] GameObject letter_A;
    [SerializeField] GameObject letter_B;

    [SerializeField] GameObject letter_C;
    // [SerializeField] GameObject letter_D;
    // [SerializeField] GameObject letter_E;
    // [SerializeField] GameObject letter_F;

    [SerializeField] private GameObject slots;

    public char current_letter;
    private Camera mainCamera;

    private void Awake() {
        mainCamera = Camera.main;
    }

    void Update() {
        DetectClick();
    }

    private void DetectClick() {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hits = Physics2D.GetRayIntersection(ray);

        if ( hits.collider && hits.collider.tag == "Crab" ) {
            if ( Input.GetMouseButton(0) ) {
                hits.collider.gameObject.GetComponent<SpriteRenderer>().DOFade(0f, 1f);
                hits.collider.gameObject.GetComponent<CrabMovementCB>().enabled = false;
                
                switch ( hits.collider.gameObject.name ) {
                    case "Crab 1":
                        letter_A.GetComponent<Transform>().DOScale(1f, 1f);
                        current_letter = 'A';
                        break;

                    case "Crab 2":
                        letter_B.GetComponent<Transform>().DOScale(1f, 1f);
                        current_letter = 'B';
                        break;

                    case "Crab 3":
                        letter_C.GetComponent<Transform>().DOScale(1f, 2f);
                        current_letter = 'C';
                        break;
                }
            }

            if ( Input.GetMouseButtonDown(1) ) {
                
                switch ( current_letter ) {
                    case 'A':
                        slots.GetComponent<CollectLettersCB>().Collect("A");
                        Destroy( letter_A.gameObject );
                        break;

                    case 'B':
                        slots.GetComponent<CollectLettersCB>().Collect("B");
                        Destroy( letter_B.gameObject );
                        break;

                    case 'C':
                        slots.GetComponent<CollectLettersCB>().Collect("C");
                        Destroy( letter_C.gameObject );
                        break;
                }

            }
                
        }
    }

}
