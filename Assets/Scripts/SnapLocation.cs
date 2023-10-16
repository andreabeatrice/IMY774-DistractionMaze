using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapLocation : MonoBehaviour
{

    private bool grabbed;

    private bool insideSnapZone;

    public bool snapped;

    public GameObject Book;

    public GameObject SnapRotationReference;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        grabbed = Book.GetComponent<SnapObject>().GetGrabbed();
        SnapObject();
        insideSnapZone = false;
    }

    private void OnTriggerEnter(Collider other){

        insideSnapZone = true;
        
    }
    
    private void OnTriggerExit(Collider other){

        insideSnapZone = false;
        
    }

    void SnapObject(){
        if (grabbed == false && insideSnapZone == true){
            Book.gameObject.transform.position = transform.position;

            Book.gameObject.transform.rotation = SnapRotationReference.transform.rotation;
            snapped = true;
        }
    }
}
