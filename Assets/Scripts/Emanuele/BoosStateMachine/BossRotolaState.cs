using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotolaState : BossBaseState
{
    public Boss bossScript;

    public int cambia;

    float rotationspeed = 25;
    float rotationLeft = 360;

    float startrotY;
    Quaternion startRotation;

    public override void EnterState(BossStateManager boss)
    {
        cambia = 0;

        Animator anim = boss.GetComponent<Animator>();
        anim.SetBool("idle", false);
        anim.SetBool("tent_side", false);
        anim.SetBool("tent_front", false);
        anim.SetBool("castaSpell", false);
        anim.SetBool("rotola", true);

        startrotY = transform.rotation.y;
        startRotation = transform.rotation;

    }

    public override void onCollisionEnter(BossStateManager boss)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(BossStateManager boss)
    {
  

        float rotation = rotationspeed * Time.deltaTime;
        if (rotationLeft > rotation)
        {
            rotationLeft -= rotation;
        }
       

        bossScript.tentacoli.transform.Rotate(0, rotation, 0);

        if (  cambia==1)
        {
            Debug.Log("PRONTOPROVA");
            transform.rotation = startRotation;
            boss.SwitchState(boss.idleState);
        }


    }


    public void Cambia3(int _cambia)
    {
        cambia = _cambia;
    }

}
