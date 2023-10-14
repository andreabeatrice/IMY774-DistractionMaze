using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorController : MonoBehaviour{
    
    [SerializeField]
    private Animator POST_PROCESSOR, THE_TABLE, THE_TARGET;

    [SerializeField]
    private AudioSource Narrator;

    [SerializeField]
    GameObject DistanceInteractorLeft, DistanceInteractorRight;

    public AudioClip YouKnowEvenThoughThisRoomIsVeryEmpty, GoOnPickItUp, WellDoneOnPickingItUp, ShameYouMissed, FingersChangingColor;

    private bool FirstTouchPickUp, DistancePickupTutorial, FirstSummoning;

    // Start is called before the first frame update
    void Start(){
        POST_PROCESSOR.Play("Eyes Open");

        StartCoroutine(WaitForWakeup());

        FirstTouchPickUp = true;
        DistancePickupTutorial = true;
        FirstSummoning = true;
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

            FirstTouchPickUp = false; 

            THE_TARGET.Play("show_target");

            Narrator.clip = WellDoneOnPickingItUp;

            Narrator.Play();

        }

    }

    public void YouMissed() {
        if (DistancePickupTutorial) {
            DistancePickupTutorial = false;

            Narrator.clip = ShameYouMissed;

            Narrator.Play();

            ShowDistanceGrab();
        }
    }

    public void ShowDistanceGrab(){
        DistanceInteractorLeft.SetActive(true);
        DistanceInteractorRight.SetActive(true);
    }

    public void SummonedTheBall(){
          if (FirstSummoning){

            FirstSummoning = false; 

            Narrator.clip = FingersChangingColor;

            Narrator.Play();

        }
    }
}
