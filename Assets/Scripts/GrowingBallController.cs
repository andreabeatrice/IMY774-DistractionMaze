using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingBallController : MonoBehaviour
{

    public GameObject Controller, Ball;

    private float FloatX, NewRHP, x;

    public Animator GrowingBall;

    private bool grabbed;

    public GrowingScriptAnimation ball;
    // Start is called before the first frame update
    void Start()
    {
        grabbed = false;
        FloatX = ball.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        float size = (Controller.transform.position.x - NewRHP);
        //Debug.Log(size);

        if (grabbed && size != 0.4f && size != 0f){
            size *= 0.5f;

            float x = FloatX + size; 
            ball.transform.localScale = new Vector3(x, x, x);

            // if (PreviousRHP > Controller.transform.position.x){
            //     ball.DecreaseSize();
            // }
            // else if (Controller.transform.position.x > PreviousRHP){
            //     ball.IncreaseSize();
            // }

            //PreviousRHP = Controller.transform.position.x;

                

            

            Debug.Log("Moved: " + size);

        }

    
        
        
    }

    public void OnObjectGrab() {
        NewRHP = Controller.transform.position.x;

        grabbed = true;
    }

    public void OnObjectRelease() {
        //OriginalRHP = RightHandPosition.transform.position.x;

        //Debug.Log(PreviousRHP);

        grabbed = false;
    }
}
