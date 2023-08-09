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
        // Baþlangýçta karakter ve kamera arasýndaki farký belirleyin.
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Hedef pozisyonu hesaplayýn.
        Vector3 targetPosition = target.position + offset;

        // Yeni kamera pozisyonunu, Lerp ile hedef pozisyona doðru hareket ettirin.
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
    }
}
