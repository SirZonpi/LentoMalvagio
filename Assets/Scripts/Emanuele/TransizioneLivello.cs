using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransizioneLivello : MonoBehaviour
{
    [SerializeField] Animator anim;
    IEnumerator delay()
    {
        anim.Play("TEST");
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
        yield return null;

    }

    private void OnEnable()
    {
        StartCoroutine(delay());
    }

}
