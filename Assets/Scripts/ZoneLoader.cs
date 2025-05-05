using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneLoader : MonoBehaviour
{
    // Масив назв сцен, які потрібно завантажити
    public string[] sceneNames = new string[] { "Zone1_Penguin", "Zone3_Tiger", "Zone5_Elk" };

    void Start()
    {
        if (sceneNames.Length != 3) // Перевірка на кількість сцен
        {
            Debug.LogError("Має бути 3 сцени!");
            return;
        }

        for (int i = 0; i < sceneNames.Length; i++)
        {
            int index = i; // Потрібна копія для лямбди
            SceneManager.LoadSceneAsync(sceneNames[index], LoadSceneMode.Additive).completed += (op) =>
            {
                Scene scene = SceneManager.GetSceneByName(sceneNames[index]);
                foreach (GameObject go in scene.GetRootGameObjects())
                {
                    // Перевіряємо, чи об'єкт називається "SceneRoot"
                    if (go.name == "SceneRoot")
                    {
                        // Задаємо позицію та розмір для кожного SceneRoot
                        go.transform.position = positions[index];
                        go.transform.localScale = Vector3.one * 0.5f;
                    }
                }
            };
        }
    }

    // Приклад координат для 3 сцен
    private Vector3[] positions = new Vector3[]
    {
        new Vector3(-25, 0, 25),   // для першої сцени (Zone1_Penguin)
        new Vector3(25, 0, 25),    // для другої сцени (Zone3_Tiger)
        new Vector3(0, 0, -25)     // для третьої сцени (Zone5_Elk)
    };
}

