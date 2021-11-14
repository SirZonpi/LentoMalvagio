using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossBaseState : MonoBehaviour
{
    public abstract void EnterState(BossStateManager boss);
    public abstract void UpdateState(BossStateManager boss);
    public abstract void onCollisionEnter(BossStateManager boss);
}
