using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
//using TMPro;

public class ScanMoodmetric : MonoBehaviour
{
    public MyListener myListener;
    //public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        //UnityEngine.Debug.Log(Application.dataPath);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scanMoodmetric()
    {
        Process proc = new Process();
        string path = Application.dataPath + "//Resources//ScanMoodmetric.lnk";
        proc.StartInfo.FileName = @path;
        proc.Start();
    }

    public void startMoodmetric()
    {
        Process proc = new Process();
        string path = Application.dataPath + "//Resources//Moodmetric.lnk";
        proc.StartInfo.FileName = @path;
        proc.Start();
        //StartCoroutine(displayError());
    }

    //private IEnumerator displayError()
    //{
    //    yield return new WaitForSeconds(5);
    //    if (!myListener.startedReceivingData)
    //    {
    //        //text.text = "Try Again!!";   
    //    }
    //}

}
