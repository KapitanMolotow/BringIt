using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesControl : MonoBehaviour      // TO:DO - FIX START TRANSITION ON NEW SCENE
{
    public Animator _transitionAnimator;

    private void Start()
    {
        if (_transitionAnimator == null)                                                        // If SceneTransition Animator isn't defined,
            _transitionAnimator = GameObject.Find("SceneTransition").GetComponent<Animator>();  // then find it in scene
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.R))            // Press R to reload active scene
            ReloadScene();
        if (Input.GetKey(KeyCode.Q))            // Press Q to load next scene
            LoadNextScene();
    }
    public void ReloadScene() => StartCoroutine(CoroutineLoadScene(SceneManager.GetActiveScene().buildIndex, 0.5f));          // Reload active scene
    public void LoadNextScene() => StartCoroutine(CoroutineLoadScene(SceneManager.GetActiveScene().buildIndex + 1, 2f));    // Load next by build index scene 
    public void LoadScene(int _sceneIndex, float _loadTime) => StartCoroutine(CoroutineLoadScene(_sceneIndex, _loadTime));                          // Load scene by scene build index
    public void LoadScene(string _sceneName) => StartCoroutine(CoroutineLoadScene(_sceneName));                         // Load scene by scene name

    private IEnumerator CoroutineLoadScene(int sceneIndex, float loadTime)
    {
        _transitionAnimator.SetTrigger("End");  // Activate scene transition
        yield return new WaitForSeconds(loadTime);    // Give 1s of wait for LoadScene function (make transition visible)
        SceneManager.LoadScene(sceneIndex);     // Load scene
    }
    private IEnumerator CoroutineLoadScene(string sceneName)
    {
        _transitionAnimator.SetTrigger("End");  // Activate scene transition
        yield return new WaitForSeconds(0.5f);  // Give 1s of wait for LoadScene function (make transition visible)
        SceneManager.LoadScene(sceneName);      // Load scene
    }
}
