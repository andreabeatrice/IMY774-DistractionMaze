using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesController : MonoBehaviour
{

    public GameObject[] Row0;

    public GameObject[] Row1;

    public GameObject[] Row2;

    public GameObject[] Row3;

    GameObject[,] TilesArray = new GameObject[4, 6];

    GameObject SELECTED;

    public Material[] selectedMaterial, usualMaterial;

    int row, col;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < TilesArray.GetLength(0); i++) 
        { 

            for (int j = 0; j < TilesArray.GetLength(1); j++) 
            { 
                switch (i) {
                    case 0:
                        TilesArray[i,j] = Row0[j];
                    break;
                    case 1:
                        TilesArray[i,j] = Row1[j];
                    break;
                    case 2:
                        TilesArray[i,j] = Row2[j];
                    break;
                    case 3:
                        TilesArray[i,j] = Row3[j];
                    break;
                }
                 
                
                Debug.Log(TilesArray[i,j]);
            } 
        }  

        SELECTED = TilesArray[0,0];
        row = 0;
        col = 0;

        SELECTED.GetComponent<MeshRenderer>().materials = selectedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    public void GoRight(){
        if (col < 5){
            col += 1;
        }

        OnSelectedUpdate();
    }

    public void GoLeft(){
        if (col > 0){
            col -= 1;
        }

        OnSelectedUpdate();
    }

    public void GoUp(){
        if(row > 0){
            row -= 1;
        }

        OnSelectedUpdate();
    }

    public void GoDown(){
        if(row < 3){
            row += 1;
        }

        OnSelectedUpdate();
    }

    public void RoatateLeft(){
        SELECTED.transform.eulerAngles = new Vector3(SELECTED.transform.eulerAngles.x, (SELECTED.transform.eulerAngles.y - 90), SELECTED.transform.eulerAngles.z);
    }

    public void RotateRight(){
        SELECTED.transform.eulerAngles = new Vector3(SELECTED.transform.eulerAngles.x, (SELECTED.transform.eulerAngles.y + 90), SELECTED.transform.eulerAngles.z);
    }

    public void OnSelectedUpdate(){
        SELECTED = TilesArray[row,col];

        for (int i = 0; i < TilesArray.GetLength(0); i++) { 

            for (int j = 0; j < TilesArray.GetLength(1); j++) { 
                TilesArray[i,j].GetComponent<MeshRenderer>().materials = usualMaterial;
            }
        }

        SELECTED.GetComponent<MeshRenderer>().materials = selectedMaterial;
    }
}
