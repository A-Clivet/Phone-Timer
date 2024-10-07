using UnityEngine;

public class AndroidSleepMode : MonoBehaviour
{
    public static AndroidSleepMode Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    
    public void LockScreen()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            try
            {
                // Obtenir l'activité Unity actuelle et appeler la méthode Java pour verrouiller l'écran
                using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity2d.player.UnityPlayer"))
                {
                    AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                    AndroidJavaObject context = activity.Call<AndroidJavaObject>("getApplicationContext");

                    // Obtenir le service PowerManager Android
                    AndroidJavaObject powerManager = context.Call<AndroidJavaObject>("getSystemService", "power");

                    // Créer un wakelock pour verrouiller l'écran
                    AndroidJavaObject wakeLock = powerManager.Call<AndroidJavaObject>("newWakeLock", 1, "UnityLock");

                    // Libérer le wakelock pour permettre à l'écran de s'éteindre
                    wakeLock.Call("release");
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Erreur pour verrouiller l'écran : " + e.Message);
            }
        }
    }
}