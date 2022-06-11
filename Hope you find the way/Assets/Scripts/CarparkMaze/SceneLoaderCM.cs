using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderCM : MonoBehaviour
{
    public void LoadLevel() {
        SceneManager.LoadScene("1");
    }

    public void LoadPuzzle() {
        SceneManager.LoadScene("Shop");
    }

}
