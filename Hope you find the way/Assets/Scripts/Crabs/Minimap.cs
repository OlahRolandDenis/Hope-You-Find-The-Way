using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{

    [SerializeField] private Transform player;

    void LateUpdate() {
        Vector2 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
