using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
Allora il lupo mentre carica il colpo salta qua e là per schivare i colpi del player o allontanarsi dal play.
nel momento in cui deve sparare il colpo, spara e rimane fermo per tipo 1-2 sec (da stabilire) in quel momento il giocatore, 
    intanto schiva il colpo del lupo e prima che ritorna a muoversi o lo colpisce da vicino (se è abbastanza veloce) o gli spara qualche magia.
*/

public class Lupo : Enemy
{
    public GameObject playerTransform;

    public float attackRadius = default;

    public float timer;
    public float nextTime = default;
    public bool inRange;

    public NavMeshAgent _agent;

    public bool loadSpell;

    public GameObject bulletPrefab;
    public GameObject spellSpawnPoint;

    Vector3 dir;
    Vector3 newPos;

    [SerializeField] float enemyDistance;


    // Start is called before the first frame update
    void Start()
    {
        // playerTransform = GameObject.FindGameObjectWithTag("Player");///

        playerTransform = GameManager.instance.player.transform.gameObject;


    }

    public void CastSpell()
    {
        GameObject bulletSpell = Instantiate(bulletPrefab, spellSpawnPoint.transform.position, Quaternion.identity) as GameObject;
        bulletSpell.transform.SetParent(null);
        LupoBullet lb = bulletSpell.GetComponent<LupoBullet>();
        dir = (transform.forward);
        if (bulletPrefab != null)
            //lb.Setup(dir);
            StartCoroutine(lb.ScaleBullet(dir));
    }

    float time = 0f;
    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, playerTransform.transform.position);
        Debug.Log("distance " + distance);


        if (distance <= attackRadius && distance>=2)
        {
            loadSpell = true;

            Vector3 direction = playerTransform.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10);

        }
        else { loadSpell = false; }

        /*
        if (distance < 2)
        {
            Vector3 dirToPlayer = transform.position - playerTransform.transform.position;
           newPos = transform.position + dirToPlayer;

           _agent.SetDestination(newPos);
        }
        */

        if (loadSpell)
        {

         
            Debug.Log("TTTTT " + time);

            if (time <= 4f)
            {
                time += Time.deltaTime;
                if (time >= 4f)
                {
                    CastSpell();
                    time = 0f;
                }
           
            }
        }

        if ( distance <= attackRadius)
        {
           
        }
          


    }
}
