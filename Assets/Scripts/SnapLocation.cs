using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapLocation : MonoBehaviour
{

    private bool grabbed;

    public bool insideSnapZone;

    public bool snapped;

    public GameObject Book;

    public GameObject SnapRotationReference;
    // Start is called before the first frame update
    void Start()
    {
        insideSnapZone = false;
        snapped=false;
    }

    // Update is called once per frame
    void Update()
    {
        grabbed = Book.GetComponent<SnapObject>().GetGrabbed();
        SnapObject();
        //
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log(other.gameObject.name);

        if (other.gameObject.name.Contains("(Book)")){
            insideSnapZone = true;
        }

        
        
    }
    
    private void OnTriggerExit(Collider other){

        insideSnapZone = false;
        snapped=false;
        
    }

    void SnapObject(){
        if (grabbed == false && insideSnapZone == true){
            Book.gameObject.transform.position = transform.position;

            Book.gameObject.transform.rotation = SnapRotationReference.transform.rotation;
            snapped = true;
        }
    }
}
