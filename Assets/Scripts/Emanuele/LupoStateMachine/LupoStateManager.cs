using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LupoStateManager : MonoBehaviour
{
    LupoBaseState currentLupoState;

    public LupoIdleState idleState; 
    public LupoJumpState jumpState; 
    public LupoDamageState damageState; 
    public LupoAttackState attackState; 

    public void SwitchState(LupoBaseState lupoState)
    {
        currentLupoState = lupoState;
        lupoState.EnterState(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLupoState = idleState;
        currentLupoState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentLupoState.UpdateState(this);
    }
}
