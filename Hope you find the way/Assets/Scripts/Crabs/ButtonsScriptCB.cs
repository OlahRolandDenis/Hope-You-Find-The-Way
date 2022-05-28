using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ButtonsScriptCB : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI collected_text;
    [SerializeField] private Button this_button;

    void Update()
    {
        if ( collected_text.gameObject.activeSelf )
            this_button.interactable = true;
    }
}
