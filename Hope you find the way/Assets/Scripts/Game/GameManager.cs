using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void ExitToMenu() {
        SceneManager.LoadScene("Menu");
    }    
}
