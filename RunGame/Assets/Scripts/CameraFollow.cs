using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private float followSpeed = 3f;

    private Vector3 offset;

    void Start()
    {
        // Ba�lang��ta karakter ve kamera aras�ndaki fark� belirleyin.
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Hedef pozisyonu hesaplay�n.
        Vector3 targetPosition = target.position + offset;

        // Yeni kamera pozisyonunu, Lerp ile hedef pozisyona do�ru hareket ettirin.
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
    }
}
