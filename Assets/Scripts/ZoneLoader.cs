using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneLoader : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadSceneAsync("Zone1_Penguin", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Zone3_Tiger", LoadSceneMode.Additive);
    }
}
