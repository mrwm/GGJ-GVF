using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour{

  public GameObject player;
  public float offset;
  private Vector3 playerPos;
  public float offsetSmooth;

  // Start is called before the first frame update
  void Start(){
    
  }

  // Update is called once per frame
  void Update(){
    playerPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    if(player.transform.localScale.x > 0f)
      playerPos = new Vector3(playerPos.x + offset, transform.position.y, transform.position.z);
    else
      playerPos = new Vector3(playerPos.x - offset, transform.position.y, transform.position.z);
    transform.position = Vector3.Lerp(transform.position, playerPos, offsetSmooth * Time.deltaTime);
  }
}
