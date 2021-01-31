using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour{
  private GameManager gm;
  private float player_health;
  private float slime_health;

  // Start is called before the first frame update
  void Start(){
    gm = GameManager.getManager();
    slime_health = 5f;
  }

  // Update is called once per frame
  void Update(){
    
  }

  void OnTriggerEnter2D(Collider2D other){
    if (other.tag == "Player")
      player_health = gm.getHealth();
      Debug.Log("HIT");
      player_health -= 1;
      gm.setHealth(player_health);
  }
}
