using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeyboardShortcuts : MonoBehaviour {
  private string currentScene;
  private bool atGameScene;

  // for the minimap
  private GameObject cam;
  private GameObject redBox;
  private bool miniMapActive;

  // for the Inventory
  private GameObject foodPanel;
  private GameObject bbyPanel;
  private bool foodPanelActive;

  // Background music variables
  AudioSource[] bg_music;
  AudioSource openMusic;
  AudioSource loopMusic;
  public Button musicButton;
  private bool openLoop; // used to setup main loop music

  // Use this for initialization
  void Start () {
    miniMapActive = false;
    cam = GameObject.Find("MiniMap"); // Get the minimap camera
    redBox = GameObject.Find("redBoxy");


    foodPanelActive = false;
    foodPanel = GameObject.Find("FoodPanel");
    bbyPanel = GameObject.Find("bbyBirdPanel");

    // Get the current name of the scene
    currentScene = SceneManager.GetActiveScene().name;

    atGameScene = true;
    if(!(currentScene.Contains("Level1"))){
      musicButton.onClick.AddListener(PlayButton); // don't set listener on game scene
      atGameScene = false;
    }
    else{
      cam.SetActive(miniMapActive); // hide minimap!
      redBox.SetActive(miniMapActive);

      // Hide Inventories
      bbyPanel.SetActive(foodPanelActive);
      foodPanel.SetActive(foodPanelActive);
    }

    // for the music
    bg_music = GetComponents<AudioSource>();
    openMusic = bg_music[0];

    if(bg_music.Length > 1){
      loopMusic = bg_music[1];
      loopMusic.loop = true;
      loopMusic.Stop();
    }

    if(!gameVariables.Mute){
      if(atGameScene){
        openMusic.loop = false;
        openMusic.Play();
        loopMusic.PlayDelayed(openMusic.clip.length);
        loopMusic.loop = true;
        loopMusic.Play();
      }
      else{
        openMusic.loop = true;
        openMusic.Play();
      }
    }
    else{
      openMusic.Stop();
    }
  }

  // Update is called once per frame
  void Update () {

    // grab keyboard codes at Edit > Proj.Settings > Input > Axis @ side bar

    // 0: not pressed
    // 1: pressed
    float esc = Input.GetAxis("Cancel");
    if ((esc != 0) && (currentScene == "Level1")){
      SceneManager.LoadScene("MainMenu");
    }
    else if ((esc != 0) && (currentScene != "Level1")){
      Application.Quit();
    }
    // Reload the level if "r" is pressed
    if (Input.GetKeyDown("r")){
      SceneManager.LoadScene("Level1");
    }
    // Toggle music if "m" is pressed
    if (Input.GetKeyDown("m")){
      PlayButton();
    }
    // Toggle map
    if (Input.GetKeyDown("q")){
      showMap();
    }
    // Toggle inventory
    if (Input.GetKeyDown("e")){
      showInventory();
    }
  }

  void PlayButton(){
    if(gameVariables.Mute){
      gameVariables.Mute = false;
      if(atGameScene){
        openMusic.loop = false;
        openMusic.Play();
        loopMusic.PlayDelayed(openMusic.clip.length);
        loopMusic.loop = true;
        loopMusic.Play();
      }
      else{
        openMusic.Play();
      }
    }
    else{
      gameVariables.Mute = true;
      openMusic.Stop();
      loopMusic.Stop();
    }
  }

  void showMap(){
    if(!miniMapActive){
      miniMapActive = true;
      cam.SetActive(miniMapActive);
      redBox.SetActive(miniMapActive);
    }
    else{
      miniMapActive = false;
      cam.SetActive(miniMapActive);
      redBox.SetActive(miniMapActive);
    }
  }

  void showInventory(){
    if(!foodPanelActive){
      foodPanelActive = true;
      foodPanel.SetActive(foodPanelActive);
      bbyPanel.SetActive(foodPanelActive);
    }
    else{
      foodPanelActive = false;
      foodPanel.SetActive(foodPanelActive);
      bbyPanel.SetActive(foodPanelActive);
    }
  }
}
