using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour {

    [SerializeField]
    GlobalControls GLOBAL_CONTROL;

    [SerializeField]
    CountdownClock CLOCK;
        
    [SerializeField]
    OriginalPositionCheck OPC;

    [SerializeField]
    NarratorController NARRATOR;

    public GameObject SNAPPING_POSITIONS;

    public GameObject[] BOOKS;

    public Animator TableAnimator;

    public GameObject GUIDE_BALL, BREATH_TRACKER, GRIP_BOX, PHONE;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void OnRevealSocket(){
        CLOCK.StartNewSecondsCountdown(10);
    }

    public void OnHideSocket(){
        TableAnimator.Play("book_tray_rise");
        NARRATOR.OnBookReveal();
    }

    public void SetBookTimer(){
        SNAPPING_POSITIONS.SetActive(true);
        CLOCK.StartNewMinutesCountdown(3, 0);
    }

    public void EnableBooks(){
        foreach(GameObject go in BOOKS){
            go.SetActive(true);
        }
    }

    public void EnablePhone(){
        GUIDE_BALL.SetActive(true);
        BREATH_TRACKER.SetActive(true);
        GRIP_BOX.SetActive(true);
        PHONE.SetActive(true);

        string timeString = GLOBAL_CONTROL.GetRemainingTime().ToString();
        string[] timeSplit = timeString.Split(".");

        int firstTwo = int.Parse(timeSplit[0]);
        int secondTwo = int.Parse(timeSplit[1]);

        Debug.Log(firstTwo + " " + secondTwo);

        //CLOCK.StartNewMinutesCountdown(3, 0);


    }
}
