using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCB : MonoBehaviour {

    // vars
    private Vector2 offset, originalPosition;
    public bool dragging, isPlaced = false;

    void Awake() {
        originalPosition = transform.position;
    }

    void Update() {

        if ( !dragging ) return; // only run this function is dragging

        var mousePosition = GetMousePos();
        transform.position = mousePosition - offset; // makes sure that the dragged object does not snap into position
    }
   
    void OnMouseDown() {
        dragging = true;
        offset = GetMousePos() - (Vector2)transform.position;
        // print( dragging );
    }

    void OnMouseUp() {
        if ( !isPlaced )
            transform.position = originalPosition;
        dragging = false;
    }

    Vector2 GetMousePos() {
        return Camera.main.ScreenToWorldPoint( Input.mousePosition );
    }

}
