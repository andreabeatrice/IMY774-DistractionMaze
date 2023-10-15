using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorController : MonoBehaviour{
    
    [SerializeField]
    private Animator POST_PROCESSOR, THE_TABLE, THE_TARGET, THE_LIGHT;

    [SerializeField]
    private AudioSource Narrator;

    [SerializeField]
    GameObject DistanceInteractorLeft, DistanceInteractorRight;

    [SerializeField]
    OriginalPositionCheck OPC;

    public AudioClip YouKnowEvenThoughThisRoomIsVeryEmpty, GoOnPickItUp, WellDoneOnPickingItUp, ShameYouMissed, FingersChangingColor, ThatTookLongAudio, PleaseReturnAudio;

    private bool FirstTouchPickUp, DistancePickupTutorial;

    // Start is called before the first frame update
    void Start(){
        POST_PROCESSOR.Play("Eyes Open");

        StartCoroutine(WaitForWakeup());

        FirstTouchPickUp = true;
        DistancePickupTutorial = true;
        
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
            
        } else {
            Narrator.clip = PleaseReturnAudio;
            Narrator.Play();
            THE_LIGHT.Play("colour_change");

            StartCoroutine(PleaseReturn());

        }

    }

    // public void SummonedTheBall(){
    //       if (FirstSummoning){

    //         FirstSummoning = false; 

           

    //     }
    // }
}
