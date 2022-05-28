using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CollectLettersCB : MonoBehaviour
{

    [SerializeField] private List<TextMeshProUGUI> slots;
    [SerializeField] private TextMeshProUGUI alert_collected;

    [SerializeField] private GameObject crab_script;    // reference to CrabCure.cs

    public void Collect(string letter) {
        for ( int i = 0; i < slots.Count; i++ ) {
            if ( slots[i].text == "" ) {    // checks if the slot is empty
                slots[i].text = letter;
                if ( i == slots.Count - 1 )
                    GoToPuzzle();
                return;
            }
        }
    }

    public void GoToPuzzle() {
        alert_collected.gameObject.SetActive( true );
    }

}
