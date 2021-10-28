using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GoblinBaseState : MonoBehaviour
{
    public abstract void EnterState(GoblinStateManager goblin);
    public abstract void UpdateState(GoblinStateManager goblin);
    public abstract void onCollisionEnter(GoblinStateManager goblin);

}
