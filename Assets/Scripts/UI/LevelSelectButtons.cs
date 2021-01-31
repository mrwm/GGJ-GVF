using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelSelectButtons : MonoBehaviour
{
    public Button back, level1, level2, level3, level4;
    private GameManager gm;
    public Animator anim;
    public float timer = 0.0f;
    public float loadTime = 3.0f;
    public bool exit_fade;
    public SceneIndexes scene_choice;
    public AudioSource start_level_sfx; 

    // Start is called before the first frame update
    void Start()
    {
        initializeLevels();
        back.onClick.AddListener(backOnClick);
        updateLevels(GameManager.getUnlockedLevels());
        gm = GameManager.getManager();
        exit_fade = false;

    }
    private void Awake()
    {
        
    }
    public void initializeLevels(){
       level1.interactable = false;
       level1.GetComponent<EventTrigger>().enabled = false;
       level2.interactable = false;
       level2.GetComponent<EventTrigger>().enabled = false;
       level3.interactable = false;
       level3.GetComponent<EventTrigger>().enabled = false;
       level4.interactable = false;
       level4.GetComponent<EventTrigger>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(exit_fade)
        {
            anim.SetTrigger("FadeOut");
            start_level_sfx.Play();
            timer += Time.deltaTime;
            if(timer >= loadTime)
            {
                SceneManager.LoadScene((int)scene_choice);
            }
        }
        
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
        level1.GetComponent<EventTrigger>().enabled = true;
        level1.onClick.AddListener(leveloneOnClick);
        break;
       case 2:
        level2.GetComponent<EventTrigger>().enabled = true;
        level2.interactable = true;
        level2.onClick.AddListener(leveltwoOnClick);
        break;
       case 3:
        level3.GetComponent<EventTrigger>().enabled = true;
        level3.interactable = true;
        level3.onClick.AddListener(levelthreeOnClick);
        break;
       case 4:
        level4.GetComponent<EventTrigger>().enabled = true;
        level4.interactable = true;
        level4.onClick.AddListener(levelfourOnClick);
        break;
      } 
    }
    void backOnClick()
    {
        scene_choice = SceneIndexes.MAINMENU;
        exit_fade = true;
    }
    void leveloneOnClick()
    {
        gm.setScene(SceneIndexes.GAME);
        gm.setLevel((int)1);
        scene_choice = SceneIndexes.LOADING;
        exit_fade = true;
    }
    void leveltwoOnClick()
    {
        gm.setScene(SceneIndexes.GAME);
        gm.setLevel((int)2);
        scene_choice = SceneIndexes.LOADING;
        exit_fade = true;


    }
    void levelthreeOnClick()
    {
        
        gm.setScene(SceneIndexes.GAME);
        gm.setLevel((int)3);
        scene_choice = SceneIndexes.LOADING;
        exit_fade = true;


    }
    void levelfourOnClick()
    {
        gm.setScene(SceneIndexes.GAME);
        gm.setLevel((int)4);
        scene_choice = SceneIndexes.LOADING;
        exit_fade = true;

    }
}
