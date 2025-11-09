using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoverPlatformScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gunPrefab;
    private string current_gunID;

    //private bool onEnabledCallback = false;
    private void OnEnable()
    {
        GameMaster.Instance.gunDestroyEvent += CreateGun;
    }

    void Start()
    {
        if(gunPrefab == null)
        {
            Debug.LogError("No Gun Prefab Set");
        }
    }

    private void OnDisable()
    {
        GameMaster.Instance.gunDestroyEvent -= CreateGun;
    }

    void Update()
    {
        
    }

    private void CreateGun(string id)
    {
        if (current_gunID == id)
        {
            GameObject gun = GameObject.Instantiate(gunPrefab);
            current_gunID = gun.GetComponent<GunData>().id;
        }
    }
}
