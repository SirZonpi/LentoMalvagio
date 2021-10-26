using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class EnemyIdleState : EnemyBaseState
{
   

    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("CIAO A TUTTI DALLO STATE INIZIALE!");

        Animator anim = enemy.GetComponent<Animator>();
        anim.SetBool("idle", true);
        anim.SetBool("cammina", false);

    }

    public override void onCollisionEnter(EnemyStateManager enemy)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            enemy.SwitchState(enemy.walkState);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
