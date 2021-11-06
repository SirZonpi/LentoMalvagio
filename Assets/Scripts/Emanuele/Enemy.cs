using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public int animeDrop;

    //override dei metodi della classe base Entity
    public override void KillEnemy()
    {
        Debug.Log("Un nemico è stato ucciso");
        base.KillEnemy();
    }

    public override void TakeDamage(int amount)
    {
        Debug.Log("Un nemico ha preso danno");
        base.TakeDamage(amount);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(5);
        }
    }
}
