using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetPlayerName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("name");

    }

}
