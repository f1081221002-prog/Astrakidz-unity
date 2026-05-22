using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

public class BuildScript : IPreprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPreprocessBuild(BuildReport report)
    {
        // ANDROID
        if (report.summary.platform == BuildTarget.Android)
        {
            PlayerSettings.SetScriptingBackend(
                BuildTargetGroup.Android,
                ScriptingImplementation.IL2CPP
            );

            PlayerSettings.Android.targetArchitectures =
                AndroidArchitecture.ARMv7 |
                AndroidArchitecture.ARM64;

            UnityEngine.Debug.Log("ANDROID IL2CPP ENABLED");
        }

        // WINDOWS
        if (report.summary.platform == BuildTarget.StandaloneWindows64)
        {
            PlayerSettings.SetScriptingBackend(
                BuildTargetGroup.Standalone,
                ScriptingImplementation.IL2CPP
            );

            UnityEngine.Debug.Log("WINDOWS IL2CPP ENABLED");
        }
    }
}