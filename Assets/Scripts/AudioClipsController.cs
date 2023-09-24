using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipsController : MonoBehaviour
{

    public AudioSource electricBuzzing, speaker;    
    public AudioClip welcomePart2; 

    public Animator animator;

    public string animationName;

    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {   
        if (speaker.clip != welcomePart2 && !speaker.isPlaying)
        {
            StartCoroutine(WaitAndPlay(2.0f, speaker, welcomePart2));

        }
        else if (speaker.clip == welcomePart2  && !speaker.isPlaying) {
            animator.Play(animationName);
        }
        
    }

    IEnumerator WaitAndPlay(float time, AudioSource audioSource, AudioClip clip ){
        yield return new WaitForSeconds(time);
        audioSource.clip = clip;
        audioSource.Play();

    }
}
