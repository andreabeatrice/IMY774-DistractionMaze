using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVisibility : MonoBehaviour
{
    public GameObject target;
    public Camera cam;

    public GameObject RedBook, OrangeBook, OrangeYellowBook, YellowBook, GreenBook, GreenBlueBook, BlueBook, PurpleBook, PinkPurpleBook, PinkBook;

    public bool FirstTimeLookAway;

    [SerializeField]
    private NarratorController NARRATOR;

    private bool IsVisible(Camera c, GameObject target)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point)< 0)
            {
                return false;
            }
        }
        return true;
    }

    private void Update ()
    {
        

        var targets = IsVisible(cam,RedBook) || IsVisible(cam,OrangeBook) || IsVisible(cam,OrangeYellowBook) || IsVisible(cam,YellowBook) || IsVisible(cam,GreenBook) || IsVisible(cam,GreenBlueBook) || IsVisible(cam,BlueBook) || IsVisible(cam,PurpleBook) || IsVisible(cam,PinkPurpleBook) || IsVisible(cam,PinkBook);



        if (targets)
        {
        //    if (!FirstTimeLookAway){
        //         Narrator.clip = FirstTimeLookAway1;
        //         Narrator.Play();

        //     }
        }
        else
        {


           if (RedBook.activeSelf){
                if (FirstTimeLookAway){
                    FirstTimeLookAway = false;
                    NARRATOR.FocusMetric();

                }
                


                RedBook.transform.position = new Vector3(-2.4411f, 1.116f, 1.003f);
                RedBook.transform.eulerAngles = new Vector3(-90, 0, 90);

                OrangeBook.transform.position = new Vector3(-2.3384f, 1.142f, 1.029498f);
                OrangeBook.transform.eulerAngles = new Vector3(-90, 0, 90);

                OrangeYellowBook.transform.position = new Vector3(-2.496f, 1.126f, 1.003f);
                OrangeYellowBook.transform.eulerAngles = new Vector3(-90, 0, 90);

                YellowBook.transform.position = new Vector3(-2.2887f, 1.103f, 1.003f);
                YellowBook.transform.eulerAngles = new Vector3(-90, 0, 90);

                GreenBook.transform.position = new Vector3(-2.6075f, 1.116f, 0.9853f);
                GreenBook.transform.eulerAngles = new Vector3(-90, 0, 90);

                GreenBlueBook.transform.position = new Vector3(-2.3894f, 1.107f, 0.9732f);
                GreenBlueBook.transform.eulerAngles = new Vector3(-90, 0, 90);

                BlueBook.transform.position = new Vector3(-2.1877f, 1.138f, 1.003f);
                BlueBook.transform.eulerAngles = new Vector3(-90, 0, 90);

                PurpleBook.transform.position = new Vector3(-2.242f, 1.154f, 1.003f);
                PurpleBook.transform.eulerAngles = new Vector3(-90, 0, 90);

                PinkPurpleBook.transform.position = new Vector3(-2.6688f, 1.128f, 0.9954979f);
                PinkPurpleBook.transform.eulerAngles = new Vector3(-90, 0, 90);

                PinkBook.transform.position = new Vector3(-2.5536f, 1.147f, 1.003f);
                PinkBook.transform.eulerAngles = new Vector3(-90, 0, 90);
            }
        }
    }
}

