using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
//using TMPro;

public class ScanMoodmetric : MonoBehaviour
{
    public MyListener myListener;
    public void scanMoodmetric()
    {
        RunPythonScript("scan");
    }

    public void startMoodmetric()
    {
        RunPythonScript("scan");
    }

    public void RunPythonScript(string scriptName)
    {
        Process proc = new Process();
        // Using string concatenation to create the path
        string pythonPath = Application.dataPath + "/Python/python.exe";
        string scriptPath = Application.dataPath + "/Python/Scripts/" + scriptName + ".py";
        proc.StartInfo.FileName = pythonPath;
        proc.StartInfo.Arguments = "\"" + scriptPath + "\"";
        proc.Start();

        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.RedirectStandardOutput = true;
        proc.StartInfo.RedirectStandardError = true;
        proc.StartInfo.CreateNoWindow = true; // Optional: if you want to hide the console window

        // Subscribe to the output and error events
        proc.OutputDataReceived += (sender, args) => UnityEngine.Debug.Log("Output: " + args.Data);
        proc.ErrorDataReceived += (sender, args) => UnityEngine.Debug.LogError("Error: " + args.Data);

        proc.Start();

        // Begin asynchronous read operations
        proc.BeginOutputReadLine();
        proc.BeginErrorReadLine();
    }

}
