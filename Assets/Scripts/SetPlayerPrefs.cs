using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSolvedTrue(){
        PlayerPrefs.SetString("Solved", "true");
        PlayerPrefs.Save();
    }

    public void SetSolvedFalse(){
        PlayerPrefs.SetString("Solved", "false");
        PlayerPrefs.Save();
    }

    public string GetSolved(){

        return PlayerPrefs.GetString("Solved");
    }

    public IEnumerator SetSolvedTrue30(){
        yield return new WaitForSeconds(31f);

        PlayerPrefs.SetString("Solved", "true");
        PlayerPrefs.Save();
    }

    public void StartSetSolved(){
        StartCoroutine(SetSolvedTrue30());
    }
}
