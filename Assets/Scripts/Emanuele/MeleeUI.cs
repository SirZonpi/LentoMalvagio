using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeUI : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Sprite iconaMelee;
    [SerializeField] Sprite iconaSpadaFuoco;

    [SerializeField] Image filler;

    Image questaIcona;

    Vector2 startSize;
    Vector2 targetSize;

    public IEnumerator SpadaInfuocataUI()
    {
        float elapsedTime=0;
        float waitTime = player.durataPowerupSpada;

        while (elapsedTime< waitTime)
        {
            filler.rectTransform.sizeDelta = Vector2.Lerp(startSize, targetSize, elapsedTime / waitTime);
        
            elapsedTime += Time.deltaTime;

            yield return null;

        }

        filler.rectTransform.sizeDelta = targetSize;
        yield return new WaitForSeconds(0.3f);
        filler.rectTransform.sizeDelta = startSize;
        questaIcona.sprite = iconaMelee;

        yield return null;

    }

    public void CambiaIconaSpada()
    {
        questaIcona.sprite = iconaSpadaFuoco;
        StartCoroutine(SpadaInfuocataUI());
    }

    void Start()
    {
        startSize = new Vector2(0, 0);
        targetSize = new Vector2(100, 100);
        questaIcona = GetComponent<Image>();
        questaIcona.sprite = iconaMelee;
    }

   

}
