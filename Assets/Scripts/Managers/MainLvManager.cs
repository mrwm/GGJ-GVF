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
<<<<<<< Updated upstream
    //Debug.Log(levelInd);
    levelInd = 2;
=======
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        Debug.Log(levelInd);
>>>>>>> Stashed changes

    switch (levelInd){
            case 0:
                playerPos = level_locations[0];
                break;
      case 1:
<<<<<<< Updated upstream
        playerPos = new Vector3(flagLeft1.transform.position.x + (player.transform.localScale.x * 2), flagLeft1.transform.position.y, player.transform.position.z);
        //Debug.Log("Case 1");
        break;
      case 2:
        // insert code check mechanic here
        //
        //
        //
        playerPos = new Vector3(flagLeft2.transform.position.x + (player.transform.localScale.x * 2), flagLeft2.transform.position.y, player.transform.position.z);
        Debug.Log("Case 2");
        break;
=======
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
>>>>>>> Stashed changes
      default:
                playerPos = level_locations[0];
        break;
      }
        player.GetComponent<Transform>().position = playerPos.position;

    player.transform.position = playerPos;
  }

  // Update is called once per frame
  void Update(){
    
  }
}
