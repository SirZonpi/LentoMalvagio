using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class PlayerAttack3State : PlayerBaseState
{
    public int cambia;

   public CinemachineVirtualCamera vcam;

    public float zoomSpeed = 1;
    public float targetOrtho;
    public float startOrtho;
    public float smoothSpeed = 2.0f;
    public float minOrtho = 1.0f;
    public float maxOrtho = 20.0f;

    public override void EnterState(PlayerStateManager player)
    {
        cambia = 1;

       //startOrtho = vcam.m_Lens.OrthographicSize; 

        Animator anim = player.GetComponent<Animator>();

        anim.SetBool("attacca3", true);
        //anim.SetBool("attacca2", true);
        anim.SetBool("idle", false);
        anim.SetBool("cammina", false);
        //anim.SetBool("attacca", true);

      
        //vcam.m_Lens.OrthographicSize = Mathf.MoveTowards(vcam.m_Lens.OrthographicSize, 2, 10 * Time.deltaTime);
     //   GameManager.instance.timeManager.SlowMotion();
    

    }

    public override void onCollisionEnter(PlayerStateManager player)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        Debug.Log("ATTACCO 3");

        Animator anim = player.GetComponent<Animator>();

        //vcam.m_Lens.OrthographicSize = Mathf.MoveTowards(vcam.m_Lens.OrthographicSize, 2, 10 * Time.deltaTime);

        if (cambia == 0 && anim.GetBool("attacca3") == true)
        {
            anim.SetBool("attacca3", false);
            anim.SetBool("attacca2", false);
            anim.SetBool("attacca", false);
            
            player.SwitchState(player.idleState);

        }
    }

    public void Cambia3(int _cambia) //da cambiare con una stringa, è un animaton event
    {
        cambia = _cambia;

    }

}
