using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateManager : MonoBehaviour
{
    public BossBaseState currentBossState;

    public BossIdleState idleState;
    public BossTentacoliSideState tentacoliSideState;
    public BossTentacoliFrontState tentacoliFrontState;
    public BossCastState castState;
    public BossRotolaState rotolaState;

    public BossBaseState[] allStates;

    public void SwitchState(BossBaseState bossState)
    {
        currentBossState = bossState;
        bossState.EnterState(this);
    }


    void Start()
    {
        currentBossState = idleState;
        currentBossState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("LOSTATODELBOSS " + currentBossState);

        currentBossState.UpdateState(this);
    }
}
