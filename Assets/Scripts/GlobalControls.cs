using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalControls : MonoBehaviour
{

    [SerializeField]
    private bool testing, opened, video_watched;

    private float remaining_time;

    public GameObject UI_CANVAS, OVRPlayerController;

    public AudioSource Narrator;

    public AudioClip InterestingChoice, InterestingChoice2;

    public Animator THE_LIGHT;

    void Awake(){
        if(SaveSystem.LoadProgress() == true){
            SceneManager.LoadScene("CanvasTaskTest");
        }
        else {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        remaining_time = 0f;
        opened =false;
    }
    
    public bool GetVideoWatched(){
        return video_watched;
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }

        if(OVRInput.Get(OVRInput.Button.Start) && opened == false){
            float dialogX = OVRPlayerController.transform.position.x + 0f;
            float dialogY = OVRPlayerController.transform.position.y + 0.3f;
            float dialogZ = OVRPlayerController.transform.position.z + 0.3f;
        
            UI_CANVAS.transform.position = new Vector3(dialogX, dialogY, dialogZ);
            UI_CANVAS.transform.eulerAngles = new Vector3(UI_CANVAS.transform.eulerAngles.x, OVRPlayerController.transform.eulerAngles.y, UI_CANVAS.transform.eulerAngles.z);

            UI_CANVAS.SetActive(true);
            StartCoroutine(SetOpened(true));
        }

        if(OVRInput.Get(OVRInput.Button.Start) && opened == true){
            UI_CANVAS.SetActive(false);
            StartCoroutine(SetOpened(false));
        }
    }

    public void SetTesting(bool t){
        testing = t;
    }

    public bool GetTesting(){
        return testing;
    }

    public float GetRemainingTime(){
        return remaining_time;
    }

    public void AddToRemainingTime(float f){
        remaining_time += f;
    }

    public IEnumerator SetOpened(bool o){
        yield return new WaitForSeconds(1f);
        opened = o;
    }

    public void Leave(){
        StopAllCoroutines();
         Narrator.clip = InterestingChoice2;

        Narrator.Play();

        THE_LIGHT.Play("power_down_with_material");
        StartCoroutine(LeaveWorld());
    }

    public IEnumerator LeaveWorld(){
        yield return new WaitForSeconds(6f);
        Application.Quit();
    }

    public void ResetMe(){
        SceneManager.LoadScene("VirtualWorld");
    }

    public void Restart(){
        StopAllCoroutines();
        Narrator.clip = InterestingChoice;

        Narrator.Play();

        THE_LIGHT.Play("power_down_with_material");
        StartCoroutine(Reset());
    }

    public IEnumerator Reset(){
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("VirtualWorld");
    }


}
