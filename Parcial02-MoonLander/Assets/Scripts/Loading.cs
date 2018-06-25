using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour {

    public Slider slider;
    public Text nextLevelText;

    void Update()
    {
        if (!LevelManager.instance)
        {
            nextLevelText.text = "Level 1";
            StartCoroutine(LoadAsynch("Level"));
        }
        else
        {
            nextLevelText.text = "Level " + LevelManager.instance.level.ToString();
            StartCoroutine(LoadAsynch("Level"));
        }
    }

    IEnumerator LoadAsynch(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f); //la division por 0.9 es para que vaya de 0 a 1 y no de 0 a 0.9
            slider.value = progress;

            yield return null;
        }
    }
}
