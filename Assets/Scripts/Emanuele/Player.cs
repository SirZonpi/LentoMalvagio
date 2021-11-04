using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    public int minionsKilled = default; //1000 per debug
    public GameObject prefabAnime;

    public string currentLevel;

    public string livelloDifficolta;

    public List<GameObject> animeRecuperabili;


    void Start()
    {

        if (GameManager.isLoaded == true)
        {
            GameManager.instance.LoadPlayer();

        }
        else
        {
            Health = maxHealth;
        }

        animeRecuperabili = new List<GameObject>();

    }

    private void Awake()
    {
        currentLevel = "Scena1";
        livelloDifficolta = "Normale";  ///aggiunto oggi

    }

    IEnumerator IncrementaHpCo()
    {
        float elapseTime = 0;
        float waitTime = 3;
        float tmp = 0;
        while (elapseTime < waitTime)
        {
            elapseTime += Time.deltaTime;
            tmp += Time.deltaTime;

            if (tmp >= 0.2f)
            {

                Health++;
                tmp = 0f;
            }

            yield return null;
        }
        yield return null;

    }


    /*
    private void OnEnable() //increedibilemnte anche se vuoto bloccava l'aggiunta della hp bar sul player...
    {
   
    }
    */

    //override dei metodi della classe base Entity
    public override void TakeDamage(int amount)
    {
        Debug.Log("Il player ha subito danno");
        base.TakeDamage(amount);
    }


    public override void RespawnPlayer() ///override fatto oggi
    {
  

        if (animeRecuperabili.Count != 0)
        {
            Destroy(animeRecuperabili[0].gameObject);
            animeRecuperabili.Remove(animeRecuperabili[0]);
        }

            GameObject anime = Instantiate(prefabAnime, transform); //istanzio il particellare delle anime perdute
            anime.transform.SetParent(null); //tolgo il parent al prefab
            RecuperaAnime.animeDaRecuperare = minionsKilled; //assegno il valore delle anime raccolte fin qui alla var statica animedarecuperare
            minionsKilled = 0; //resetto il valore delle anime raccolte

        animeRecuperabili.Add(anime);

        base.RespawnPlayer(); //le operazioni del metodo originario che si trova nella base class

    }

    public override void RestoreHealth()
    {
        StartCoroutine(IncrementaHpCo());
    }

    public override void KillEnemy()
    {
        Debug.Log("Il player è stato ucciso");
        base.KillEnemy();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("MAX " + maxHealth);
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(1);
           
        }
    }

    
}
