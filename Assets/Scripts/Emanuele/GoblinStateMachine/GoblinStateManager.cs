using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinStateManager : MonoBehaviour
{
    GoblinBaseState currentGoblinState;
    public GoblinAttackState attackState; // = new PlayerAttackState();
    public GoblinIdleState idleState; // = new PlayerIdleState();
    public GoblinWalkState walkState; // = new PlayerWalkState();
    //public PlayerAttack2State attack2State;
    //public PlayerAttack3State attack3State;

    public void SwitchState(GoblinBaseState goblinState)
    {
        currentGoblinState = goblinState;
        goblinState.EnterState(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentGoblinState = idleState;
        currentGoblinState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentGoblinState.UpdateState(this);
    }
}
