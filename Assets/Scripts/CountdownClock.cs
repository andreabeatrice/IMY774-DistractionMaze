using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownClock : MonoBehaviour
{

    public int TimeToGoFirstDigits, TimeToGoSecondDigits;
    [SerializeField] TMP_Text firstTwoDigits, secondTwoDigits, divider;
    [SerializeField] AudioSource buzzer, digitalTick;

    protected bool paused;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        //firstTwoDigits.text = TimeToGoFirstDigits.ToString() ;
        //secondTwoDigits.text = TimeToGoSecondDigits.ToString() ;
        //StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        //transform.GetComponent<TextMesh>().text

        if ( paused == true){
            
        }
    }

    public IEnumerator Countdown(){
        yield return new WaitForSeconds(1f);

        
        if (TimeToGoSecondDigits > 0) {
           
            TimeToGoSecondDigits -= 1;
            firstTwoDigits.color = new Color32(255, 255, 255, 255);
            secondTwoDigits.color = new Color32(255, 255, 255, 255);
            divider.color = new Color32(255, 255, 255, 255);

            if(TimeToGoSecondDigits != 0){
                digitalTick.Play();
                StartCoroutine(Countdown());
            }
            
        }
        
        if (TimeToGoSecondDigits == 0)  {
           firstTwoDigits.color = new Color32(255, 0, 0, 255);
           secondTwoDigits.color = new Color32(255, 0, 0, 255);
           divider.color = new Color32(255, 0, 0, 255);
           buzzer.Play();

        }

        if (TimeToGoSecondDigits < 10) {
            
            secondTwoDigits.text = "   0" + TimeToGoSecondDigits.ToString() ;
        }
        else {
            secondTwoDigits.text = "   " + TimeToGoSecondDigits.ToString() ;
        }

    }

    public void StartNewSecondsCountdown(int seconds){
        TimeToGoSecondDigits = seconds;

        firstTwoDigits.color = new Color32(255, 255, 255, 255);
        secondTwoDigits.color = new Color32(255, 255, 255, 255);
        divider.color = new Color32(255, 255, 255, 255);

         if (TimeToGoSecondDigits < 10) {
            
            secondTwoDigits.text = "   0" + TimeToGoSecondDigits.ToString() ;
        }
        else {
            secondTwoDigits.text = "   " + TimeToGoSecondDigits.ToString() ;
        }

        firstTwoDigits.text = "00";
        digitalTick.Play();

        if (paused == false){
            StartCoroutine(Countdown());
        }
        

    }

    public void StartNewMinutesCountdown(int minutes, int seconds){
        TimeToGoFirstDigits = minutes;
        TimeToGoSecondDigits = seconds;

        firstTwoDigits.color = new Color32(255, 255, 255, 255);
        secondTwoDigits.color = new Color32(255, 255, 255, 255);
        divider.color = new Color32(255, 255, 255, 255);

        
        if (TimeToGoFirstDigits < 10) {
            
            firstTwoDigits.text = "0" + TimeToGoFirstDigits.ToString() ;
        }
        else {
            firstTwoDigits.text = TimeToGoFirstDigits.ToString() ;
        }


        if (TimeToGoSecondDigits < 10) {
            
            secondTwoDigits.text = "   0" + TimeToGoSecondDigits.ToString() ;
        }
        else {
            secondTwoDigits.text = "   " + TimeToGoSecondDigits.ToString() ;
        }

        if (paused == false){
            StartCoroutine(CountdownMinutes());
        }
    }

    public IEnumerator CountdownMinutes(){

        yield return new WaitForSeconds(1f);

        if(TimeToGoFirstDigits > 0 || TimeToGoSecondDigits > 0){
            if (TimeToGoSecondDigits == 0){
                TimeToGoFirstDigits -= 1;
                TimeToGoSecondDigits = 60;
            }

            TimeToGoSecondDigits -= 1;
        }
        else {
            firstTwoDigits.color = new Color32(255, 0, 0, 255);
            secondTwoDigits.color = new Color32(255, 0, 0, 255);
            divider.color = new Color32(255, 0, 0, 255);
            buzzer.Play();
        }


        if (TimeToGoFirstDigits < 10) {
            
            firstTwoDigits.text = "0" + TimeToGoFirstDigits.ToString() ;
        }
        else {
            firstTwoDigits.text = TimeToGoFirstDigits.ToString() ;
        }

        if (TimeToGoSecondDigits < 10) {
            
            secondTwoDigits.text = "   0" + TimeToGoSecondDigits.ToString() ;
        }
        else {
            secondTwoDigits.text = "   " + TimeToGoSecondDigits.ToString() ;
        }

        if(paused == false){
            StartCoroutine(CountdownMinutes());
        }
        

    }

    public void StopTimer(){
        StopAllCoroutines();
    }

    public float GetClockValue(){
        string number = TimeToGoFirstDigits + "," + TimeToGoSecondDigits;
        return float.Parse(number);

    }

    public void Pause(){
        paused = true;
    }

    public void Resume(){
        paused = false;
    }
}
