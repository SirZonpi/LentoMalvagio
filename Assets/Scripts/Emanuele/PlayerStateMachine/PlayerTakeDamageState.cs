using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamageState : PlayerBaseState
{
    public Player playerScript;

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("LAMADONNA");
        Animator anim = player.GetComponent<Animator>();
        anim.SetBool("idle", false);
        anim.SetBool("cammina", false);
        anim.SetBool("attacca", false);
        anim.SetBool("attacca2", false);
        anim.SetBool("attacca3", false);
        anim.SetBool("damage", true);
    }

    public override void onCollisionEnter(PlayerStateManager player)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        // transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.Lerp(transform.localPosition.z, transform.localPosition.z-1,1));
        playerScript.StartCoroutine(playerScript.PlayerHittedCo());
        playerScript.colpito = false;
        player.SwitchState(player.idleState);

    }


}
