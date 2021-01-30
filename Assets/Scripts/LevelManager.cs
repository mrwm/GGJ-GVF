using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq; // used to manipulate lists

public class LevelManager : MonoBehaviour {

  public Slider healthBarSlider;
  public Slider bbyHungerBarSlider;

  public float foodDelay = 3f;
  private PlayerControls gamePlayer;

  public List<GameObject> bunchOfFood2Hide; //= new List<GameObject>();
  public List<GameObject> bunchOfFoodWithBird; //= new List<GameObject>();

  //private FoodScript foodFun;
  private FoodInventory foodInvntry;

  // Use this for initialization
  void Start () {
    foodInvntry = FindObjectOfType<FoodInventory>();
    //foodFun = FindObjectOfType<FoodScript>();
    gamePlayer = FindObjectOfType<PlayerControls>();
    healthBarSlider.value = 100f;
    bbyHungerBarSlider.value = 0f;
  }

  // Sends the player to the main menu 5 seconds after ending
  public IEnumerator endSCREEN(){
    yield return new WaitForSeconds(5);
    SceneManager.LoadScene("MainMenu");
  }

  // Decreases health of player
  public void hit(){
    healthBarSlider.value -= 10f;
    // Load end popup if hp is less than zero
    if (healthBarSlider.value == 0f){
      gamePlayer.deadEndPanel.SetActive(true);
      hideBar();
      StartCoroutine(endSCREEN());
    }
  }

  public void showTheFood(){
    foreach(GameObject food in bunchOfFood2Hide){
      food.SetActive(true);
    }
    bunchOfFood2Hide.Clear();
  }

  // Hides the food for a certain amount of time
  private GameObject foodToHide;
  public IEnumerator hideFOOD(float time, string name){
    bunchOfFood2Hide = bunchOfFood2Hide.Where(item => item != null).ToList(); // removes null items

    foodToHide = GameObject.Find(name);
    bunchOfFoodWithBird.Add(foodToHide);
    foodInvntry.currentInventory("add", foodToHide, foodToHide.gameObject.name); // update inventory
    foodToHide.SetActive(false);
    yield return new WaitForSeconds(time);
    if(!(foodToHide.name.Contains("Clone"))){
      bunchOfFood2Hide.Add(foodToHide);
    }
  }

  // Increase food/meal count and trigger healing
  public void foodUp(int foodValue, string name, int healValue){
    healUp(healValue);
    StartCoroutine(hideFOOD(foodDelay, name));
  }

  // Heals the player
  public void healUp(int healValue){
    if (healthBarSlider.value < 100f){
      healthBarSlider.value += healValue;
    }
  }

  // Drops da food
  public void dropDaFood(){
    bunchOfFoodWithBird = bunchOfFoodWithBird.Where(item => item != null).ToList();

    if(bunchOfFoodWithBird.Any()){
      //GameObject lastFood = bunchOfFoodWithBird.Last(); // get last item held
      GameObject lastFood = bunchOfFoodWithBird.LastOrDefault(); // get last item held
      bool isClone = lastFood.name.Contains("Clone");
      GameObject player = GameObject.Find("Player"); // get player info
      Vector2 playerFoodDrop = new Vector2(player.transform.position.x, player.transform.position.y - 1.5f); // set food drop location
      var foodClone = Instantiate(lastFood, playerFoodDrop, player.transform.rotation); // create the clone
      foodClone.SetActive(true); // enable the clone to show up
      bunchOfFoodWithBird.Remove(lastFood); // remove dropped item from list
      foodInvntry.currentInventory("delete", lastFood, lastFood.gameObject.name); // update inventory
      if(isClone){
        Destroy(lastFood);
      }
    }
  }

  // Launches the end screen 
  public void bby(int foodValue){
    bbyHungerBarSlider.value += foodValue;
    if(bbyHungerBarSlider.value > 99){
      gamePlayer.endPanel.SetActive(true);
      hideBar();
      StartCoroutine(endSCREEN());
    }
  }

  private void hideBar(){
    if(GameObject.Find("HealthSlider") != null){
      GameObject.Find("HealthSlider").SetActive(false);
      GameObject.Find("bbyHungerSlider").SetActive(false);
    }
  }
}
