using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControls : MonoBehaviour
{

    [SerializeField]
    private bool testing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTesting(bool t){
        testing = t;
    }

    public bool GetTesting(){
        return testing;
    }
}
