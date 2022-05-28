using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowParentCB : MonoBehaviour
{
    
    [SerializeField] private Transform cured_crab;
    [SerializeField] private Transform parent;

    void Start()
    {
        cured_crab.position = parent.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cured_crab.position = parent.position;
    }
}
