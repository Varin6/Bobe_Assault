using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private PlayerController _playerController;

    [SerializeField] private float restartDelay = 2f;
    [SerializeField] private GameObject deathExplosion = default;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = gameObject.GetComponent<PlayerController>();
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        StartDeathSequence();
        deathExplosion.SetActive(true);
        Invoke("RestartLevel", restartDelay);
        
    }

    private void StartDeathSequence()
    {
        _playerController.OnPlayerDeath();

    }

    void RestartLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
