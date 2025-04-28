using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public AudioClip[] gunshots;
    private AudioSource audioSource;
    public Transform spawnPoint;
    public float bulletSpeed = 50;

    [SerializeField]
    [Range(0f, 1f)]
    private float intensity = 0.15f;
    [SerializeField]
    private float duration = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        XRGrabInteractable grab = GetComponent<XRGrabInteractable>();
        grab.activated.AddListener(Fire);
        GetComponent<XRBaseInteractable>().activated.AddListener(TriggerHaptic);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fire(ActivateEventArgs arg)
    {
        int rand = UnityEngine.Random.Range(0, gunshots.Length);
        audioSource.PlayOneShot(gunshots[rand]);
        GameObject spawnBullet = Instantiate(bullet);
        spawnBullet.transform.position = spawnPoint.position;
        spawnBullet.GetComponent<Rigidbody>().velocity = -(spawnPoint.forward) * bulletSpeed;
    }

    public void TriggerHaptic(BaseInteractionEventArgs eventArgs)
    {
        if(eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            TriggerHaptic(controllerInteractor.xrController);
        }
    }

    public void TriggerHaptic(XRBaseController controller)
    {
        if (intensity > 0)
        {
            controller.SendHapticImpulse(intensity, duration);
        }
    }
}
