using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    [SerializeField]
    GlobalControls GLOBAL_CONTROL;

    [SerializeField]
    NarratorController NARRATOR;

    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPressed(){

        Debug.Log("POKED");
        button.transform.position = new Vector3(button.transform.position.x, button.transform.position.y, (button.transform.position.z + 0.01f));
    }

    public void ButtonUnpressed(){
        Debug.Log("NOPE");
        button.transform.position = new Vector3(button.transform.position.x, button.transform.position.y, (button.transform.position.z - 0.01f));
    }
}
