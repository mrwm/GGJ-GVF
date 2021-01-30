using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuButtons : MonoBehaviour
{
    public Button btn_levels, btn_start;
    // Start is called before the first frame update
    void Start()
    {
        btn_start.onClick.AddListener(StartOnClick);
        btn_levels.onClick.AddListener(LevelsOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartOnClick()
    {
        Debug.Log("Start Button Pressed");
    }
    void LevelsOnClick()
    {
        SceneManager.LoadScene("Level Select");
    }
}
