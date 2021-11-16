using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelGameOver : MonoBehaviour
{
    public int attiva;

    public void Disattiva(int _attiva)
    {
        attiva = _attiva;
    }

    private void Update()
    {
        if (attiva == 1)
        {
            gameObject.SetActive(false);
            attiva = 0;
        }
    }
}
