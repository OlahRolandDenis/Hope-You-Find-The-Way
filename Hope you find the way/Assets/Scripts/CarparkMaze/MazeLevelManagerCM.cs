using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeLevelManagerCM : MonoBehaviour
{
    
    [SerializeField] private Transform target;
    [SerializeField] private Transform player;

    void Update() {
        if ( player.position.x >= target.position.x ){
            gameObject.GetComponent<FadeSceneCM>().FadeIn();
            StartCoroutine( GoToShop() );
        }
    }

    IEnumerator GoToShop() {
        yield return new WaitForSeconds( 0.5f );
        SceneManager.LoadScene("ShopCM");
    }

}
