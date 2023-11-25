using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesController : MonoBehaviour
{

    public GameObject[] Row0;

    public GameObject[] Row1;

    public GameObject[] Row2;

    public GameObject[] Row3;

    GameObject[,] myArray = new GameObject[4, 6];


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < myArray.GetLength(0); i++) 
        { 

            for (int j = 0; j < myArray.GetLength(1); j++) 
            { 
                switch (i) {
                    case 0:
                        myArray[i,j] = Row0[j];
                    break;
                    case 1:
                        myArray[i,j] = Row1[j];
                    break;
                    case 2:
                        myArray[i,j] = Row2[j];
                    break;
                    case 3:
                        myArray[i,j] = Row3[j];
                    break;
                }
                 
                
                Debug.Log(myArray[i,j]);
            } 
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
