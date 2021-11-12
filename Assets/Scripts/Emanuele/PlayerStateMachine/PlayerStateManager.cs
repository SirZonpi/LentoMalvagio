using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentPlayerState;
 
    public PlayerIdleState idleState; 
    public PlayerWalkState walkState; 
    public PlayerAttackState attackState; 
    public PlayerAttack2State attack2State;
    public PlayerAttack3State attack3State;
    public PlayerCastState castState;
    public PlayerEsecuzioneState esecuzione;
    public PlayerTakeDamageState takeDamage;

    public void SwitchState(PlayerBaseState playerState)
    {
        currentPlayerState = playerState;
        playerState.EnterState(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentPlayerState = idleState;
        currentPlayerState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("LOSTATODELLAMERDA " + currentPlayerState);

        currentPlayerState.UpdateState(this);

   
    }
}
