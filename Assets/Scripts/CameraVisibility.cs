using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVisibility : MonoBehaviour
{
    public GameObject target, BookSnapTracker;
    public Camera cam;

    public GameObject RedBook, OrangeBook, OrangeYellowBook, YellowBook, GreenBook, GreenBlueBook, BlueBook, PurpleBook, PinkPurpleBook, PinkBook;

    public GameObject[] SnapPositionsByColor, SnapPositionsByHeight;

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


           if (RedBook.activeSelf && BookSnapTracker.activeSelf){
                if (FirstTimeLookAway){
                    FirstTimeLookAway = false;
                    NARRATOR.FocusMetric();

                }

                BookSnapTracker.GetComponent<BookSnapTracker>().enabled = false;

                foreach(GameObject go in SnapPositionsByColor){
                    go.SetActive(false);
                    go.GetComponent<SnapLocation>().insideSnapZone = false;
                    go.GetComponent<SnapLocation>().snapped = false;
                }

                foreach(GameObject go in SnapPositionsByHeight){
                    go.SetActive(false);
                    go.GetComponent<SnapLocation>().insideSnapZone = false;
                    go.GetComponent<SnapLocation>().snapped = false;
                }
                

                RedBook.GetComponent<SnapObject>().objectSnapped = false;
                RedBook.GetComponent<SnapObjectDuplicate>().objectSnapped = false;
                RedBook.transform.position = new Vector3(-2.4411f, 1.116f, 1.003f);
                RedBook.transform.eulerAngles = new Vector3(-90, 0, 90);


                OrangeBook.GetComponent<SnapObject>().objectSnapped = false;
                OrangeBook.GetComponent<SnapObjectDuplicate>().objectSnapped = false;
                OrangeBook.transform.position = new Vector3(-2.3384f, 1.142f, 1.029498f);
                OrangeBook.transform.eulerAngles = new Vector3(-90, 0, 90);

                OrangeYellowBook.GetComponent<SnapObject>().objectSnapped = false;
                OrangeYellowBook.GetComponent<SnapObjectDuplicate>().objectSnapped = false;
                OrangeYellowBook.transform.position = new Vector3(-2.496f, 1.126f, 1.003f);
                OrangeYellowBook.transform.eulerAngles = new Vector3(-90, 0, 90);

                YellowBook.GetComponent<SnapObject>().objectSnapped = false;
                YellowBook.GetComponent<SnapObjectDuplicate>().objectSnapped = false;
                YellowBook.transform.position = new Vector3(-2.2887f, 1.103f, 1.003f);
                YellowBook.transform.eulerAngles = new Vector3(-90, 0, 90);

                GreenBook.GetComponent<SnapObject>().objectSnapped = false;
                GreenBook.GetComponent<SnapObjectDuplicate>().objectSnapped = false;
                GreenBook.transform.position = new Vector3(-2.6075f, 1.116f, 0.9853f);
                GreenBook.transform.eulerAngles = new Vector3(-90, 0, 90);
                
                GreenBlueBook.GetComponent<SnapObject>().objectSnapped = false;
                GreenBlueBook.GetComponent<SnapObjectDuplicate>().objectSnapped = false;
                GreenBlueBook.transform.position = new Vector3(-2.3894f, 1.107f, 0.9732f);
                GreenBlueBook.transform.eulerAngles = new Vector3(-90, 0, 90);

                BlueBook.GetComponent<SnapObject>().objectSnapped = false;
                BlueBook.GetComponent<SnapObjectDuplicate>().objectSnapped = false;
                BlueBook.transform.position = new Vector3(-2.1877f, 1.138f, 1.003f);
                BlueBook.transform.eulerAngles = new Vector3(-90, 0, 90);

                PurpleBook.GetComponent<SnapObject>().objectSnapped = false;
                PurpleBook.GetComponent<SnapObjectDuplicate>().objectSnapped = false;
                PurpleBook.transform.position = new Vector3(-2.242f, 1.154f, 1.003f);
                PurpleBook.transform.eulerAngles = new Vector3(-90, 0, 90);

                PinkPurpleBook.GetComponent<SnapObject>().objectSnapped = false;
                PinkPurpleBook.GetComponent<SnapObjectDuplicate>().objectSnapped = false;
                PinkPurpleBook.transform.position = new Vector3(-2.6688f, 1.128f, 0.9954979f);
                PinkPurpleBook.transform.eulerAngles = new Vector3(-90, 0, 90);

                PinkBook.GetComponent<SnapObject>().objectSnapped = false;
                PinkBook.GetComponent<SnapObjectDuplicate>().objectSnapped = false;
                PinkBook.transform.position = new Vector3(-2.5536f, 1.147f, 1.003f);
                PinkBook.transform.eulerAngles = new Vector3(-90, 0, 90);

                foreach(GameObject go in SnapPositionsByColor){
                    go.SetActive(true);
                    
                }

                foreach(GameObject go in SnapPositionsByHeight){
                    go.SetActive(true);
                }

                BookSnapTracker.GetComponent<BookSnapTracker>().enabled = true;

            }
        }
    }
}

