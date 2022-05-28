using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerCB : MonoBehaviour
{
    
    [SerializeField] private Canvas inventory_canvas;
    [SerializeField] private Canvas minimap;

    void Update() {
        if ( Input.GetKeyDown(KeyCode.Tab) )
            if ( !inventory_canvas.gameObject.activeInHierarchy )
                ToggleInventory( true );
            else
                ToggleInventory( false );
    }   

    private void ToggleInventory( bool active) {
        inventory_canvas.gameObject.SetActive( active );
        minimap.gameObject.SetActive( !active );
    }

}
