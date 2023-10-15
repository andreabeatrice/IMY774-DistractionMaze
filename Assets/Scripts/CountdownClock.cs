using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownClock : MonoBehaviour
{

    public int TimeToGoFirstDigits;
    [SerializeField] TMP_Text firstTwoDigits;
    // Start is called before the first frame update
    void Start()
    {

        firstTwoDigits.text = TimeToGoFirstDigits.ToString() ;
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        //transform.GetComponent<TextMesh>().text
    }

    public IEnumerator Countdown(){
        yield return new WaitForSeconds(1f);

        TimeToGoFirstDigits -= 1;

        if (TimeToGoFirstDigits > 0) {
            firstTwoDigits.color = new Color32(255, 255, 255, 255);
            StartCoroutine(Countdown());
        }
        else {
           firstTwoDigits.color = new Color32(255, 0, 0, 255);

        }

        if (TimeToGoFirstDigits < 10) {
            firstTwoDigits.text = "0" + TimeToGoFirstDigits.ToString() ;
        }
        else {
            firstTwoDigits.text = TimeToGoFirstDigits.ToString() ;
        }

    }

    public void StartNewSecondsCountdown(int seconds){
        TimeToGoFirstDigits = seconds;
        firstTwoDigits.color = new Color32(255, 255, 255, 255);
        firstTwoDigits.text = TimeToGoFirstDigits.ToString();
        StartCoroutine(Countdown());
    }
}
