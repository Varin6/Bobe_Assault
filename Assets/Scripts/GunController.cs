using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GunController : MonoBehaviour
{

    private ParticleSystem gun;
    private GameObject cam;

    [SerializeField]
    private GameObject gunSound;
    [SerializeField] private Transform parent;

    private int _numberOfParticles = 0;



    private void Awake()
    {
        InitialiseGuns();
    }

    private void InitialiseGuns()
    {
        gun = gameObject.GetComponent<ParticleSystem>();
        cam = GameObject.Find("Main Camera");
        //gunSound = gun.GetComponent<AudioSource>();

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
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            var ree = Physics.Raycast(ray, out hit, Mathf.Infinity);

            if (ree)
            {
                transform.LookAt(hit.point);
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
            
        }

        if (CrossPlatformInputManager.GetButtonUp("Fire1"))
        {
            gun.Stop();
        }

        
    }
}
