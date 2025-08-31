using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRange = 3f;
    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float controlPitchFactor = 50f;
    [SerializeField] float rotationSpeed = 10f;
    Vector2 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessPitch();
    }

    
    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXpos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXpos, -xClampRange, xClampRange);

        
        
        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYpos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYpos, -yClampRange, yClampRange);
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    void ProcessRotation()
    {
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, -controlRollFactor*movement.x);

        transform.localRotation=Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);

    }

    private void ProcessPitch()
    {
        Quaternion targetRotation = Quaternion.Euler(-controlPitchFactor * movement.y, 0f, 0f);

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
    }


}
