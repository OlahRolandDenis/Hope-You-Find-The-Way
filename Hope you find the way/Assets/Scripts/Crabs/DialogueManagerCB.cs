using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// using UnityEngine.Localization.Settings;
using System.IO;
using System.Linq;
using TMPro;
using DG.Tweening;

public class DialogueManagerCB : MonoBehaviour
{
    
    [SerializeField] private GameObject distance;
    [SerializeField] private GameObject dialogue_box;
    [SerializeField] private TextMeshProUGUI dialogue_text;

    [SerializeField] private GameObject go_further_box;
    [SerializeField] private Canvas PuzzleCanvas;
    [SerializeField] private Image PuzzleImage;

    private Scene current_scene;

    // public string[] dialogue;

    private int phrase_index = 0;

    private StoryManagerCB storyManager;
    private List<string> dialogue;

    void Start() {
        current_scene = SceneManager.GetActiveScene();
        storyManager = gameObject.GetComponent<StoryManagerCB>();
        storyManager.SetStory();
        dialogue = storyManager.dialogue;

        dialogue_text.text = dialogue[0];
    }

    public void NextPhrase() {
        if ( phrase_index == dialogue.Count - 1  ) {
            distance.GetComponent<DistanceManagerCB>().enabled = false;

            if ( current_scene.name == "CrabsPuzzle" )
                StartPuzzle();

            if ( current_scene.name == "CrabsStory")
                GoFurther();

            return;
        }

        phrase_index += 1;
        dialogue_text.text = dialogue[ phrase_index ];
    }

    private void GoFurther() {
        // dialogue_box.SetActive( false );
        dialogue_box.GetComponent<RectTransform>().DOMoveY( -10f, 1f );
        go_further_box.GetComponent<RectTransform>().DOMoveY( 3.5f, 1f );
    }

    private void StartPuzzle() {
        // puzzle fade in
        dialogue_box.SetActive( false );
        PuzzleCanvas.gameObject.SetActive( true );
        PuzzleImage.DOFade( 0.65f, 1f );
    }

}
