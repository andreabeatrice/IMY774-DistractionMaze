using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{

    [SerializeField]
    GameObject THE_BALL;

    [SerializeField]
    Animator THE_TABLE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (THE_BALL.transform.position.y > 3.7f || THE_BALL.transform.position.y < -0.5f){
            THE_BALL.SetActive(false);

            THE_BALL.transform.position = new Vector3(-2.053f, 0.458f, 1.201f);

            THE_TABLE.Play("new_ball");
        }
    }
}
