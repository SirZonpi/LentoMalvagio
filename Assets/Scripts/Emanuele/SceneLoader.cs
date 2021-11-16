using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    bool doOnce=true;
    Player player;

    GameObject puntoSpawnLivello2;

    public string scenaDaCaricare;
    public string scenaDaScaricare;

    public string musica;

    private void Start()
    {
        player = GameManager.instance.player;
        puntoSpawnLivello2 = GameManager.instance.spawnLivello2;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && doOnce==true)
        {
            doOnce = false;
            SceneManager.LoadSceneAsync(scenaDaCaricare, LoadSceneMode.Additive);

            SceneManager.UnloadSceneAsync(scenaDaScaricare);

            player.transform.position = puntoSpawnLivello2.transform.position;

            GameManager.instance.audioManager.PlaySound(musica);

        }
    }

}
