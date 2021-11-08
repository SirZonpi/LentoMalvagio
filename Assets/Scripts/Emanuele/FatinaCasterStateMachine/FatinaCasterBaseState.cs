using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FatinaCasterBaseState : MonoBehaviour
{
    public abstract void EnterState(FatinaCasterStateManager goblin);
    public abstract void UpdateState(FatinaCasterStateManager goblin);
    public abstract void onCollisionEnter(FatinaCasterStateManager goblin);

}
