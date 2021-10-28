using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatinaBullet : MonoBehaviour
{
    GameObject playerTransform;
    Vector3 direzione;
    Rigidbody rb;
    float speed = 2f;


    public void Setup(Vector3 shootDir)
    {
        direzione = shootDir;
       
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector2(0, 0);
  
        rb.AddForce(shootDir * speed, ForceMode.Impulse);
        

    }

    IEnumerator disattiva()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
