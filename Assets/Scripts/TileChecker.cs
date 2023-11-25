using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChecker : MonoBehaviour
{

    public bool RightPlace;

    public Material[] circuitMG, gradientMG, connectionMG, circuitM, gradientM, connectionM;

    public GameObject circuit, gradient, connection;

    public int correct_rotation;


    // Start is called before the first frame update
    void Start()
    {
        RightPlace = false;

        Debug.Log(this);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = new Vector3(0, correct_rotation, 0);


        if (this.transform.eulerAngles == rotation){
            RightPlace = true;
        }
        else {
            RightPlace = false;
        }

        if(RightPlace){
            GoGreen();
        }
        else {
            NoGreen();
        }
    }

    public void GoGreen(){
        circuit.GetComponent<MeshRenderer>().materials = circuitMG;
        gradient.GetComponent<MeshRenderer>().materials = gradientMG;
        connection.GetComponent<MeshRenderer>().materials = connectionMG;

        gradient.GetComponent<Animator>().Play("glowy_details");
    }

    public void NoGreen(){
        circuit.GetComponent<MeshRenderer>().materials = circuitM;
        gradient.GetComponent<MeshRenderer>().materials = gradientM;
        connection.GetComponent<MeshRenderer>().materials = connectionM;

        gradient.GetComponent<Animator>().Play("DefaultState");
    }
}
