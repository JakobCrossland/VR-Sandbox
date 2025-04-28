using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    private bool alreadyHit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision c)
    {
        if (alreadyHit)
            return;

        GameObject hitObject = c.collider.gameObject;
        Debug.Log("Bullet hit: " + hitObject.name + " with tag " + hitObject.tag);

        TargetPing targetSFX = hitObject.GetComponent<TargetPing>();

        if (targetSFX == null)
            return;

        switch (hitObject.tag)
        {
            case "Center":
                GameMaster.Instance.scoreUpdate(100);
                targetSFX.targetPing(0);
                alreadyHit = true;
                break;
            case "Middle":
                GameMaster.Instance.scoreUpdate(50);
                targetSFX.targetPing(1);
                alreadyHit = true;
                break;
            case "Edge":
                GameMaster.Instance.scoreUpdate(25);
                targetSFX.targetPing(2);
                alreadyHit = true;
                break;
        }
    }
}
