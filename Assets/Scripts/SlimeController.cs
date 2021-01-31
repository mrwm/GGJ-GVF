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

    InvokeRepeating("animateSlime", 2f, 1f);
  }

  // Update is called once per frame
  void Update(){
    if (slime_health < 0)
      //delete self
      Destroy(gameObject);
  }

  void OnTriggerEnter2D(Collider2D other){
    if (other.tag == "Player"){
      player_health = gm.getHealth();
      player_health -= 1;
      gm.setHealth(player_health);
    }
    else if (other.tag == "Weapon"){
      slime_health -= 2.5f;
    }
  }

  private Vector2 slime_scale;
  private int scaleDirection = 1;
  void animateSlime(){
    slime_scale = new Vector2(transform.localScale.x, transform.localScale.y + (0.035f * scaleDirection));
    scaleDirection = -scaleDirection;

    //transform.localScale = Vector3.Lerp(transform.localScale, slime_scale, 10f * Time.deltaTime);;
    transform.localScale = slime_scale;
  }
}
