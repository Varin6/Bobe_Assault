using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GunController : MonoBehaviour
{

    private ParticleSystem gun;
    private GameObject cam;
    


    private void Awake()
    {
        InitialiseGuns();
    }

    private void InitialiseGuns()
    {
        gun = gameObject.GetComponent<ParticleSystem>();
        cam = GameObject.Find("Main Camera");

    }

    void Start()
    {
        
    }

    

    void Update()
    {
        ProcessFire();
    }

    void ProcessFire()
    {

        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            var ree = Physics.Raycast(ray, out hit, Mathf.Infinity);

            if (ree)
            {
               
                //print(hit.transform.position);
                //Physics.Raycast(transform.position, ray.direction, 20000);
                transform.LookAt(hit.point);
                //Debug.DrawRay(transform.position, ray.direction*50000, Color.green, 20, true);
                
            }
            else
            {
                print("BOBE");
                print(ray.direction * 500);
                transform.LookAt(ray.direction*50000);
            }
        }


        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {

            gun.Play();
            print("shooting");
        }

        if (CrossPlatformInputManager.GetButtonUp("Fire1"))
        {
            print("not shooting");
            gun.Stop();

        }
    }
}
