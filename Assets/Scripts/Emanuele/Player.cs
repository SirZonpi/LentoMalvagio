using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : Entity
{

    public int minionsKilled = default; //1000 per debug
    public GameObject prefabAnime;

    public string currentLevel;

    public string livelloDifficolta;

    public List<GameObject> animeRecuperabili;

    public GameObject spellPrefab;
    public Transform spellSpawnPoint;

    public HpBarPlayer hpbar;

    public bool powerUpSpada = false;
    public float durataPowerupSpada;
    public float durataPowerupMana;
    public GameObject spadaInfuocata;

    [SerializeField] MeleeUI iconaMelee;
    [SerializeField] ManaUI iconaMagia;

    public float fireRate = 1f; // posso spare ogni x
    public float timeToNextShot; // tempo di attesa

    public Text animeText;

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

        hpbar.SetMaxhealth(Health);

        spadaInfuocata.SetActive(false);

        animeText.text = minionsKilled.ToString();

    }

    private void Awake()
    {
        currentLevel = "Scena1";
        livelloDifficolta = "Normale";  ///aggiunto oggi

    }

    public void CambiaTestoAnime()
    {
        animeText.text = minionsKilled.ToString();
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

   public IEnumerator ManaPowerUp()
    {
        fireRate = 0;
        yield return new WaitForSeconds(durataPowerupMana);
        fireRate = 2;
        yield return null;

    }

    public void CastSpell()
    {
        if (Time.time>timeToNextShot)
        {
            iconaMagia.StartCoroutine(iconaMagia.MagiaCo());
            timeToNextShot = Time.time + fireRate;
            GameObject spell = Instantiate(spellPrefab, spellSpawnPoint.position, Quaternion.identity);

            Rigidbody rb = spell.GetComponent<Rigidbody>();
            rb.velocity = new Vector2(0, 0);

            rb.AddForce(transform.forward * 8, ForceMode.Impulse);

            Destroy(spell, 1.5f);
        }

    }

    /*
    private void OnEnable() //increedibilemnte anche se vuoto bloccava l'aggiunta della hp bar sul player...
    {
   
    }
    */

    public void RiattivaElementi()
    {
        foreach (GameObject  go in GameManager.instance.oggettidaDisattivare)
        {
            go.SetActive(true);
        }
    }

    public IEnumerator SpadaInfuocata()
    {

        iconaMelee.CambiaIconaSpada();
        powerUpSpada = true;
        int tmp = attaccoFisico;
        attaccoFisico += 5;
        spadaInfuocata.SetActive(true);
        yield return new WaitForSeconds(durataPowerupSpada);
        attaccoFisico = tmp;
        spadaInfuocata.SetActive(false);
        powerUpSpada = false;

    }



    //override dei metodi della classe base Entity
    public override void TakeDamage(int amount)
    {
        hpbar.SetHealth(Health-amount);

        Debug.Log("Il player ha subito danno" + amount);
        base.TakeDamage(amount);

        
    }


    public override void RespawnPlayer() ///override fatto oggi
    {
        RiattivaElementi();

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

        hpbar.SetHealth(maxHealth);
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
