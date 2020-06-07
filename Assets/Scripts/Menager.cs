using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menager : MonoBehaviour {

    public GameObject StandardUI;
    public GameObject AfterShotUI;

    public void ResetScene() {
        SceneManager.LoadScene(0);
    }

    public void ChangeUI() {
        StandardUI.SetActive(false);
        AfterShotUI.SetActive(true);
    }

    public void Exit() {
        Application.Quit();
    }
}
