#if UNITY_EDITOR_OSX
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

public class PreBuildProcessing : IPreprocessBuildWithReport
{
    public int callbackOrder => 1;
 
    public void OnPreprocessBuild(BuildReport report)
    {
        // This should be the path to your Python installation. Python 2 or 3 should work.
        // This should only be necessary on macOS Monterey, since it doesn't include Python 2 anymore.
        System.Environment.SetEnvironmentVariable("EMSDK_PYTHON", "/usr/bin/python3");
    }
}
#endif