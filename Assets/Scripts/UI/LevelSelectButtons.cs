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
        initializeLevels();
        back.onClick.AddListener(backOnClick);
        updateLevels(GameManager.getUnlockedLevels());
        gm = GameManager.getManager();
    }
    private void Awake()
    {
        
    }
    public void initializeLevels(){
       level1.interactable = false;
       level2.interactable = false;
       level3.interactable = false;
       level4.interactable = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateLevels(int[] levels){

       for (int i = 0; i < levels.Length -1; i++)
        {
           if(levels[i] == 1) {
             activateLevel(i+1);
           }
        }
    }
    
     public void activateLevel(int number){
      switch (number) 
      {
       case 1:
        level1.interactable = true;
        level1.onClick.AddListener(leveloneOnClick);
        break;
       case 2:
        level2.interactable = true;
        level2.onClick.AddListener(leveloneOnClick);
        break;
        case 3:
        level3.interactable = true;
        level3.onClick.AddListener(leveloneOnClick);
        break;
       case 4:
        level4.interactable = true;
        level4.onClick.AddListener(leveloneOnClick);
        break;
      } 
    }

    void backOnClick()
    {
        SceneManager.LoadScene((int)SceneIndexes.MAINMENU);
        
    }
    void leveloneOnClick()
    {
        gm.setScene(SceneIndexes.GAME);
        gm.setLevel((int)1);
        SceneManager.LoadScene((int)SceneIndexes.LOADING);
        
    }
    void leveltwoOnClick()
    {
        gm.setScene(SceneIndexes.GAME);
        gm.setLevel((int)2);
        SceneManager.LoadScene((int)SceneIndexes.LOADING);

    }
    void levelthreeOnClick()
    {
        gm.setScene(SceneIndexes.GAME);
        gm.setLevel((int)3);
        SceneManager.LoadScene((int)SceneIndexes.LOADING);

    }
    void levelfourOnClick()
    {
        gm.setScene(SceneIndexes.GAME);
        gm.setLevel((int)4);
        SceneManager.LoadScene((int)SceneIndexes.LOADING);

    }
}
