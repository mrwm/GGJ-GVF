using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportArrow : MonoBehaviour{
  private GameManager gm;
  public SceneIndexes scene_choice;
  // Start is called before the first frame update
  void Start(){
    gm = GameManager.getManager();
    
  }

  // Update is called once per frame
  void Update(){
    
  }

  void OnTriggerEnter2D(Collider2D other){
    Debug.Log(other.tag);
    if (other.tag == "Player"){
      gm.setScene(SceneIndexes.GAME);
      if ((gm.getLevel()+1) < 4)
        gm.setLevel((int)gm.getLevel()+1);
      scene_choice = SceneIndexes.LOADING;
      SceneManager.LoadScene((int)scene_choice);
    }
  }
}
