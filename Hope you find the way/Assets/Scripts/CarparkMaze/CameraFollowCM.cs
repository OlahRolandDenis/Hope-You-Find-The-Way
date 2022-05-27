using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCM : MonoBehaviour
{
    
    [SerializeField] private Transform target;

    void LateUpdate() {
        transform.position = new Vector3( target.position.x, target.position.y, -10 );
    }

}
