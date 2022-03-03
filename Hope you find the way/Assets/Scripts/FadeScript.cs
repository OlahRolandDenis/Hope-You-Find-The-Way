using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class FadeScript : MonoBehaviour
{
   
    void Start()
    {
        Fade();
    }

   void Fade()
    {
        GetComponent<Image>().material.DOFade(0.0f, 2.0f); //trebuie revizuit
    }
}
