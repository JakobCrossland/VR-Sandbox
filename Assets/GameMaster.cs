using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;

    public TMP_Text scoreUI;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
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
