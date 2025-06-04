using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitApp()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
