using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private SceneIndexes current_scene_index;
    private int current_level_index;
    private static GameManager instance;
    public bool second_load = true;
    public int health_level = 4;
    public int number_of_chests_collected = 0;
    public int total_gacha_currency = 0;
    public int total_princess_saved = 0;
    private static int[] unlockedLevels = {1,0,0,0};
    // Start is called before the first frame update
    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        current_scene_index = SceneIndexes.MAINMENU;
        //current_level_index = LevelIndexes.LVONE;
        instance.setScene(current_scene_index);
        instance.setLevel(current_level_index);
        LoadGame();
    }
    public static int[] getUnlockedLevels()
    {
        return unlockedLevels;
    }
    public static GameManager getManager()
    {
        //singleton pattern
        return instance;
    }
    public void setScene (SceneIndexes level)
    {
        current_scene_index = level;
    }
    public int getScene()
    {
        return (int)current_scene_index;
    }

    public void setLevel (int lvl)
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

    public void addPoints(int amount)
    {
        total_gacha_currency += amount;
        Debug.Log(total_gacha_currency);
    }

    public void takeDamage(int hit)
    {
        health_level -= hit;
    }
    public void setHealth (int hit)
    {
        health_level = hit;
    }
    public int getHealth()
    {
        return health_level;
    }

}
