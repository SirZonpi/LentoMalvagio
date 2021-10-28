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

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void CastSpell()
    {
        Debug.Log("spella");
        transform.LookAt(playerTransform.transform);
        GameObject bulletSpell = Instantiate(bulletPrefab, spellSpawnPoint.transform.position, Quaternion.identity) as GameObject;
        FatinaBullet fb = bulletSpell.GetComponent<FatinaBullet>();
        fb.Setup(dir);
        //bulletSpell.transform.position += playerTransform.transform.position;
     }

    // Update is called once per frame
    void Update()
    {
    
        float distance = Vector3.Distance(transform.position, playerTransform.transform.position);

        if (distance < enemyDistance)
        {

            Vector3 dirToPlayer = transform.position - playerTransform.transform.position;
            newPos = transform.position + dirToPlayer;

            _agent.SetDestination(newPos);

        }
        if(distance >= enemyDistance)
        {
            dir = spellSpawnPoint.transform.right; ////
            CastSpell();
        }
    }
}
