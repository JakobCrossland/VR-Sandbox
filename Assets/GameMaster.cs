using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;

    public TMP_Text scoreUI;
    private int score = 0;

    public event Action<string> gunDestroyEvent;

    private uint counter = 0;
    public uint GunCounter { get => counter; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void Init()
    {
        Instance = null;
    }
    public void incrementGunCounter()
    {
        counter++;
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GunDestroyedCallback(string id)
    {
        gunDestroyEvent?.Invoke(id);
    }

    public void scoreUpdate(int x)
    {
        score += x;
        scoreUI.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
