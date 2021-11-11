using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaUI : MonoBehaviour
{
     
    [SerializeField] Player player;
    [SerializeField] Sprite iconaMagia;
    Image questaIcona;

    [SerializeField] Image filler;

    public IEnumerator MagiaCo()
    {
        float elapsedTime = 0;
        float waitTime = player.fireRate;

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
        questaIcona.sprite = iconaMagia;
    }

    


}
