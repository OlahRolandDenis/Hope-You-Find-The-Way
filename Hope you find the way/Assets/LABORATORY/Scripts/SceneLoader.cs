using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadLevel() {
        SceneManager.LoadScene("Maze");
    }

    public void LoadPuzzle() {
        SceneManager.LoadScene("Shop");
    }

}
