using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// EMANUELE: CLASSE MADRE PER LA GESTIONE DI PLAYER E NEMICI
public class Entity : MonoBehaviour
{
    public int maxHealth; //vita massima
    [SerializeField] int currentHealth; //vita current

    public int attaccoFisico; /////
    public int attaccoMagico; //////

    public ParticleSystem psMorte;

    //creo due events statici (potrò accedervi per le sottoscrizioni dei metodi dagli script HpBar e HpBarController) sono quindi eventi generici e non legati a una istanza specifica.
    //ogni volta che una nuova entity viene creata chiamiamo questi due eventi. questi due eventi vengono chiamato
    //ogni volta che una hp bar viene aggiunta o rimossa
    public static event Action<Entity> OnHealthAdded = delegate { };
    public static event Action<Entity> OnHealthRemoved= delegate { };

    //questo evento rispetto ai due precedenti non è statico. viene chiamato ogni volta che la health di QUESTA entity cambia (una nuova istanza).
    //ogni vollta che la health di questo nemico cambia questo evento viene richiamato (vedi script hpbar)
    public event Action<float> OnHealthChanged = delegate { };

    private void OnEnable()
    {
        //controlliamo se si tratta del player o di un nemico (non vogliamo hp bar sopra la testa del player
        //nota: fare refactoring e spostare dichiarazione dei delegate da Entity a Enemy
        if (GetComponent<Player>() == false) 
        {
            OnHealthAdded(this); // se questa istanza non è il player allora, una volta abilitata, richiamiamo subito l'evento e passiamo come argomento questa stessa entity
        }
    }

    private void OnDisable()
    {
       // OnHealthRemoved(this); //da mettere dentro al metodo kill
    }


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
            else if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }

    }



    public virtual void TakeDamage(int amount) //danno base, override per eventuali cambiamenti nelle classi figlie
    {
        Health -= amount;

        float currentPChealth = (float)Health / (float)maxHealth; //per ottenere valori in percentuale da usare per la barra degli hp (casting perchè health ritorna int)

        OnHealthChanged(currentPChealth); //richiamo il delegate (sottoscrizioni ai delegate dichiarati verranno fatte negli script hpbar e HpBarController)

        Debug.Log("current health = " + Health);
    }

    public virtual void KillEnemy() //comportamento base per le kill, override nella rispattiva classe per comportamenti specifici
    {
        GameManager.instance.oggettidaDisattivare.Add(this.gameObject); //aggiungiasmo a una lista i character disattivati per riattivarli all 'occorrenza
        if (psMorte != null)
        {
            ParticleSystem ps = Instantiate(psMorte, transform.position, Quaternion.identity);
            ps.transform.SetParent(null);
            ps.Play();
            Destroy(ps, 1.5f);
        }

       gameObject.SetActive(false);

       OnHealthRemoved(this); //una volta disabilitato richiamiamo subito l'evento e passiamo come argomento questa stessa entity

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

   
    void Awake()
    {
        Health = maxHealth;

    }

    

}
