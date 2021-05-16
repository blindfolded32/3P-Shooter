using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    [SerializeField] WallDestroy boom;

    public void OnTriggerEnter(Collider other)
    {
        print("Boom");
        boom.DestroyIt();
        Destroy(gameObject);
    }
}
