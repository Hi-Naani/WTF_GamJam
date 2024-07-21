using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningStars : MonoBehaviour
{
    public Timer timer;
    public GameObject[] stars; 

    void Start()
    {
        timer = this.gameObject.GetComponent<Timer>();
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].SetActive(false);
        }
    }

    public void CallinMethodForStars()
    {
        Debug.Log("CallinMethodForStars called");
        StartCoroutine(EnablingStars());
        Debug.Log("CallinMethodForStars called");
    }

    IEnumerator EnablingStars()
    {
        Debug.Log("EnablingStars called");
        int timeLeft = (int)timer.timer;

        yield return new WaitForSeconds(0.5f);

        if (timeLeft >= 20)                  //>= 240
        {
            for (int i = 0; i < stars.Length; i++)
            {
                yield return new WaitForSeconds(0.5f);
                stars[i].SetActive(true);
                //play audio               
            }
        }
        else if (timeLeft > 15 && timeLeft <= 19)       //timeLeft > 150 && timeLeft <= 239
        {
            for (int i = 0; i < stars.Length - 1; i++)
            {
                yield return new WaitForSeconds(0.5f);
                stars[i].SetActive(true);
                //play audio
            }
        }
        else if (timeLeft > 5 && timeLeft <= 15)      //timeLeft > 149 && timeLeft <= 239
        {
            yield return new WaitForSeconds(0.5f);
            stars[0].SetActive(true);
            //play audio
        }

        StopCoroutine(EnablingStars());
    }
}
