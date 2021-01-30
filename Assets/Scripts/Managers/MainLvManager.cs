using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour{

  private int levelInd;
  private GameManager gm;

  public GameObject player;
  private Vector3 playerPos;

  public GameObject cmera;
  private Vector3 cmeraPos;


  // Start is called before the first frame update
  void Start(){
    gm = GameManager.getManager();
    levelInd = gm.getLevel();

    switch (levelInd){
      case 1:
        // hardcoded starting place:
        // maybe replace with flag later?
        // technically we don't need to do anything since it's the default 
        // starting place for the character
        playerPos = new Vector3(-4.63f, 2.39f, 0f);
        Debug.Log("Case 1");
        break;
      case 2:
        //
        playerPos = new Vector3(-4.63f, 2.39f, 0f);
        Debug.Log("Case 2");
        break;
      default:
        Debug.Log("Default case");
        break;
      }

 }

  // Update is called once per frame
  void Update(){
    
  }
}
