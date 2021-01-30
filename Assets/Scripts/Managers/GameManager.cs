using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private SceneIndexes current_level_index;
    private static GameManager instance; 
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

    public void LoadGame()
    {
        SceneManager.LoadScene((int)current_level_index);
    }
}
