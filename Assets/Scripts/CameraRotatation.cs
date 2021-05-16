using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotatation : MonoBehaviour
{
    public Transform player;
    /* public float speedCam = 15;
     public float speedScroll = 15;

     public float maxDistance;

     private bool _isActive = false;
     
     private float _x;
     private float _y;*/
    public float speed;
    
        [SerializeField] Transform target;
        [SerializeField] float delay;

        Coroutine c_move = null;
        Vector3 oldPosition = Vector3.zero;
        Queue<Vector3> qPositions = new Queue<Vector3>();

        void Start()
        {
            oldPosition = target.position;
        }

        void Update()
        {
            if (target.position != oldPosition)
            {
                oldPosition = target.position;

                qPositions.Enqueue(target.position);

                if (c_move == null)
                {
                    c_move = StartCoroutine(c_Move());
                }
            }
        }

        IEnumerator c_Move()
        {
            yield return new WaitForSeconds(delay);

            while (qPositions.Count != 0)
            {
                var p = qPositions.Dequeue();
                p.z = transform.position.z;
                transform.position = p;

                yield return null;
            }

            c_move = null;
        }
    }
