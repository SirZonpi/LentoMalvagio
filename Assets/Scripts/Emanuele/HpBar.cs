using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    Player player; //i serve per calcolare la distanza tra il player e l'entity che possiede un'istanza di questa barra hp

    [SerializeField] Image sfondoImmagine; 
    [SerializeField] Image barraImmagine;

    [SerializeField] float velocitaAggiornamento; //quanto velocemente i valori della barra hp (l immagine che fa da filler nel canvas)  devono lerpare

    [SerializeField] float offesetY; //per posizionare la barra sopra la testa dell entity

    [SerializeField] Entity entityHealth; //lo mostro nell inspector solo a fini di debug

    [SerializeField] float distanzaDalPlayer=default; //per far comparire la barra hp solo quando il player è abbastanza vicino

    public void SetHealth(Entity entityHealth)
    {
        this.entityHealth = entityHealth;
        entityHealth.OnHealthChanged += HandleHealthChanged; //sottoscriviamo la funzione all event nello script entity
    }

    void HandleHealthChanged(float percentuale) //fa partire la coroutine per il rimpicciolimento della barra hp
    {
        StartCoroutine(Percentuale(percentuale));
    }

    IEnumerator Percentuale(float pct)
    {
        float preChange = barraImmagine.fillAmount;
        float elapsedTime = 0f;

        while (elapsedTime< velocitaAggiornamento)
        {
            elapsedTime += Time.deltaTime;
            barraImmagine.fillAmount = Mathf.Lerp(preChange, pct, elapsedTime / velocitaAggiornamento);
            yield return null;
        }

        barraImmagine.fillAmount = pct;

    }

    private void Start()
    {
        player = GameManager.instance.player;
    }

    private void LateUpdate()
    {
        if (entityHealth != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(entityHealth.transform.position + Vector3.up * offesetY); //posizione della hp bar nello spazio mondo
        }
    }

    private void OnDisable()
    {
        entityHealth.OnHealthChanged -= HandleHealthChanged; //rimuoviamo la sottoscrizione al delegate
    }

    private void OnDestroy()
    {
        entityHealth.OnHealthChanged -= HandleHealthChanged; //rimuoviamo la sottoscrizione al delegate
    }

    private void Update()
    {
        //la barra deve comparire solo se il player e l'entity a cui è associata questa barra hp sono abbastanza vicini

        //Debug.Log("DISTANZA " + Vector3.Distance(transform.position, player.transform.position));

        if (entityHealth != null)
        {
            if (Vector3.Distance(entityHealth.transform.position, player.transform.position) <= distanzaDalPlayer)
            {
                sfondoImmagine.enabled = true;
                barraImmagine.enabled = true;
            }
            else if (Vector3.Distance(entityHealth.transform.position, player.transform.position) > distanzaDalPlayer)
            {
                sfondoImmagine.enabled = false;
                barraImmagine.enabled = false;
            }
        }
    }

}
