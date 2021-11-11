using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchivataUI : MonoBehaviour
{
    [SerializeField] PlayerMove player;
    [SerializeField] Sprite iconaSchivata;
    //[SerializeField] Sprite iconaSpadaFuoco;

    [SerializeField] Image filler;

    Image questaIcona;

    Vector2 startSize;
    Vector2 targetSize;

    public IEnumerator SchivataCo()
    {
        float elapsedTime = 0;
        float waitTime = player.rollDistance;

        while (elapsedTime < waitTime)
        {
            elapsedTime += Time.deltaTime;
            filler.gameObject.SetActive(true);
            yield return null;

        }

        filler.gameObject.SetActive(false);
        yield return null;

    }


    void Start()
    {
        filler.gameObject.SetActive(false);
        questaIcona = GetComponent<Image>();
    }

}
