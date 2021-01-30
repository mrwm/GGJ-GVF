using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private SceneIndexes current_level_index;
    private static GameManager instance;
    private static int[] unlockedLevels = {1,0,0,0};
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
    {
        current_level_index = level;
    }
    public int getLevel()
    {
        return (int)current_level_index;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene((int)current_level_index);
    }
}
