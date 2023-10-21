using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSnapTracker : MonoBehaviour
{
    public GameObject[] SnapByColorPositions, SnapByHeightPositions, Books;

    public bool AllColorPositionsFalse, AllHeightPositionsFalse;

    public bool sortDetermined;

    public GameObject SnappingThings;
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

    public IEnumerator OnSorted(){

        yield return new WaitForSeconds(1);

        sortDetermined = true;
        if (AllColorPositionsFalse) {
            Debug.Log("Sorted by height");
        }
        else {
            Debug.Log("Sorted by color");
            foreach(GameObject go in SnapByColorPositions){
                go.GetComponent<Rigidbody>().isKinematic = false;
            }
        }

        foreach(GameObject go in Books){
            go.GetComponent<SnapObject>().enabled = false;
            go.GetComponent<SnapObjectDuplicate>().enabled = false;
            go.GetComponent<Rigidbody>().isKinematic = true;
        }

        //SnappingThings.SetActive(false);
    }
}
