using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerBottomController : MonoBehaviour{
    [SerializeField]
    GlobalControls GLOBAL_CONTROL;

    [SerializeField]
    CountdownClock CLOCK;

    [SerializeField]
    NarratorController NARRATOR;

    public Animator TABLE;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){

        if (GLOBAL_CONTROL.GetTesting()){
            Debug.Log("Entered collision with " + collision.gameObject.name);
        }

        if (collision.gameObject.name == "Ball"){
            collision.gameObject.SetActive(false);

            CLOCK.StopTimer();

            NARRATOR.OnSocketSuccess();
        }


       
    }
}
