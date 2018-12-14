using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public GameObject pauseMenu;
	public bool paused;
	public bool mainMenu;
    public GameObject user;
	// Use this for initialization
	void Awake () {
        if (instance == null) {
            instance = this;
        }
        if (!mainMenu) {
			paused = false;
			Time.timeScale = 1.0f;
			pauseMenu.SetActive(paused);
            Cursor.lockState = CursorLockMode.Locked;
		}
	}

    public void RestartTheGameAfterSeconds(float seconds){
		Time.timeScale = 1.0f;
		StartCoroutine (LoadSceneAfterSeconds (seconds, SceneManager.GetActiveScene ().name));
	}

	public void LoadScene(float seconds, string sceneName){
		StartCoroutine (LoadSceneAfterSeconds (seconds, sceneName));
	}

	public void LoadSceneByIndex(int i){
		SceneManager.LoadScene(i);
	}

	public void LoadMainMenu() {
		SceneManager.LoadScene("startMenu");
	}

    public void LoadProject() {
        SceneManager.LoadScene("project");
    }

	public void LoadNextScene(float seconds) {
		StartCoroutine (LoadSceneAfterSeconds (seconds, null));
	}

	IEnumerator LoadSceneAfterSeconds(float seconds, string sceneName){
		yield return new WaitForSeconds (seconds);
		if (sceneName == null) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		}
		else {
			SceneManager.LoadScene (sceneName);
		}
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape) && !mainMenu) {
			TogglePauseMenu();
		}

        // Debug.Log(Cursor.lockState);
        // if (!mainMenu && !paused && Cursor.lockState == CursorLockMode.None) {
        //     Cursor.lockState = CursorLockMode.Locked;
        // }
		
		// if (Input.GetKeyDown(KeyCode.R) && !mainMenu) {
        // 	RestartTheGameAfterSeconds(0.5f);
    	// }
	}

	public void TogglePauseMenu() {
		if (paused)
        {
            user.GetComponent<MouseLook>().enabled = true;
            Camera.main.GetComponent<MouseLook>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            pauseMenu.SetActive(!paused);
            Time.timeScale = 1.0f;
        }
        else
        {
            user.GetComponent<MouseLook>().enabled = false;
            Camera.main.GetComponent<MouseLook>().enabled = false;
            pauseMenu.SetActive(!paused);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        paused = !paused;
    }
}
