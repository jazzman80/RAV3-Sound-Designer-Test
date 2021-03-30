using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayerSoundManager : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] StudioEventEmitter footsteps;
    [SerializeField] StudioEventEmitter jump;

    private Vector3 lastPosition;
    private FMOD.Studio.Bus footbus;
    private string footstring = "Bus:/Footbus";
    private bool isActive;

    private void Start()
    {
        isActive = false;
        footbus = RuntimeManager.GetBus(footstring);
        footbus.setVolume(0.0001f);
        lastPosition = transform.position;
        footsteps.Play();
        Invoke("Activate", 1.0f);
    }

    private void Update()
    {
        if (isActive) footbus.setVolume(Speed() * 0.05f);

        if (Input.GetButtonDown("Jump")) jump.Play();

        lastPosition = transform.position;
    }

    private float Speed()
    {
        Vector3 distance = lastPosition - transform.position;
        return distance.magnitude / Time.deltaTime;
    }

    private void Activate()
    {
        isActive = true;
    }
}
