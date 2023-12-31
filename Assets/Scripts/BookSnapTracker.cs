using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class BookSnapTracker : MonoBehaviour
{
    public GameObject[] SnapByColorPositions, SnapByHeightPositions, Books;

    public bool AllColorPositionsFalse, AllHeightPositionsFalse;

    public bool sortDetermined;

    public GameObject VisibleSlots, ME;

    [SerializeField]
    NarratorController NARRATOR;

    [SerializeField]
    GlobalControls GLOBAL_CONTROL;

    [SerializeField]
    CountdownClock CLOCK;

    // Start is called before the first frame update
    void Start()
    {
        sortDetermined = false;
        foreach(GameObject go in SnapByColorPositions){
            if (go.activeSelf){
                AllColorPositionsFalse = false;
            }
        }

        foreach(GameObject go in SnapByHeightPositions){
            if (go.activeSelf){
                AllHeightPositionsFalse = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GLOBAL_CONTROL.GetTesting()){
            
            StartCoroutine(Testing());
        }
        else {
        int counter = 0;
        if (AllColorPositionsFalse == false && AllHeightPositionsFalse == false) {
            foreach(GameObject go in SnapByColorPositions){
                if (!go.activeSelf){
                    counter +=1;
                    
                }
            }

            if (counter == 10){
                AllColorPositionsFalse = true;
                StartCoroutine(OnSorted());
            }
            else {
                counter = 0;

                foreach(GameObject go in SnapByHeightPositions){
                    if (!go.activeSelf){
                        counter +=1;
                    }
                }

                if (counter == 10){
                    AllHeightPositionsFalse = true;
                    StartCoroutine(OnSorted());
                }
            }

            

           
        }
        else {
            if (!sortDetermined){
                StartCoroutine(OnSorted());
            }
            

        }
        }

    }

    public IEnumerator Testing(){

        yield return new WaitForSeconds(1.5f);

        AllColorPositionsFalse = true;

        StartCoroutine(OnSorted());

    }

    public IEnumerator OnSorted(){

        yield return new WaitForSeconds(0.5f);

        sortDetermined = true;
        if (AllColorPositionsFalse) {
            //Debug.Log("Sorted by height");
            NARRATOR.OrganizedByHeightResponse();
        }
        else {
            //Debug.Log("Sorted by color");
            NARRATOR.OrganizedByColourResponse();
        }

        //CLOCK.StopTimer();



        StartCoroutine(NextDistraction());

        //SnappingThings.SetActive(false);
    }

    public IEnumerator NextDistraction(){
        yield return new WaitForSeconds(5f);

        //GLOBAL_CONTROL.AddToRemainingTime(CLOCK.GetClockValue());

        //Debug.Log(GLOBAL_CONTROL.GetRemainingTime());

        VisibleSlots.SetActive(false);

        foreach(GameObject go in Books){
            go.GetComponent<SnapObject>().enabled = false;
            go.GetComponent<SnapObjectDuplicate>().enabled = false;
            go.GetComponent<Grabbable>().enabled = false;
        }

        foreach(GameObject go in SnapByColorPositions){
            go.SetActive(false);
        }

        foreach(GameObject go in SnapByHeightPositions){
            go.SetActive(false);
        }

        foreach(GameObject go in Books){
            go.GetComponent<Rigidbody>().useGravity = false;
            go.GetComponent<Rigidbody>().isKinematic = false;
        }

        NARRATOR.BrokenGravity();

        ME.SetActive(false);

    }
}
