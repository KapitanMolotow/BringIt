using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    [SerializeField] public List<AudioClip> finishSounds = new List<AudioClip>();
    private AudioSource audioSurc;
    private void Start()
    {
        audioSurc = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cargo")
        {

            audioSurc.clip = finishSounds[Random.Range(0, finishSounds.Count)];
            audioSurc.Play();
            LoadNextLevel();
        }
    }
    private void LoadNextLevel() => GameObject.FindGameObjectWithTag("ScenesControl"). // Find object ScenesControl object
                                               GetComponent<ScenesControl>().          // Get ScenesControl component
                                               LoadNextScene();                        // Load next scene
}
