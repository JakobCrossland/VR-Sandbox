using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPing : MonoBehaviour
{
    public AudioClip[] centerPings;
    public AudioClip[] middlePings;
    public AudioClip[] edgePings;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void targetPing(int part)
    {
        int rand = Random.Range(0, centerPings.Length);
        switch (part)
        {
            case 0:
                audioSource.PlayOneShot(centerPings[rand]);
                break;
            case 1:
                audioSource.PlayOneShot(middlePings[rand]);
                break;
            case 2:
                audioSource.PlayOneShot(edgePings[rand]);
                break;
        }
    }
}
