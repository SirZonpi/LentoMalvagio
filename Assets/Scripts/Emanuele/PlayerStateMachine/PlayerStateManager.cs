using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentPlayerState;
    public PlayerAttackState attackState; // = new PlayerAttackState();
    public PlayerIdleState idleState; // = new PlayerIdleState();
    public PlayerWalkState walkState; // = new PlayerWalkState();
    public PlayerAttack2State attack2State;

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
        currentPlayerState.UpdateState(this);
    }
}
