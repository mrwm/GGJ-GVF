using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private SceneIndexes current_level_index;
    private static GameManager instance;
    public bool second_load = true;

    public float health_level = 1.0f;
    public int number_of_chests_collected = 0;
    public int total_gacha_currency = 0;
    public int total_princess_saved = 0;

    // Start is called before the first frame update
    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        current_level_index = SceneIndexes.MAINMENU;
        instance.setLevel(current_level_index);
        LoadGame();
    }
    public static GameManager getManager()
    {
        //singleton pattern
        return instance;
    }
    public void setLevel (SceneIndexes level)
    {
        current_level_index = level;
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
        SceneManager.LoadScene((int)current_level_index);
    }
}
