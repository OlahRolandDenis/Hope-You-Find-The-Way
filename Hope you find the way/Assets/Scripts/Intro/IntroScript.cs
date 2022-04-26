using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class IntroScript : MonoBehaviour
{

    [SerializeField] private List<Image> intro_images = new List<Image>();
    [SerializeField] private TextMeshProUGUI current_phrase;
    private int image_index = -1;
    private int phrase_index = -1;

    private string[] phrases;
    private string[] phrases_ro = {
        "Anul 2040...",
        "viata pe pământ este acum un coșmar devenit realitate.",
        "în ultimul an virusul a preluat frâiele conducerii planetei cauzând câteva miliarde de morți",
        "dacă exista o persoana care poate găsi leacul, tu ești aceea. trebuie sa duci la capăt misiunea începută de tatăl tău, dar ai grija nimic nu e ceea ce pare."
    };

    private string[] phrases_en = {
        "Year 2040...",
        "Life on Earth is now a real nightmare",
        "In the last year, the virus has taken over the world and caused milions of deaths.",
        "If there is a person who can find the cure, that is you. You need to complete your father's mission and save the world!"
    };

    private void Start() {
        
        if ( Application.systemLanguage == SystemLanguage.English )
            phrases = phrases_en;
        else
            phrases = phrases_ro;

    }

    private string nextScene = "CharacterSelection";
    public void SkipIntro() {
        SceneManager.LoadScene(nextScene);
    }

    public void NextImage() {
        current_phrase.DOFade(0, 0);

        if ( image_index == intro_images.Count - 1 ){
            SkipIntro();
            return;
        }

        image_index += 1;
        // var tempColor = intro_images[image_index].color;
        // tempColor.a = 1;
        // intro_images[image_index].color = tempColor;

        intro_images[image_index].DOFade(1, 0.5f);

        phrase_index += 1;
        current_phrase.text = phrases[phrase_index];
        current_phrase.DOFade(1, 1);
    }
}
