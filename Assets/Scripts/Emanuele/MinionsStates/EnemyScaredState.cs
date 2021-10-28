using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScaredState : EnemyBaseState
{
    public int cambia=0;
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("CIAO A TUTTI DALLO STATE INIZIALE!");

        Animator anim = enemy.GetComponent<Animator>();
        anim.SetBool("idle", false);
        anim.SetBool("cammina", false);
        anim.SetBool("spaventato",true);
    }

    public override void onCollisionEnter(EnemyStateManager enemy)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (cambia==1)
        {
            enemy.SwitchState(enemy.walkState);

        }
        else { return; }
    }

    public void Cambia(int _cambia)
    {
        cambia = _cambia ;
    }
    private void Update()
    {

    }

}
