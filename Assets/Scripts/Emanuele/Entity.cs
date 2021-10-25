using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EMANUELE: CLASSE MADRE PER LA GESTIONE DI PLAYER E NEMICI
public class Entity : MonoBehaviour
{
    public int maxHealth; //vita massima
    [SerializeField] int currentHealth; //vita current

    public int Health //property: con un getter prendiamo il valore di current health, con un setter impostiamo il nuovo valore e il cap prima di uccidere l entity
    {
        get { return currentHealth; }

        set { currentHealth = value; //curent health avrà il valore impostato dai vari metodi (takedamage() ecc..
        
            if(currentHealth <= 0) //controlliamo subito con la property se currenthealth scende sotto 0
            {
                if (gameObject.GetComponent<Enemy>()) //se è un nemico lo uccidiamo/disattiviamo
                    KillEnemy();
                else if (gameObject.GetComponent<Player>()) //se è il player lo facciamo respawnare
                    RespawnPlayer();
            }
        }

    }

    public GameObject mesh;

    public virtual void TakeDamage() //danno base, override per eventuali cambiamenti
    {
        Health -= 5;
        Debug.Log("current health = " + Health);
    }

    public virtual void KillEnemy() //comportamento base per le kill, override nella rispattiva classe per comportamenti specifici
    {
       GameManager.instance.oggettidaDisattivare.Add(this.gameObject); //aggiungiasmo a una lista i character disattivati per riattivarli all 'occorrenza
       gameObject.SetActive(false);
     
    }

    public virtual void RestoreHealth()
    {
        Health = maxHealth;
    }

    public virtual void RespawnPlayer()
    {    
        RestoreHealth();
        transform.position = CheckPoints.GetActiveCheckPointPosition();
    }

    // Start is called before the first frame update
    void Awake()
    {
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
