using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransizioneLivello : MonoBehaviour
{
    IEnumerator delay()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
        yield return null;

    }

    private void OnEnable()
    {
        StartCoroutine(delay());
    }

}
