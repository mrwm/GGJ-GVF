using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Image[] hearts;

    public int health;
    public int numOfHearts = 4;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.getManager();

    }

    // Update is called once per frame
    void Update()
    {
        health = gm.getHealth();

        for(int i = 0; i < numOfHearts; i++)
        {
            if(health > i)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
