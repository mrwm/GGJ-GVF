using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectButtons : MonoBehaviour
{
    public Button back, level1, level2, level3, level4;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        back.onClick.AddListener(backOnClick);
        level1.onClick.AddListener(leveloneOnClick);
        level2.onClick.AddListener(leveltwoOnClick);
        level3.onClick.AddListener(levelthreeOnClick);
        level4.onClick.AddListener(levelfourOnClick);
        gm = GameManager.getManager();
    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void backOnClick()
    {
        SceneManager.LoadScene((int)SceneIndexes.MAINMENU);
        
    }
    void leveloneOnClick()
    {
        gm.setScene(SceneIndexes.GAME);
        gm.setLevel(LevelIndexes.LVONE);
        SceneManager.LoadScene((int)SceneIndexes.LOADING);
        
    }
    void leveltwoOnClick()
    {
        gm.setScene(SceneIndexes.GAME);
        gm.setLevel(LevelIndexes.LVTWO);
        SceneManager.LoadScene((int)SceneIndexes.LOADING);

    }
    void levelthreeOnClick()
    {
        gm.setScene(SceneIndexes.GAME);
        gm.setLevel(LevelIndexes.LVTHREE);
        SceneManager.LoadScene((int)SceneIndexes.LOADING);

    }
    void levelfourOnClick()
    {
        gm.setScene(SceneIndexes.GAME);
        gm.setLevel(LevelIndexes.LVFOUR);
        SceneManager.LoadScene((int)SceneIndexes.LOADING);

    }
}
