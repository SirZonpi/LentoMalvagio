using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarPlayer : MonoBehaviour
{
    [SerializeField] Image barraImmagine;
    public Slider slider;

    public Gradient gradient;

    public void SetMaxhealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        barraImmagine.color = gradient.Evaluate(1f);//gradient verde
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        barraImmagine.color = gradient.Evaluate(slider.normalizedValue);//gradient verso il rosso
    }

}
