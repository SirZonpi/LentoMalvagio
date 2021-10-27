using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor=0.05f; //fattore di scala, intesità rallentamento
    public float slowdownLenght=2f; //durata effetto

    private void Update()
    {
        Time.timeScale += ( 1 / slowdownLenght) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

    }

    public void SlowMotion()
    {
        Time.timeScale = slowdownFactor; // 1/ 0.05 = 20, il tempo scorre 20 volte più lentamente del normale

        Time.fixedDeltaTime = Time.timeScale * 0.02f;

    }

}
