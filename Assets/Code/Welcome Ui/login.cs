using UnityEngine;
using Supabase;
using System.Threading.Tasks;

public class AuthManager : MonoBehaviour
{
private Client supabase;

async void Start()
{
    Debug.Log("Initializing Supabase...");

    supabase = new Client(
        "https://sgpvvidxyzntjplmzlnr.supabase.co",
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InNncHZ2aWR4eXpudGpwbG16bG5yIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NzkyOTMyNTMsImV4cCI6MjA5NDg2OTI1M30.3sEq_BSd42UU6gJBWEkmAkf2jKL1eDZ1wv5s8AOe-R8"
    );

    await supabase.InitializeAsync();

    Debug.Log("Supabase initialized!");
}

public void LoginGoogle()
{
string url =
"https://sgpvvidxyzntjplmzlnr.supabase.co/auth/v1/authorize?provider=google";

Debug.Log("Membuka browser login...");

Application.OpenURL(url);

}

}