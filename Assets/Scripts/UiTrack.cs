using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTrack : MonoBehaviour {


  public GameObject Obj;
  public bool above;
  public bool center;
  private float offset;
  public Camera mCamera;
  private RectTransform rt;

  // Use this for initialization
  void Start (){
    this.gameObject.SetActive(true);
    rt = GetComponent<RectTransform>();
    if(above){
      offset = 0.65f;
    }
    else if (center){
      offset = 0f;
    }
    else{
      offset = -0.65f;
    }
  }

  // Update is called once per frame
  void Update (){
    if (Obj != null){
      Vector2 objPos = new Vector2(Obj.transform.position.x, Obj.transform.position.y + offset);
      Vector2 pos = RectTransformUtility.WorldToScreenPoint(mCamera, objPos);
      rt.position = pos;
    }
  }
}
