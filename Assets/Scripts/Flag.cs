﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour{

  //public GameObject player;
  //private Vector3 playerPos;
  public string flagName;
 
  // Start is called before the first frame update
  void Start(){
    flagName = this.name;
    Debug.Log(flagName);
  }

  // Update is called once per frame
  void Update(){
    
  }

  void OnTriggerEnter2D(Collider2D other){
    Debug.Log("FLAG");
  }

}
