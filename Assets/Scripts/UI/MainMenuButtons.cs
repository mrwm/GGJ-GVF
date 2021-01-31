using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuButtons : MonoBehaviour
{
    public Button btn_start;
    public Animator anim;
    public float timer = 0.0f;
    public float loadTime = 1.5f;
    public bool exit_fade = false;
    // Start is called before the first frame update
    void Start()
    {
        btn_start.onClick.AddListener(StartOnClick);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (exit_fade)
        {
            anim.SetTrigger("FadeOut");
            timer += Time.deltaTime;
            if (timer >= loadTime)
            {
                SceneManager.LoadScene("LevelSelect");
            }
        }
    }
    void StartOnClick()
    {
        exit_fade = true;
    }
}
