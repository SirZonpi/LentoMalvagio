using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestoHit : MonoBehaviour
{

    private void OnEnable()
    {
        Destroy(this.gameObject, .8f);
    }

}
