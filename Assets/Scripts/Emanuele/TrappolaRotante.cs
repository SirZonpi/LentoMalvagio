using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrappolaRotante : MonoBehaviour
{
    [SerializeField] float velocitaRotazione;
 
    void Update()
    {
        transform.Rotate(0f, velocitaRotazione * Time.deltaTime, 0f);
    }
}
