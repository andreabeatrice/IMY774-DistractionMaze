using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapObject : MonoBehaviour {
    
    public GameObject SnapLocation;

    public bool isSnapped;

    private bool objectSnapped;

    private bool grabbed; 

    // Start is called before the first frame update
    void Start()
    {
        grabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        objectSnapped = SnapLocation.GetComponent<SnapLocation>().snapped;

        if (objectSnapped == true) {
            GetComponent<Rigidbody>().isKinematic = true;
            isSnapped = true;
        }

        if (objectSnapped == false && grabbed == false) {
            GetComponent<Rigidbody>().isKinematic = false;

        }
    }

    public void SetGrabbed(bool g){
        grabbed = g;
    }

    public bool GetGrabbed(){
        return grabbed;
    }
}
