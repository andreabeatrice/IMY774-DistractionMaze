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
    }

    public void SetBookTimer(){
        CLOCK.StartNewMinutesCountdown(3, 0);
    }
}
