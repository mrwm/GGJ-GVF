public static class gameVariables {
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
