using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{
    [Range(1f,20f)]
    [Tooltip("In ms^-1")][SerializeField] private float xSpeed = 15f;
    [SerializeField] private float xRange;

    [SerializeField] private float positionPitchFactor = -5;
    [SerializeField] private float controlPitchFactor = -10;
    [SerializeField] private float positionYawFactor = 3;
    [SerializeField] private float controlYawFactor = 10;
    [SerializeField] private float rollFactor = -15;

    // Start is called before the first frame update
    void Start()
    {
        
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();


//        if (xOffset < 0)
//        {
//            
//            //transform.Rotate(Vector3.forward * 2);
//            
//
//        } else if (xOffset > 0)
//        {
//            //transform.Rotate(Vector3.back * 2);
//        }
    }

    private void ProcessMovement()
    {

        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        ProcessTranslation(xThrow, yThrow);
        ProcessRotation(xThrow, yThrow);

        print(xThrow);
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

        float newX = Mathf.Clamp((transform.localPosition.x + xOffset), -6f, 6f);
        float newY = Mathf.Clamp((transform.localPosition.y + yOffset), -3f, 3f);

        transform.localPosition = new Vector3(newX, newY, transform.localPosition.z);
    }
}
