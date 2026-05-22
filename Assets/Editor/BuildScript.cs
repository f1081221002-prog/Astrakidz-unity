using UnityEditor;

public class BuildScript
{
    // ANDROID
    public static void SetAndroidIL2CPP()
    {
        PlayerSettings.SetScriptingBackend(
            BuildTargetGroup.Android,
            ScriptingImplementation.IL2CPP
        );

        PlayerSettings.Android.targetArchitectures =
            AndroidArchitecture.ARMv7 |
            AndroidArchitecture.ARM64;
    }

    // WINDOWS
    public static void SetWindowsIL2CPP()
    {
        PlayerSettings.SetScriptingBackend(
            BuildTargetGroup.Standalone,
            ScriptingImplementation.IL2CPP
        );
    }
}