using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class ButtonSystem : MonoBehaviour {

    public List<GameObject> cantObjShow;
    public List<GameObject> cantObjHide;

    public void Play() {
        SceneManager.LoadScene("Level");
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
        Application.Quit();
    }

}
