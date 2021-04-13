using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float hitDamage;
    [SerializeField]
    private WoodRotate woodRotate;
    private Rigidbody knifeBody;
    private Vector3 movementVector;
    private bool isMoving = false;

    private void Start()
    {
        knifeBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isMoving = Input.GetMouseButton(0);
        if (isMoving)
        {
            movementVector = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f) * movementSpeed * Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        if (isMoving)
        {
            knifeBody.position += movementVector;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ColliderScale colliderScale = collision.collider.GetComponent<ColliderScale>();
        if (colliderScale != null)
        {
            colliderScale.HitCollider(hitDamage);
            woodRotate.Hit(colliderScale.index, hitDamage);
        }
    }
}
