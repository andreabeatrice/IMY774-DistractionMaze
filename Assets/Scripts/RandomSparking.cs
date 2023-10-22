using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSparking : MonoBehaviour
{

    public AudioSource FUSE_BOX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSparking(){
        FUSE_BOX.Play();

        float time = Random.Range(0.5f, 10f);
        
        StartCoroutine(PlaySpark(time));

    }

    public IEnumerator PlaySpark(float s){
        yield return new WaitForSeconds(s);

        StartSparking();
    }


}
