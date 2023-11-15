using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSparking : MonoBehaviour
{

    public AudioSource FUSE_BOX;

    public AudioClip Option1, Option2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSparking(){
        int clip = Random.Range(1,3);

        switch (clip){
            case 1: 
                FUSE_BOX.clip = Option1;
            break;
            case 2: 
                FUSE_BOX.clip = Option2;
            break;
        }

        FUSE_BOX.Play();

        float time = Random.Range(1f, 15f);
        
        StartCoroutine(PlaySpark(time));

    }

    public IEnumerator PlaySpark(float s){
        yield return new WaitForSeconds(s);

        StartSparking();
    }

    public void StopSparking(){
        StopAllCoroutines();
    }


}
