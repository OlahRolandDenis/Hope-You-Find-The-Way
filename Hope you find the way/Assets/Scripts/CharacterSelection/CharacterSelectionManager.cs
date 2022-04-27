using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterSelectionManager : MonoBehaviour
{
    
    [SerializeField] private List<Sprite> girls, boys;
    [SerializeField] private GameObject selected_skin;

    [SerializeField] private TMP_InputField player_name; 

    [SerializeField] private Button done_button;

    private List<Sprite> current_gender;

    private int index = 0;

    void Update() {
        if ( selected_skin.GetComponent<SpriteRenderer>().sprite != null && player_name.text != "" )
            done_button.interactable = true;
    }

    void ChangeGender( string gender ) {
        index = 0;

        switch ( gender ) {
            case "boys":
                current_gender = boys;
                break;

            case "girls":
                current_gender = girls;
                break;
        }

        ChangeSkin();
    }

    public void ShowGirls() {
        ChangeGender( "girls" );
    }

    public void ShowBoys() {
        ChangeGender( "boys" );
    }

    void ChangeSkin() {
        selected_skin.GetComponent<SpriteRenderer>().sprite = current_gender[0];
        index = 0;
    }

    public void NextSkin() {
        index += 1;

        if ( index >= current_gender.Count ) {
            index = 0;
            selected_skin.GetComponent<SpriteRenderer>().sprite = current_gender[0];
            return;
        }

        selected_skin.GetComponent<SpriteRenderer>().sprite = current_gender[ index ];
    }

    public void PreviousSkin() {
        index -= 1;

        if ( index < 0 ) {
            index = current_gender.Count - 1;
            selected_skin.GetComponent<SpriteRenderer>().sprite = current_gender[ current_gender.Count - 1 ];;
            return;
        }

        selected_skin.GetComponent<SpriteRenderer>().sprite = current_gender[ index ];
    }

    public void Save() {
        
        selected_skin.name = player_name.text;

        PrefabUtility.SaveAsPrefabAsset( selected_skin, "Assets/Prefabs/Player.prefab" );
        PlayerPrefs.SetString("name", player_name.text );

        SceneManager.LoadScene("Laborator");

    }

}
