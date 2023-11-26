using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    GameObject DistanceInteractorLeft, DistanceInteractorRight, Tiles, StartingPoint, EndingPoint, TableCanvas;

    [SerializeField]
    OriginalPositionCheck OPC;

    [SerializeField]
    RandomSparking rs;


    public AudioClip YouKnowEvenThoughThisRoomIsVeryEmpty, GoOnPickItUp, WellDoneOnPickingItUp, ShameYouMissed, FingersChangingColor, ThatTookLongAudio, PleaseReturnAudio, SocketAudio, WellDoneAudio, YouWillBeTimed, BookInstructions, ByColorResponseAudio, FaultyGravityExcuse;

    public AudioClip WeBrokeTheGravityMachine, ByHeightResponse, FocusUp, SimplerTask, CircuitInstruction, WhatsHappening;
    
    private bool FirstTouchPickUp, DistancePickupTutorial, CircuitTutorial;

    private float timeBeforePowerOff;

    // Start is called before the first frame update
    void Start(){
        if(!GLOBAL_CONTROL.GetTesting()){
            //POST_PROCESSOR.Play("Eyes Open");

            StartCoroutine(WaitForWakeup());

            FirstTouchPickUp = true;
            DistancePickupTutorial = true;
            CircuitTutorial = true;
        }
        else {
            ShowDistanceGrab();
            FirstTouchPickUp = false;
            DistancePickupTutorial = false;
            CircuitTutorial = false;
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

        if (SceneManager.GetActiveScene().name == "VirtualWorld"){
            StartCoroutine(WaitForLookAroundLonger());
        }
        if (SceneManager.GetActiveScene().name == "VirtualWorldReset"){
            StartCoroutine(RevealTheBall());
        }
        
    }

    private IEnumerator WaitForLookAround(){
        yield return new WaitForSeconds(12f);

        Narrator.clip = YouKnowEvenThoughThisRoomIsVeryEmpty;

        Narrator.Play();

        StartCoroutine(RevealTheBall());
    }

    private IEnumerator WaitForLookAroundLonger(){
        yield return new WaitForSeconds(14f);

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

        SaveSystem.SaveProgress(true);

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

        StartCoroutine(IntroduceCircuits());
    }

    public IEnumerator IntroduceCircuits(){
        yield return new WaitForSeconds(9f);

        Narrator.clip = SimplerTask;
        Narrator.Play();


        THE_TABLE.Play("breath_tray_rise");

        StartCoroutine(CircuitTutorialMethod());
    }

    public IEnumerator CircuitTutorialMethod(){
        yield return new WaitForSeconds(6f);

        if (CircuitTutorial){
            CircuitTutorial = false;


            Narrator.clip = CircuitInstruction;
            Narrator.Play();
        }


        
        //Tiles, StartingPoint, EndingPoint, TableCanvas

        
        
    }


    public void FocusMetric(){
        StopAllCoroutines();

        Narrator.clip = FocusUp;
        Narrator.Play();
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
        TableCanvas.SetActive(false);

        THE_LIGHT.Play("power_down_with_material");

        CLOCK.StopTimer();

        POWER_AUDIO.Play();
        ELECTRIC_CABLE.Pause();
        BUZZ.Pause();
        RECORDING.Pause();

        //BreathGuide.SetActive(false);

        rs.StopSparking();
        RenderSettings.ambientIntensity = 1;

        StartCoroutine(OneSecondLight(2));
    }

    private IEnumerator OneSecondLight(int i){
        yield return new WaitForSeconds(1f);
        i -= 1;
        if(i != 0){
            StartCoroutine(OneSecondLight(i));
        }
        else { //bb.moveobjects

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
