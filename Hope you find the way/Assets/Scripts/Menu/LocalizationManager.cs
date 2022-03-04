using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public class LocalizationManager : MonoBehaviour
{
    [SerializeField] private Button selectLanguage;

    // these will change the language button's image
    [SerializeField] private Sprite ro_button_image;
    [SerializeField] private Sprite en_button_image;
    [SerializeField] private GameObject ro;
    [SerializeField] private GameObject en;

    private void Start() {
        if ( LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0] ) {
            selectLanguage.image.sprite = en_button_image;
        } else {
            selectLanguage.image.sprite = ro_button_image;
        }
    }

    public void ToggleActive() {
        bool isActive = ro.activeSelf;  // if the ro button is inactive, the en button is also

        // toggles the activity of both of them
        ro.SetActive(!isActive);      
        en.SetActive(!isActive);
    }

    public void changeToRo() {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
        selectLanguage.image.sprite = ro_button_image;
        ToggleActive();
    }

    public void changeToEn() {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
        selectLanguage.image.sprite = en_button_image;
    }
}