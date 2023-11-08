using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingScriptAnimation : MonoBehaviour
{

    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseSize(){
        float x = ball.transform.localScale.x;
        float y = ball.transform.localScale.y;
        float z = ball.transform.localScale.z;
        ball.transform.localScale = new Vector3(x + 0.01f, y + 0.01f, z + 0.01f);
    }

    public void DecreaseSize(){
        float x = ball.transform.localScale.x;
        float y = ball.transform.localScale.y;
        float z = ball.transform.localScale.z;
        ball.transform.localScale = new Vector3(x - 0.01f, y - 0.01f, z - 0.01f);
    }

    public void IncreaseSize(float f){
        float x = ball.transform.localScale.x;
        float y = ball.transform.localScale.y;
        float z = ball.transform.localScale.z;

        ball.transform.localScale = new Vector3(x + f, y + f, z + f);
    }

    public void DecreaseSize(float f){
        float x = ball.transform.localScale.x;
        float y = ball.transform.localScale.y;
        float z = ball.transform.localScale.z;

        ball.transform.localScale = new Vector3(x - f, y - f, z - f);
    }
}
