using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //override dei metodi della classe base Entity
    public override void TakeDamage()
    {
        Debug.Log("Il player ha subito danno");
        base.TakeDamage();
    }

    public override void KillEnemy()
    {
        Debug.Log("Il player è stato ucciso");
        base.KillEnemy();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("MAX " + maxHealth);
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage();
           
        }
    }
}
