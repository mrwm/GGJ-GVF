using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoading : MonoBehaviour
{
    public float timer = 0.0f;
    public float loadTime = 5.0f;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.getManager();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= loadTime)
        {
            gm.LoadGame();
        }
    }
}
