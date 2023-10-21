using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorController : MonoBehaviour{

    [SerializeField]
    GlobalControls GLOBAL_CONTROL;

    [SerializeField]
    CountdownClock CLOCK;
    
    [SerializeField]
    private Animator POST_PROCESSOR, THE_TABLE, THE_TARGET, THE_LIGHT;

    [SerializeField]
    private AudioSource Narrator;

    [SerializeField]
    GameObject DistanceInteractorLeft, DistanceInteractorRight;

    [SerializeField]
    OriginalPositionCheck OPC;

    public AudioClip YouKnowEvenThoughThisRoomIsVeryEmpty, GoOnPickItUp, WellDoneOnPickingItUp, ShameYouMissed, FingersChangingColor, ThatTookLongAudio, PleaseReturnAudio, SocketAudio, WellDoneAudio, YouWillBeTimed, BookInstructions, ByColorResponseAudio;

    private bool FirstTouchPickUp, DistancePickupTutorial;

    // Start is called before the first frame update
    void Start(){
        if(!GLOBAL_CONTROL.GetTesting()){
            POST_PROCESSOR.Play("Eyes Open");

            StartCoroutine(WaitForWakeup());

            FirstTouchPickUp = true;
            DistancePickupTutorial = true;
        }
        else {
            ShowDistanceGrab();
            FirstTouchPickUp = false;
            DistancePickupTutorial = false;
            THE_TABLE.Play("reveal_ball");
            THE_TARGET.Play("show_target");
        }
        
    }

    // Update is called once per frame
    void Update(){
        OVRInput.Update();
    }

    void FixedUpdate()
    {
        OVRInput.FixedUpdate();
    }

    private IEnumerator WaitForWakeup(){
        DistanceInteractorLeft.SetActive(false);
        DistanceInteractorRight.SetActive(false);
        
        //10f
        yield return new WaitForSeconds(1f);
        

        Narrator.Play();

        StartCoroutine(WaitForLookAround());
    }

    private IEnumerator WaitForLookAround(){
        yield return new WaitForSeconds(12f);

        Narrator.clip = YouKnowEvenThoughThisRoomIsVeryEmpty;

        Narrator.Play();

        StartCoroutine(RevealTheBall());
    }

    private IEnumerator RevealTheBall(){
        yield return new WaitForSeconds(4f);

        THE_TABLE.Play("reveal_ball");

        StartCoroutine(PickItUp());

    }

    private IEnumerator PickItUp(){
        yield return new WaitForSeconds(3f);

        Narrator.clip = GoOnPickItUp;

        Narrator.Play();
    }


    public void WellDone(){

        if (FirstTouchPickUp){
            StopAllCoroutines();

            FirstTouchPickUp = false; 

            THE_TARGET.Play("show_target_long");

            Narrator.clip = WellDoneOnPickingItUp;

            Narrator.Play();

        }

    }

    public void YouMissed() {
        if (DistancePickupTutorial) {
            DistancePickupTutorial = false;

            Narrator.clip = ShameYouMissed;

            Narrator.Play();

            StartCoroutine(ExplainFingers());

            ShowDistanceGrab();
        }
    }

    public void ShowDistanceGrab(){
        DistanceInteractorLeft.SetActive(true);
        DistanceInteractorRight.SetActive(true);
    }

    public IEnumerator ExplainFingers(){
        yield return new WaitForSeconds(13f);

        Narrator.clip = FingersChangingColor;

        Narrator.Play();
    }

    public void ThatTookLong(){
        Narrator.clip = ThatTookLongAudio;

        Narrator.Play();

        StartCoroutine(PleaseReturn());
    }

    public IEnumerator PleaseReturn(){
        yield return new WaitForSeconds(3f);

        if (OPC.InArea == true){
            THE_LIGHT.Play("DefaultState");
            Narrator.clip = SocketAudio;
            Narrator.Play();

            THE_TABLE.Play("socket_tray_rise");
            StartCoroutine(ShowSocket());
            //CLOCK.StartNewSecondsCountdown(10);
            
        } else {
            Narrator.clip = PleaseReturnAudio;
            Narrator.Play();
            THE_LIGHT.Play("colour_change");

            StartCoroutine(PleaseReturn());

        }

    }

    public IEnumerator ShowSocket(){
        yield return new WaitForSeconds(1.5f);

        THE_TABLE.Play("socket_tray_rise");

    }

    public void OnSocketSuccess(){
        Narrator.clip = WellDoneAudio;

        Narrator.Play();

        THE_TABLE.Play("hide_socket");

        //THE_TABLE.Play("reveal_books");
        //WellDoneAudio
    }

    public void OnBookReveal(){
        Narrator.clip = YouWillBeTimed;

        Narrator.Play();

        StartCoroutine(BookOrganizingInstructions());
    }

    public IEnumerator BookOrganizingInstructions(){
        yield return new WaitForSeconds(6f);

        Narrator.clip = BookInstructions;
        Narrator.Play();

    }

    public void OrganizedByColourResponse(){
        Narrator.clip = ByColorResponseAudio;
        Narrator.Play();
    }
    

    // public void SummonedTheBall(){
    //       if (FirstSummoning){

    //         FirstSummoning = false; 

           

    //     }
    // }
}
