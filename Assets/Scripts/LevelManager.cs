using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour{

  public int levelInd;

  // Start is called before the first frame update
  void Start(){

    // Always start at level 0 by default
    levelInd = 0;
  }

  // Update is called once per frame
  void Update(){
    
  }


  private static bool mute, instructionsRead;

  public static bool Mute{
    get{
      return mute;
    }
    set{
      mute = value;
    }
  }

  public static bool InstructionsRead{
    get{
      return instructionsRead;
    }
    set{
      instructionsRead = value;
    }
  }
}
