using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    [SerializeField] private float timeUntilDeath;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeUntilDeath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
