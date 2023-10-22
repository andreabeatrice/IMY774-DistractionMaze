using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class SnapObject : MonoBehaviour {
    
    public GameObject SnapLocation, CorrespondingSnapPosition;

    private bool objectSnapped;

    public bool grabbed; 



    // Start is called before the first frame update
    void Start()
    {
        grabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        objectSnapped = (SnapLocation.GetComponent<SnapLocation>().snapped || CorrespondingSnapPosition.GetComponent<SnapLocation>().snapped);


        if(objectSnapped == false){
            GetComponent<Rigidbody>().isKinematic = false;
        }
        if (objectSnapped == true) {
            GetComponent<Rigidbody>().isKinematic = true;
            
        }
    }

    public void SetGrabbed(bool g){
        grabbed = g;
    }
    

    public bool GetGrabbed(){
        return grabbed;
    }

}
