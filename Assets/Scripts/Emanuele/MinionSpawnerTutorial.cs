using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawnerTutorial : MonoBehaviour
{
    //per mantenere almeno un minion sempre presente nella zona iniziale del tuorial. può essere utile al player per sperimentare con le combo

    public GameObject minionPrefab; //il prefab da far spawnare

    public List<GameObject> minionlist; //ogni spawn finisce in questa lista

    // Start is called before the first frame update
    void Start()
    {

        minionlist = new List<GameObject>(); //inizializzo la lista

        GameObject min = Instantiate(minionPrefab, transform.position, Quaternion.identity, null ); //creo il primo minion

        minionlist.Add(min); //lo aggiungo alla lista

    }

    void SpawnaMinion() //funzione per creare nuovi minion
    {
        if (minionlist.Count == 0) //voglio che si esegua solo se la lista è vuota. voglio un minion per volta
        {
            GameObject min = Instantiate(minionPrefab, transform.position, Quaternion.identity, null);

            minionlist.Add(min);
        }
  
    }

    void RimuoviMinionDaLista() //quando il minion nella lista è disattivato, quindi è stato ucciso dal player, pulisco la lista
    {
        if (minionlist.Count != 0) //deve essere eseguita solo se la lista non è già vuota
        {
            if (!minionlist[0].gameObject.activeInHierarchy)
            {
                minionlist.Clear();
            }
        }
    }

    IEnumerator delayCo() //delay per lo spawn
    {
        yield return new WaitForSeconds(1.5f);
        SpawnaMinion();

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        RimuoviMinionDaLista();

        if (minionlist.Count <= 0)
        {
             StartCoroutine(delayCo());
          //  SpawnaMinion();

        }
    }
}
