using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Finish", 0);
        gameObject.GetComponent<Button>().onClick.AddListener(NextScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextScene ()
    {
        SceneManager.LoadScene(1);
    }
}
