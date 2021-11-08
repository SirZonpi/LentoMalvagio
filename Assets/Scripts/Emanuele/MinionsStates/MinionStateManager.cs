using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionStateManager : MonoBehaviour
{

    MinionBaseState currentMinionState;

    public MinionIdleState idleState; //= new EnemyIdleState();
    public MinionWalkState walkState; // = new EnemyWalkState();
    public MinionScaredState scaredState; // = new EnemyScaredState();

    public void SwitchState(MinionBaseState minionState)
    {
        currentMinionState = minionState;
        minionState.EnterState(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentMinionState = idleState;
        currentMinionState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentMinionState.UpdateState(this);
    }
}
