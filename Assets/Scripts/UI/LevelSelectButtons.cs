using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        back.onClick.AddListener(backOnClick);
        level1.onClick.AddListener(leveloneOnClick);
        level2.onClick.AddListener(leveltwoOnClick);
        level3.onClick.AddListener(levelthreeOnClick);
        level4.onClick.AddListener(levelfourOnClick);
        gm = GameManager.getManager();
        exit_fade = false;

    }
    private void Awake()
    {
        
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
