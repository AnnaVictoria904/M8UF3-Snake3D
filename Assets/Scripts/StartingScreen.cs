using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartingScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestText;
    [SerializeField] private Toggle multiplayerMode;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Multiplayer", 0);
        bestText.text = "Best Score: " + PlayerPrefs.GetInt("BestScore");
        if (Application.isEditor)
        {
            multiplayerMode.gameObject.SetActive(true);
        }
    }
    public void playerModeChange(bool flag)
    {
        if (multiplayerMode.isOn)
        {
            PlayerPrefs.SetInt("Multiplayer", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Multiplayer", 0);
        }
    }
}
