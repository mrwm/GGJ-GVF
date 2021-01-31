using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLvManager : MonoBehaviour{

  public int levelInd;
  private GameManager gm;
  private Transform playerPos;
    private GameObject player;
    private Rigidbody2D rb;
  public GameObject cmera;
  private Vector3 cmeraPos;

  // We only need the starting place at the left
  public GameObject flagLeft1;
  public GameObject flagLeft2;
  public GameObject flagLeft3;
  public GameObject flagLeft4;
  private float flagLeftPos;
  public Transform[] level_locations;

    // Start is called before the first frame update
    void Start(){
    gm = GameManager.getManager();
    levelInd = gm.getLevel();

    switch (levelInd){
            case 0:
                playerPos = level_locations[0];
                break;
      case 1:
                playerPos = level_locations[1];
        //Debug.Log("Case 1");
        break;
      case 2:
                playerPos = level_locations[2];
                break;
            case 3:
                playerPos = level_locations[3];
                break;
            case 4:
                playerPos = level_locations[4];
                break;
      default:
                playerPos = level_locations[0];
        break;
      }
        player.GetComponent<Transform>().position = playerPos.position;

  }

  // Update is called once per frame
  void Update(){
    
  }
}
