using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FatinaSpellCaster : Enemy
{
    public float enemyDistance;
    public NavMeshAgent _agent;
    public GameObject playerTransform;
    public Vector3 newPos;

    public GameObject bulletPrefab;
    public GameObject spellSpawnPoint;

    public Vector3 dir ;
    public float timeRate = 0f;

    //aggiunti oggi
    public Transform[] path;

    int currentPoint;

    public AudioSource audiosource;

    //aggiunti oggi
    public void MoveToPath()
    {
        if (_agent.remainingDistance < 0.5f)
        {
            _agent.destination = path[currentPoint].position;
            UpdateCurrentPoint();
        }
    }

    public void UpdateCurrentPoint()
    {
        if (currentPoint == path.Length - 1) //siamo nell ultimo nodo della path
        {
            currentPoint = 0;
        }
        else
        {
            currentPoint++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameManager.instance.player.transform.gameObject;
    }

    public void CastSpell()
    {
        Debug.Log("spella");
        
        GameObject bulletSpell = Instantiate(bulletPrefab, spellSpawnPoint.transform.position, Quaternion.identity) as GameObject;
        audiosource.PlayOneShot(audiosource.clip);
        FatinaBullet fb = bulletSpell.GetComponent<FatinaBullet>();
        fb.attacco = attaccoMagico;
        dir = (transform.forward);
        if(bulletPrefab != null)
        fb.Setup(dir);

    }

   

    // Update is called once per frame
    void Update()
    {

      /*
        float distance = Vector3.Distance(transform.position, playerTransform.transform.position);

        Debug.Log("distance " + distance);

        if (distance < enemyDistance)
        {

            Vector3 dirToPlayer = transform.position - playerTransform.transform.position;
            newPos = transform.position + dirToPlayer;

            _agent.SetDestination(newPos);

        }
        if(distance >= enemyDistance && distance <= 10f )
        {
            Vector3 direction = playerTransform.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10);
             
            // transform.LookAt(playerTransform.transform);

            Ray ray = new Ray(spellSpawnPoint.transform.position, spellSpawnPoint.transform.forward);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 8f);

            if (hit.transform != null && hit.transform.CompareTag("Player"))
            {
                Debug.Log("FATINA SPARA");
                timeRate += Time.deltaTime;

                if (timeRate >= 1)
                {
                    //Debug.Log("time " + timeRate);
 
                    CastSpell();
                    timeRate = 0;
                }
            }
        }
     
        */
    }
}
