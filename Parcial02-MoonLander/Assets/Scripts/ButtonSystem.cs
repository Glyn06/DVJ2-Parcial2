using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class ButtonSystem : MonoBehaviour {

    public List<GameObject> cantObjShow;
    public List<GameObject> cantObjHide;

    private bool onPause = false;

    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);

        GameManager.instance.landed = false;
        GameManager.instance.gameOver = false;
        Time.timeScale = 1;
    }

    public void ShowOBJ() {
        for (int i = 0; i < cantObjShow.Count; i++)
            cantObjShow[i].gameObject.SetActive(true);

        for (int i = 0; i < cantObjHide.Count; i++)
            cantObjHide[i].gameObject.SetActive(false);
    }

    public void HideOBJ() {
        for (int i = 0; i < cantObjShow.Count; i++)
            cantObjShow[i].gameObject.SetActive(false);

        for (int i = 0; i < cantObjHide.Count; i++)
            cantObjHide[i].gameObject.SetActive(true);
    }

    public void ShutDown() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void Pause() {
        if (!onPause)
        {
            Time.timeScale = 0;
            onPause = true;
            ShowOBJ();
        }
        else
        {
            Time.timeScale = 1;
            onPause = false;
            HideOBJ();
        }
    }

}
