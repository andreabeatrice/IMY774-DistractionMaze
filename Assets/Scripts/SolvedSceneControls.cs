using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SolvedSceneControls : MonoBehaviour
{

    public GameObject UI_CANVAS, OVRPlayerController;

    public AudioSource Narrator;

    public AudioClip InterestingChoice, InterestingChoice2;

    public Animator THE_LIGHT;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }

        
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
