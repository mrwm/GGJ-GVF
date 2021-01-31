using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator anim;
    public LootSystem ls;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        if(anim == null) anim = GetComponent<Animator>();
        ls = GetComponent<LootSystem>();

    }
    public void TakeDamage(int damage)
    {
        anim.SetTrigger("Damaged");
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //die animation
        if(ls != null)
        {
            ls.Spawn();
        }
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
