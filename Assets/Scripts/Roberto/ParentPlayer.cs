using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; /// ema

public class ParentPlayer : MonoBehaviour
{
    Player player;
    public string scenaDiQuestoPrefab; //ema

    private void Start()
    {
        scenaDiQuestoPrefab = this.gameObject.scene.name; //ema
        player = GameManager.instance.player;
    }

    private void OnTriggerEnter(Collider other) //Se il giocatore sale su una piattaforma semovente, viene imparentato alla piattaforma così viene trasportato.
    {
        if(other.transform.CompareTag("Player"))
        {
            SceneManager.MoveGameObjectToScene(this.gameObject.transform.root.gameObject, SceneManager.GetSceneByName("ScenaPrincipale")); //ema
            player.transform.SetParent(transform);
        }
        
    }
    private void OnTriggerExit(Collider other)//appena scende viene sparentato
    {
        if(other.transform.CompareTag("Player"))
        {
            player.transform.SetParent(null);

            SceneManager.MoveGameObjectToScene(this.gameObject.transform.root.gameObject, SceneManager.GetSceneByName(scenaDiQuestoPrefab)); //ema

        }
       

    }
}
