using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.ParticleSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crossHair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;

    bool isFiring;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessFiring();
        MoveCrossHair();
        MoveTarget();
        AimLaser();
    }

   

    public void OnFire(InputValue value)
    {

        isFiring = value.isPressed;

    }
    void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;

            emissionModule.enabled = isFiring;
        }
    }
    void MoveCrossHair()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        crossHair.position = mousePosition;
    }

    private void MoveTarget()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    void AimLaser()
    {
        foreach (GameObject laser in lasers)
        {
            laser.transform.LookAt(targetPoint);
        }
    }
}
