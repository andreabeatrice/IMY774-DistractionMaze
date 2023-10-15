using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalPositionCheck : MonoBehaviour
{

    public Collider og_Position; 
    public GameObject PLAYER;
    Vector3 m_Size, m_Min, m_Max, player_Position;

    public bool InArea;

    // Start is called before the first frame update
    void Start()
    {
        InArea = false;
        //Fetch the minimum and maximum bounds of the Collider volume
        m_Min = og_Position.bounds.min;
        m_Max = og_Position.bounds.max;    

        Debug.Log("Collider bound Minimum : " + m_Min);
        Debug.Log("Collider bound Maximum : " + m_Max);
    }

    // Update is called once per frame
    void Update()
    {
        player_Position = new Vector3(PLAYER.transform.position.x, PLAYER.transform.position.y, PLAYER.transform.position.z);

        bool x_pos = (player_Position.x > m_Min.x) && (player_Position.x < m_Max.x);
        bool y_pos = (player_Position.y > m_Min.y)  && (player_Position.y < m_Max.y);
        bool z_pos = (player_Position.z > m_Min.z)  && (player_Position.z < m_Max.z);

        if(x_pos && y_pos && z_pos){
            InArea = true;
            
        }
        if((!x_pos || !y_pos || !z_pos) && InArea){

            InArea = false;

            Debug.Log("Not in position");
            
            //TARGET_ANIMATOR.Play("show_target_again");
        }

    }

}
