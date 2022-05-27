using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class DialogueManagerCM : MonoBehaviour
{
    
    [SerializeField] private Canvas dialogue_canvas;
    [SerializeField] private GameObject distance_manager;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Canvas queryCanvas;

    private StoryManagerCM storyManager;

    private int phrase_index = -1;
    private List<string> dialogue;

    void Start() {
        storyManager = gameObject.GetComponent<StoryManagerCM>();
        storyManager.SetStory();
        dialogue = storyManager.dialogue;
    }

    public void NextPhrase() {
        phrase_index += 1;

        if ( phrase_index >= dialogue.Count ) {
            distance_manager.gameObject.GetComponent<DistanceManagerCM>().enabled = false;
            dialogue_canvas.gameObject.SetActive( false );
            queryCanvas.gameObject.SetActive( true );
            return;
        }

        text.text = dialogue[ phrase_index ];
    }
}
