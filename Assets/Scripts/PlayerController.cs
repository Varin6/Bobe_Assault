using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Range(1f,20f)]
    [Tooltip("In ms^-1")][SerializeField] private float xSpeed = 15f;
    [SerializeField] private float xRange = 6f;
    [SerializeField] private float yRange = 3f;

    [Header("Pitch/Yaw/Roll")]
    [SerializeField] private float positionPitchFactor = -5;
    [SerializeField] private float controlPitchFactor = -10;
    [SerializeField] private float positionYawFactor = 3;
    [SerializeField] private float controlYawFactor = 10;
    [SerializeField] private float rollFactor = -15;

    [SerializeField] public float damage = 25;

    private bool isControlEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessMovement();
        }
        

    }

    

    private void ProcessMovement()
    {

        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        ProcessTranslation(xThrow, yThrow);
        ProcessRotation(xThrow, yThrow);

    }

    

    void ProcessRotation(float xThrow, float yThrow)
    {

        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor + xThrow * controlYawFactor;
        float roll = xThrow * rollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);


        
    }

    private void ProcessTranslation(float xThrow, float yThrow)
    {
        

        float xOffset = xThrow * Time.deltaTime * xSpeed;
        float yOffset = yThrow * Time.deltaTime * xSpeed;

        float newX = Mathf.Clamp((transform.localPosition.x + xOffset), -xRange, xRange);
        float newY = Mathf.Clamp((transform.localPosition.y + yOffset), -yRange, yRange);

        transform.localPosition = new Vector3(newX, newY, transform.localPosition.z);
    }



    public void OnPlayerDeath()
    {
        isControlEnabled = false;
       
    }



}
