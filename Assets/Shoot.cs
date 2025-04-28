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

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        XRGrabInteractable grab = GetComponent<XRGrabInteractable>();
        grab.activated.AddListener(Fire);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(ActivateEventArgs arg)
    {
        int rand = Random.Range(0, gunshots.Length);
        audioSource.PlayOneShot(gunshots[rand]);
        GameObject spawnBullet = Instantiate(bullet);
        spawnBullet.transform.position = spawnPoint.position;
        spawnBullet.GetComponent<Rigidbody>().velocity = -(spawnPoint.forward) * bulletSpeed;
        Destroy(spawnBullet, 10);
    }
}
