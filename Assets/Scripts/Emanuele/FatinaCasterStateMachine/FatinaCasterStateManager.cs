using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatinaCasterStateManager : MonoBehaviour
{
    FatinaCasterBaseState currentFatinaCasterState;
    public FatinaCasterAttackState attackState; 
    public FatinaCasterIdleState idleState; 
    public FatinaCasterWalkState walkState; 
    public FatinaCasterDamageState damageState;


    public void SwitchState(FatinaCasterBaseState fatinaCasterState)
    {
        currentFatinaCasterState = fatinaCasterState;
        fatinaCasterState.EnterState(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentFatinaCasterState = idleState;
        currentFatinaCasterState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("FATINASTATO " + currentFatinaCasterState);

        currentFatinaCasterState.UpdateState(this);


    }
}
