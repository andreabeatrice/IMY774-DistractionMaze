using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorController : MonoBehaviour{
    
    [SerializeField]
    private Animator POST_PROCESSOR, THE_TABLE;

    [SerializeField]
    private AudioSource Narrator;

    public AudioClip YouKnowEvenThoughThisRoomIsVeryEmpty;

    // Start is called before the first frame update
    void Start(){
        POST_PROCESSOR.Play("Eyes Open");

        StartCoroutine(WaitForWakeup());
        Debug.Log(POST_PROCESSOR.GetCurrentAnimatorStateInfo(0));


    }

    // Update is called once per frame
    void Update(){

    }

    private IEnumerator WaitForWakeup(){
        yield return new WaitForSeconds(10f);

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

        //Narrator.clip = YouKnowEvenThoughThisRoomIsVeryEmpty;

        //Narrator.Play();
    }
}
