using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyAfterDelay(10f));
    }

    private IEnumerator destroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Center"))
        {
            GameMaster.Instance.scoreUpdate(100);
            Destroy(gameObject);
        }
        else if (c.gameObject.CompareTag("Middle"))
        {
            GameMaster.Instance.scoreUpdate(75);
            Destroy(gameObject);
        }
        else if (c.gameObject.CompareTag("Edge"))
        {
            GameMaster.Instance.scoreUpdate(50);
            Destroy(gameObject);
        }
    }
}
