using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LupoBaseState : MonoBehaviour
{
    public abstract void EnterState(LupoStateManager minion);
    public abstract void UpdateState(LupoStateManager minion);
    public abstract void onCollisionEnter(LupoStateManager minion);
}
