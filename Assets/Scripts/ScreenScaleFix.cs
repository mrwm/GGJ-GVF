using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScaleFix : MonoBehaviour {

  private float screenHeight;
  private float screenWidth;

  // Use this for initialization
  void Start () {
    screenHeight = Camera.main.orthographicSize * 2.0f;
    screenWidth = screenHeight * Screen.width / Screen.height;

    //This doesn't work:
    //transform.localScale = new Vector3(screenHeight, screenHeight, screenHeight);

    //TEST
    Vector3 initialScale = transform.localScale;
    float additionX = 0f;
    float additionY = 0f;

    //Debug.Log(transform.localScale);
    if (transform.localScale.x > 1.0f){
      additionX = 0.1f * (int)transform.localScale.x;
    }
    if (transform.localScale.y > 1.0f){
      additionY = 0.1f * (int)transform.localScale.x;
    }
    transform.localScale = new Vector3( ((initialScale.x * 16) / screenWidth) + additionX , ((initialScale.y * 9) / screenHeight) + additionY, initialScale.z);
    //Debug.Log(transform.localScale);


  }
  
  // Update is called once per frame
  void Update () {
    
  }
}
