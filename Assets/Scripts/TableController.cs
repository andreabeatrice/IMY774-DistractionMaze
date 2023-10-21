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
}
