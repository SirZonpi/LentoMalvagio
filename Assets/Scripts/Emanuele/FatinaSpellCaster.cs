using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FatinaSpellCaster : Enemy
{
    [SerializeField] float enemyDistance;
    [SerializeField] NavMeshAgent _agent;
    public GameObject playerTransform;
    Vector3 newPos;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject spellSpawnPoint;

    Vector3 dir ;
    float timeRate = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void CastSpell()
    {
        Debug.Log("spella");
        
        GameObject bulletSpell = Instantiate(bulletPrefab, spellSpawnPoint.transform.position, Quaternion.identity) as GameObject;
        FatinaBullet fb = bulletSpell.GetComponent<FatinaBullet>();
        dir = (transform.forward);
        if(bulletPrefab != null)
        fb.Setup(dir);

     }

   

    // Update is called once per frame
    void Update()
    {
      
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

                timeRate += Time.deltaTime;

                if (timeRate >= 1)
                {
                    //Debug.Log("time " + timeRate);
 
                    CastSpell();
                    timeRate = 0;
                }
            }
        }
     
    }
}
