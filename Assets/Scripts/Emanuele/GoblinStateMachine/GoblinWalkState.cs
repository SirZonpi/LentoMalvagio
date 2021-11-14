using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinWalkState : GoblinBaseState
{
    public Goblin _goblin;


    public Collider pugnoDes;
    public Collider pugnoSin;

    public override void EnterState(GoblinStateManager goblin)
    {
        pugnoDes.enabled = false;
        pugnoSin.enabled = false;

        Animator anim = goblin.GetComponent<Animator>();
        anim.SetBool("cammina", true);
        anim.SetBool("idle", false);
        anim.SetBool("attacca", false);
        // anim.SetBool("spaventato", false);   
        _goblin.MoveToPath();
    }

    public override void onCollisionEnter(GoblinStateManager goblin)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(GoblinStateManager goblin)
    {
        float distance = Vector3.Distance(transform.position, _goblin.playerTransform.transform.position);
        //Debug.Log("distance " + distance);


        if (distance <= _goblin.attackRadius && distance < 1.3f)
        {
            goblin.SwitchState(goblin.attackState);
        }

        if (distance <= _goblin.attackRadius && distance  > 1.3f) //inseguimento
        {
            _goblin.timer += Time.deltaTime;

            if (_goblin.timer > _goblin.nextTime)
            {
                _goblin.inRange = true;
                transform.LookAt(_goblin.playerTransform.transform);

                Vector3 moveTo = Vector3.MoveTowards(transform.position, _goblin.playerTransform.transform.position, 30);
                _goblin._agent.destination = moveTo;

            }

        }
        else if (distance > _goblin.attackRadius)
        {
            _goblin.inRange = false;
            _goblin.MoveToPath();
        }
    }
}
