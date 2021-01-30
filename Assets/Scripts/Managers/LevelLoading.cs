using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoading : MonoBehaviour
{
    public float timer = 0.0f;
    public float loadTime = 3.0f;
    public Text loading_txt;
    private GameManager gm;
    public Image ice_cream;
    public Image slime;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.getManager();
        if (gm.isSecondLoad())
        {
            ice_cream.enabled = false;
            slime.enabled = true;
        }
        else
        {
            ice_cream.enabled = true;
            slime.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {


        timer += Time.deltaTime;

        float loading_distant = (loadTime - timer);
        if (loading_distant >= 3)
        {
            loading_txt.text = "Loading";
        }
        else if (loading_distant >= 2)
        {
            loading_txt.text = "Loading.";
        }
        else if (loading_distant >= 1)
        {
            loading_txt.text = "Loading..";
        }
        else if (loading_distant >= 0)
        {
            loading_txt.text = "Loading...";
        }

        if (timer >= loadTime)
        {
            gm.LoadGame();
        }

    }
}
