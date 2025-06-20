using UnityEditor;
using UnityEngine;
using System.Diagnostics;

public class ADBTest
{
    [MenuItem("Tools/Test ADB Connection")]
    public static void TestADB()
    {
        Process process = new Process();
        process.StartInfo.FileName = "adb";
        process.StartInfo.Arguments = "devices";
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        UnityEngine.Debug.Log("ADB Output:\n" + output);
    }
}
