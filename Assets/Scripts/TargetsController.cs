using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsController : MonoBehaviour
{

    public Collider wall_Collider; 

    public NarratorController NARRATOR;

    public Animator TARGET_ANIMATOR;
    public GameObject ball;
    Vector3 m_Size, m_Min, m_Max, ball_Position;

    bool InArea, WallMovingEnabled, WME;
    // Start is called before the first frame update
    void Start()
    {
        InArea= false;
        WallMovingEnabled = true;
        WME = true;
        //Fetch the minimum and maximum bounds of the Collider volume
        m_Min = wall_Collider.bounds.min;
        m_Max = wall_Collider.bounds.max;    

        Debug.Log("Collider bound Minimum : " + m_Min);
        Debug.Log("Collider bound Maximum : " + m_Max);
    }

    // Update is called once per frame
    void Update()
    {
        ball_Position = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);

        bool x_pos = (ball_Position.x > m_Min.x) && (ball_Position.x < m_Max.x);
        bool y_pos = (ball_Position.y > m_Min.y)  && (ball_Position.y < m_Max.y);
        bool z_pos = (ball_Position.z > m_Min.z)  && (ball_Position.z < m_Max.z);

        if( y_pos && z_pos && WallMovingEnabled && WME){
            InArea = true;
            TARGET_ANIMATOR.Play("hide_target");
            TARGET_ANIMATOR.SetFloat("direction", 1f);
            
        }
        if((!y_pos || !z_pos) && InArea){
            TARGET_ANIMATOR.SetFloat("direction", -1f);

            InArea = false;
            
            //TARGET_ANIMATOR.Play("show_target_again");
        }

    }

    void OnCollisionEnter(Collision collision){
        Debug.Log("Entered collision with " + collision.gameObject.name);

        if(collision.gameObject.name == "Ball" && WME){
            TARGET_ANIMATOR.speed = 0;
            WME = false;

            NARRATOR.ThatTookLong();
        }
       
    }

    public void SetWallMovingEnabled(bool wme){
        WallMovingEnabled = wme;
    }



}
