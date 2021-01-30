using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

  public GameObject Tutorial0; // Story page
  public GameObject Tutorial1; // Player controls 1/2
  public GameObject Tutorial2; // Player controls 2/2
  public GameObject Tutorial3; // Misc controls 1/2
  public GameObject Tutorial4; // Misc controls 2/2
  public GameObject Tutorial5; // Credits page
  private int pageNumber;

  private GameObject nextButton;
  private Sprite nextButtonImg;
  public Sprite playButton;

  // Use this for initialization
  void Start() {
    // for the slides
    Tutorial1.SetActive(false); // Hide player control page page
    Tutorial2.SetActive(false); // Hide third page
    Tutorial3.SetActive(false); // Hide fourth page
    Tutorial4.SetActive(false); // Hide fifth page
    Tutorial5.SetActive(false); // Hide sixth page
    pageNumber = 0; // starting on story page
    nextButton = GameObject.Find("NextButton");
    nextButtonImg = nextButton.GetComponent<Image>().sprite;
    //gameVariables.InstructionsRead = false;
  }

  public void PlayGame()
  {
    // Load level1
    if(gameVariables.InstructionsRead){
      SceneManager.LoadScene("Level1");
    }
    else{
      SceneManager.LoadScene("Tutorial");
      gameVariables.InstructionsRead = true;
    }
  }
  public void Tutorial()
  {
    // Load Tutorial
    SceneManager.LoadScene("Tutorial");
    gameVariables.InstructionsRead = true;
  }
  public void TutorialNext()
  {
    switch(pageNumber){
      case 0:
        Tutorial0.SetActive(false);
        Tutorial1.SetActive(true);
        //Tutorial2.SetActive(false);
        //Tutorial3.SetActive(false);
        //Tutorial4.SetActive(false);
        //Tutorial5.SetActive(false);
        break;
      case 1:
        //Tutorial0.SetActive(false);
        Tutorial1.SetActive(false);
        Tutorial2.SetActive(true);
        //Tutorial3.SetActive(false);
        //Tutorial4.SetActive(false);
        //Tutorial5.SetActive(false);
        break;
      case 2:
        //Tutorial0.SetActive(false);
        //Tutorial1.SetActive(false);
        Tutorial2.SetActive(false);
        Tutorial3.SetActive(true);
        //Tutorial4.SetActive(false);
        //Tutorial5.SetActive(false);
        break;
      case 3:
        //Tutorial0.SetActive(false);
        //Tutorial1.SetActive(false);
        //Tutorial2.SetActive(false);
        Tutorial3.SetActive(false);
        Tutorial4.SetActive(true);
        //Tutorial5.SetActive(false);
        break;
      case 4:
        //Tutorial0.SetActive(false);
        //Tutorial1.SetActive(false);
        //Tutorial2.SetActive(false);
        //Tutorial3.SetActive(false);
        Tutorial4.SetActive(false);
        Tutorial5.SetActive(true);
        nextButton.GetComponent<Image>().sprite = playButton;
        break;
      case 5:
        // This shouldn't happen
        SceneManager.LoadScene("Level1");
        break;
      default:
        SceneManager.LoadScene("MainMenu");
        break;
    }
    pageNumber += 1;
  }
  public void TutorialBack()
  {
    switch(pageNumber){
      case 0:
        SceneManager.LoadScene("MainMenu");
        break;
      case 1:
        Tutorial0.SetActive(true);
        Tutorial1.SetActive(false);
        //Tutorial2.SetActive(false);
        //Tutorial3.SetActive(false);
        //Tutorial4.SetActive(false);
        //Tutorial5.SetActive(false);
        break;
      case 2:
        //Tutorial0.SetActive(false);
        Tutorial1.SetActive(true);
        Tutorial2.SetActive(false);
        //Tutorial3.SetActive(false);
        //Tutorial4.SetActive(false);
        //Tutorial5.SetActive(false);
        break;
      case 3:
        //Tutorial0.SetActive(false);
        //Tutorial1.SetActive(false);
        Tutorial2.SetActive(true);
        Tutorial3.SetActive(false);
        //Tutorial4.SetActive(false);
        //Tutorial5.SetActive(false);
        break;
      case 4:
        //Tutorial0.SetActive(false);
        //Tutorial1.SetActive(false);
        //Tutorial2.SetActive(false);
        Tutorial3.SetActive(true);
        Tutorial4.SetActive(false);
        //Tutorial5.SetActive(false);
        break;
      case 5:
        //Tutorial0.SetActive(false);
        //Tutorial1.SetActive(false);
        //Tutorial2.SetActive(false);
        //Tutorial3.SetActive(false);
        Tutorial4.SetActive(true);
        Tutorial5.SetActive(false);
        nextButton.GetComponent<Image>().sprite = nextButtonImg;
        break;
      default:
        SceneManager.LoadScene("MainMenu");
        break;
    }
    pageNumber -= 1;
  }

  public void QuitGame() {
    Application.Quit();
  }
}
