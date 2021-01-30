using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour{

  //public GameObject player;
  //private Vector3 playerPos;
 
  // Start is called before the first frame update
  void Start(){
    
  }

  // Update is called once per frame
  void Update(){
    
  }

  void OnTriggerEnter2D(Collider2D other){
    Debug.Log("FLAG");
  }

}
