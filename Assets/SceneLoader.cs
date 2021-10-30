using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    bool doOnce=true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && doOnce==true)
        {
            doOnce = false;
            SceneManager.LoadSceneAsync("Scena2", LoadSceneMode.Additive);

        }
    }

}
