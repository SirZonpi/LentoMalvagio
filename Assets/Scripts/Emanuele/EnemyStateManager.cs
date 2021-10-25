using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{

    EnemyBaseState currentEnemyState;
    public EnemyAttackState attackState = new EnemyAttackState();
    public EnemyIdleState idleState = new EnemyIdleState();
    public EnemyWalkState walkState = new EnemyWalkState();
    public EnemyScaredState scaredState = new EnemyScaredState();

    public void SwitchState(EnemyBaseState enemyState)
    {
        currentEnemyState = enemyState;
        enemyState.EnterState(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentEnemyState = idleState;
        currentEnemyState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentEnemyState.UpdateState(this);
    }
}
