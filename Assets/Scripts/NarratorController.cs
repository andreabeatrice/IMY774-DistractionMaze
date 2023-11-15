using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorController : MonoBehaviour{

    [SerializeField]
    GlobalControls GLOBAL_CONTROL;

    [SerializeField]
    CountdownClock CLOCK;
    
    [SerializeField]
    private Animator POST_PROCESSOR, THE_TABLE, THE_TARGET, THE_LIGHT, VIDEO_PLAYER;

    [SerializeField]
    private AudioSource Narrator, VIDEO_AUDIO, POWER_AUDIO, ELECTRIC_CABLE, BUZZ, RECORDING;

    [SerializeField]
    private RandomSparking FUSE_BOX;

    [SerializeField]
    GameObject DistanceInteractorLeft, DistanceInteractorRight, BreathGuide;

    [SerializeField]
    OriginalPositionCheck OPC;

    [SerializeField]
    RandomSparking rs;

    public AudioClip YouKnowEvenThoughThisRoomIsVeryEmpty, GoOnPickItUp, WellDoneOnPickingItUp, ShameYouMissed, FingersChangingColor, ThatTookLongAudio, PleaseReturnAudio, SocketAudio, WellDoneAudio, YouWillBeTimed, BookInstructions, ByColorResponseAudio, FaultyGravityExcuse;

    public AudioClip WeBrokeTheGravityMachine, ByHeightResponse, FocusUp, SimplerTask, BreathInstruction, WhatsHappening;
    
    private bool FirstTouchPickUp, DistancePickupTutorial, BreathTutorial;

    private float timeBeforePowerOff;

    // Start is called before the first frame update
    void Start(){
        if(!GLOBAL_CONTROL.GetTesting()){
            POST_PROCESSOR.Play("Eyes Open");

            StartCoroutine(WaitForWakeup());

            FirstTouchPickUp = true;
            DistancePickupTutorial = true;
            BreathTutorial = true;
        }
        else {
            ShowDistanceGrab();
            FirstTouchPickUp = false;
            DistancePickupTutorial = false;
            BreathTutorial = false;
            THE_TABLE.Play("reveal_ball");
            THE_TARGET.Play("show_target");

            PowerOutage();
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

            //StartCoroutine(ExplainFingers());

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
        StopAllCoroutines();

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

        FUSE_BOX.StartSparking();

    }

    public void OrganizedByColourResponse(){
        Narrator.clip = ByColorResponseAudio;
        Narrator.Play();
    }

    public void OrganizedByHeightResponse(){
        Narrator.clip = ByHeightResponse;
        Narrator.Play();
    }


    public void BrokenGravity(){
        Narrator.clip = WeBrokeTheGravityMachine;
        Narrator.Play();

        StartCoroutine(BreathingTest());
    }

    public IEnumerator BreathingTest(){
        yield return new WaitForSeconds(8f);

        Narrator.clip = SimplerTask;
        Narrator.Play();


        THE_TABLE.Play("breath_tray_rise");
    }

    public void GrabbedControl(){
        if (BreathTutorial){
            BreathTutorial = false;


            Narrator.clip = BreathInstruction;
            Narrator.Play();
        }

        BreathGuide.SetActive(true);

        string timeString = GLOBAL_CONTROL.GetRemainingTime().ToString();

        Debug.Log(timeString);
        string[] timeSplit = timeString.Split(",");

        float firstTwo = float.Parse(timeSplit[0]);
        float secondTwo = 0;

        if(timeSplit.Length > 1){
            secondTwo = float.Parse(timeSplit[1]);
        }
            

        Debug.Log(firstTwo + " " + secondTwo);

        float tens = 10;

        tens = tens - firstTwo;

        tens = tens * 60;

        tens = tens - secondTwo;

        tens = tens/60;

        timeBeforePowerOff = (float) Mathf.Round(tens);

        Debug.Log(tens);

            //int.Parse(timeSplit[0]), int.Parse(timeSplit[1])

        int timer = 10 - (int) timeBeforePowerOff;

        CLOCK.StartNewMinutesCountdown(10, 0);

        StartCountingTimeTillPowerOff(timer);
        
    }


    public void FocusMetric(){
        StopAllCoroutines();

        Narrator.clip = FocusUp;
        Narrator.Play();
    }

    public void StartCountingTimeTillPowerOff(int i){
        timeBeforePowerOff = i * 60;
        Debug.Log(timeBeforePowerOff);
        if(timeBeforePowerOff != 0){
            StartCoroutine(OneSecond());
        }
        else {
            PowerOutage();
        }
    }

    private IEnumerator OneSecond(){
        yield return new WaitForSeconds(1f);
        timeBeforePowerOff -= 1;
        Debug.Log(timeBeforePowerOff);
        if(timeBeforePowerOff != 0){
            StartCoroutine(OneSecond());
        }
        else { //bb.moveobjects
            PowerOutage();
        }
        
    }

    public void PowerOutage(){
        Debug.Log("POWER'S OUT");

        THE_LIGHT.Play("power_down_with_material");

        CLOCK.StopTimer();

        POWER_AUDIO.Play();
        ELECTRIC_CABLE.Pause();
        BUZZ.Pause();
        RECORDING.Pause();

        rs.StopSparking();
        RenderSettings.ambientIntensity = 1;

        StartCoroutine(OneSecondLight(2));
    }

    private IEnumerator OneSecondLight(int i){
        yield return new WaitForSeconds(1f);
        i -= 1;
        if(i != 0){
            RenderSettings.ambientIntensity = 0.5f;
            StartCoroutine(OneSecondLight(i));
        }
        else { //bb.moveobjects
            RenderSettings.ambientIntensity = 0.25f;

            Narrator.clip = WhatsHappening;
            Narrator.Play();

            StartCoroutine(BackUp());
            
        }
        
    }

     private IEnumerator BackUp(){
        yield return new WaitForSeconds(3f);

        THE_LIGHT.Play("power_back_up");

        VIDEO_PLAYER.Play("screen_rolldown");
        VIDEO_AUDIO.Play();
     }
    

    // public void SummonedTheBall(){
    //       if (FirstSummoning){

    //         FirstSummoning = false; 

           

    //     }
    // }
}
