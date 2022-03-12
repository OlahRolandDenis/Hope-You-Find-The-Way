using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class IntroScript : MonoBehaviour
{

    [SerializeField] private List<Image> intro_images = new List<Image>();
    private int image_index = -1;

    private string nextScene = "CharacterSelection";
    public void SkipIntro() {
        SceneManager.LoadScene(nextScene);
    }

    public void NextImage() {
        if ( image_index == intro_images.Count - 1 ){
            SkipIntro();
            return;
        }

        image_index += 1;
        var tempColor = intro_images[image_index].color;
        tempColor.a = 1;
        intro_images[image_index].color = tempColor;
    }
}
