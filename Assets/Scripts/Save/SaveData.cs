using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {
    public bool video_watched;

    public SaveData(bool vw){
        video_watched = vw;
    }
}
