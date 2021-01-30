﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private SceneIndexes current_level_index;
    private static GameManager instance;
LoadingScreen
    public bool second_load = true;

    public float health_level = 1.0f;
    public int number_of_chests_collected = 0;
    public int total_gacha_currency = 0;
    public int total_princess_saved = 0;
    private static int[] unlockedLevels = {1,0,0,0};
    private SceneIndexes current_scene_index;
    private LevelIndexes current_level_index;
    private static GameManager instance; 


    // Start is called before the first frame update
    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        current_scene_index = SceneIndexes.MAINMENU;
        current_level_index = LevelIndexes.LVONE;
        instance.setScene(current_scene_index);
        LoadGame();
    }
    public static GameManager getManager()
    {
        //singleton pattern
        return instance;
    }

    public static int[] getUnlockedLevels()
    {
        return unlockedLevels;
    }
    // TODO unlocking level 2 would be unlockLevel(2)
    // public void unlockLevel(levelNumber){
    //     int index = levelNumber - 1;
    //     unlockedLevels[levelNumber - 1] = 1;
    // }
    public void setLevel (SceneIndexes level)

    public void setScene (SceneIndexes level)
    {
        current_scene_index = level;
    }
    public int getScene()
    {
        return (int)current_scene_index;
    }

    public void setLevel (LevelIndexes lvl)
    {
        current_level_index = lvl;
    }
    public int getLevel()
    {
        return (int)current_level_index;
    }
    
    public bool isSecondLoad()
    {
        return second_load;
    }
    public void LoadGame()
    {

        instance.second_load = !instance.second_load;
        SceneManager.LoadScene((int)current_scene_index);

    }
}
