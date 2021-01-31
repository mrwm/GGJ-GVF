using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaCoin : MonoBehaviour
{
    public GameManager gm;
    public int gachacoin_value = 1000;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.getManager();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gm.addPoints(gachacoin_value);
        }
        Destroy(this.gameObject);
    }
}
