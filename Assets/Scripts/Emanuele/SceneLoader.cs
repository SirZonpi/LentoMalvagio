using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    bool doOnce=true;
    Player player;

    GameObject puntoSpawnLivello2;
    GameObject puntoSpawnLivelloBoss;

    public string scenaDaCaricare;
    public string scenaDaScaricare;

    public string musica;
    public string musicaDisattiva;

    public GameObject panelLivelloSuperato;

    private void Start()
    {
        player = GameManager.instance.player;
        puntoSpawnLivello2 = GameManager.instance.spawnLivello2;
        puntoSpawnLivelloBoss = GameManager.instance.spawnLivelloBoss;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && doOnce==true)
        {
            doOnce = false;
            SceneManager.LoadSceneAsync(scenaDaCaricare, LoadSceneMode.Additive);

            SceneManager.UnloadSceneAsync(scenaDaScaricare);

            if (scenaDaCaricare == "Scena2")
            {
                player.transform.position = puntoSpawnLivello2.transform.position;
                panelLivelloSuperato.SetActive(true);
            }

            else
            {
                player.transform.position = puntoSpawnLivelloBoss.transform.position;
                panelLivelloSuperato.SetActive(true);
            }


            GameManager.instance.audioManager.SwapMusicLevel(musicaDisattiva,musica);

        }
    }

}
