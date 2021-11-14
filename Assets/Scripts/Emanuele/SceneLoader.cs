using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    bool doOnce=true;
    Player player;

    GameObject puntoSpawnLivello2;

    Enemy[] enemies;

    private void Start()
    {
        player = GameManager.instance.player;
        puntoSpawnLivello2 = GameManager.instance.spawnLivello2;

        enemies =  Enemy.FindObjectsOfType<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && doOnce==true)
        {
            doOnce = false;
            SceneManager.LoadSceneAsync("Scena2", LoadSceneMode.Additive);

            foreach (Enemy enemy in enemies)
            {
                //enemy.KillEnemy();

               

                //Destroy(enemy);
            }

            SceneManager.UnloadSceneAsync("Scena1");

            player.transform.position = puntoSpawnLivello2.transform.position;

        }
    }

}
