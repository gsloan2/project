using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private double maxHealth;
    public double currentHealth;

    

    // Start is called before the first frame update
    void Start()
    {
        this.currentHealth = this.maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void takeDamage(double damage)
    {
        this.currentHealth -= damage;
    }

    public void applyDamage()
    {

    }
}
