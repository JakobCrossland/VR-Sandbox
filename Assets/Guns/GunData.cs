using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Lumin;

public class GunData : MonoBehaviour
{
    private string _id;
    private bool _initialized_ = false;
    public string id
    {
        get { return _id; }
        private set
        {
            if (!_initialized_)
            {
                _id = value;
                _initialized_ = true;
                GameMaster.Instance.incrementGunCounter();
            }
        }
    }

    private void Start()
    {
        id = "G" + GameMaster.Instance.GunCounter;
    }

    private void OnDestroy()
    {
        GameMaster.Instance.GunDestroyedCallback(_id);
    }
}
