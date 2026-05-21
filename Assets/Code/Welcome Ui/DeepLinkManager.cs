using UnityEngine;

public class DeepLinkManager : MonoBehaviour
{
void Start()
{
Application.deepLinkActivated += OnDeepLinkActivated;

    if (!string.IsNullOrEmpty(Application.absoluteURL))
    {
        OnDeepLinkActivated(Application.absoluteURL);
    }
}

void OnDeepLinkActivated(string url)
{
    Debug.Log("Deep Link diterima: " + url);

    // Di sini nanti ambil token login
}

}
