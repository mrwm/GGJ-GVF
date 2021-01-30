using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectButtons : MonoBehaviour
{
    public Button back, level1, level2, level3, level4;
    // Start is called before the first frame update
    void Start()
    {
        back.onClick.AddListener(backOnClick);
        level1.onClick.AddListener(leveloneOnClick);
        level2.onClick.AddListener(leveltwoOnClick);
        level3.onClick.AddListener(levelthreeOnClick);
        level4.onClick.AddListener(levelfourOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void backOnClick()
    {
        SceneManager.LoadScene("Main Menu");
        
    }
    void leveloneOnClick()
    {

    }
    void leveltwoOnClick()
    {

    }
    void levelthreeOnClick()
    {

    }
    void levelfourOnClick()
    {

    }
}
