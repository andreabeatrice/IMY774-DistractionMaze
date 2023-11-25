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

    bool[,] all_right = new bool[4, 6];

    GameObject SELECTED;

    public GameObject ENDPOINT_Gradient, ENDPOINT_Circuitry, ENDPOINT_Line;

    public Material[] selectedMaterial, usualMaterial, gradient, circuitry, line;

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
        StartCoroutine(OnChange());
    }

    public void RotateRight(){
        SELECTED.transform.eulerAngles = new Vector3(SELECTED.transform.eulerAngles.x, (SELECTED.transform.eulerAngles.y + 90), SELECTED.transform.eulerAngles.z);
        StartCoroutine(OnChange());
    }

    public void OnSelectedUpdate(){
        SELECTED = TilesArray[row,col];

        for (int i = 0; i < TilesArray.GetLength(0); i++) { 

            for (int j = 0; j < TilesArray.GetLength(1); j++) { 
                TilesArray[i,j].GetComponent<MeshRenderer>().materials = usualMaterial;
            }
        }

        SELECTED.GetComponent<MeshRenderer>().materials = selectedMaterial;

        
        StartCoroutine(OnChange());

    }

    public IEnumerator OnChange(){
        yield return new WaitForSeconds(0.5f);

        Debug.Log("____________________________________________ON CHANGE");
        for (int i = 0; i < TilesArray.GetLength(0); i++) { 

            for (int j = 0; j < TilesArray.GetLength(1); j++) { 

                all_right[i,j] = TilesArray[i,j].GetComponent<TileChecker>().RightPlace;
            }
        }

        for (int i = 0; i < all_right.GetLength(0); i++) { 

            for (int j = 0; j < all_right.GetLength(1); j++) { 
                if (all_right[i,j] == false){
                    Debug.Log(TilesArray[i,j] + " - FALSE");
                    yield break;
                }
            }
        }

        Debug.Log("AFTER RETURMN___________________________________________");
        ENDPOINT_Gradient.GetComponent<MeshRenderer>().materials = gradient;
        ENDPOINT_Circuitry.GetComponent<MeshRenderer>().materials = circuitry;
        ENDPOINT_Line.GetComponent<MeshRenderer>().materials = line;

    }
}
