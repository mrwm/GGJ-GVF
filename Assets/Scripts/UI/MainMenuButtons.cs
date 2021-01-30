using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuButtons : MonoBehaviour
{
    public Button btn_start;
    // Start is called before the first frame update
    void Start()
    {
        btn_start.onClick.AddListener(StartOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartOnClick()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
