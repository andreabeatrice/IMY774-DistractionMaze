using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControls : MonoBehaviour
{

    [SerializeField]
    private bool testing;

    private float remaining_time;
    // Start is called before the first frame update
    void Start()
    {
        remaining_time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

    public void SetTesting(bool t){
        testing = t;
    }

    public bool GetTesting(){
        return testing;
    }

    public float GetRemainingTime(){
        return remaining_time;
    }

    public void AddToRemainingTime(float f){
        remaining_time += f;
    }

}
