using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatinaBullet : MonoBehaviour
{
    GameObject playerTransform;
    Vector3 direzione;
    Rigidbody rb;
    float speed = 25f;

    public int attacco;

    public void Setup(Vector3 shootDir)
    {
        direzione = shootDir;
       
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector2(0, 0);
  
        rb.AddForce(shootDir * speed, ForceMode.Impulse);
        

    }

    IEnumerator disattiva()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
        yield return null;
    }

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnEnable()
    {
        StartCoroutine(disattiva());
    }


}
