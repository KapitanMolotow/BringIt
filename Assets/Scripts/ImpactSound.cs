using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSound : MonoBehaviour
{
    [SerializeField] public float minimumMagnitude;
    [SerializeField] public float volumeMultiplier;
    [SerializeField] public float pitchValue;
    [Range(0f, 0.99f)]
    [SerializeField] public float pitchClampMinimum;
    [Range(1f, 2f)]
    [SerializeField] public float pitchClampMaximum;
    [SerializeField] public List<AudioClip> impactSoundVariations = new List<AudioClip>();
    private AudioSource impactSound;
    private void Start()
    {
        impactSound = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude >= minimumMagnitude)
        {
            Debug.Log(collision.relativeVelocity.magnitude);
            impactSound.clip = impactSoundVariations[Random.Range(0, impactSoundVariations.Count)];
            impactSound.volume = collision.relativeVelocity.magnitude / 20 * volumeMultiplier;
            impactSound.pitch = Mathf.Clamp(impactSound.volume * pitchValue, pitchClampMinimum, pitchClampMaximum);
            impactSound.Play();
        }
    }
}
