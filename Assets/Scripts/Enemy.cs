using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deathExplosion;

    [SerializeField] private float health = 100;
    [SerializeField] private Transform parent;
    [SerializeField] private int points = 10;


    private PlayerController _playerController; 
    private GameObject bobeShip;
    
    private BoxCollider boxCollider;
    private Scoreboard scoreboard;
    private Rigidbody _rigidbody;
    


    private void Awake()
    {

        bobeShip = GameObject.Find("BobeShip");
        _playerController = bobeShip.GetComponent<PlayerController>();
        scoreboard = FindObjectOfType<Scoreboard>();
        _rigidbody = GetComponent<Rigidbody>();

        InitialiseBoxCollider();

    }
    


    void Start()
    {
        
    }

    

    void Update()
    {
        
    }



    void OnParticleCollision(GameObject gameObject)
    {
        DecreaseHealth();
        PlayDeathEffects();

        if (health <= 0)
        {
            DisableColisions();
            IncreaseScore();
            DestroyMe();
        }
        
    }

    private void DisableColisions()
    {
        _rigidbody.detectCollisions = false;
    }



    private void PlayDeathEffects()
    {
        GameObject fx = Instantiate(deathExplosion, transform.position, transform.rotation);
        fx.transform.parent = parent;
        deathExplosion.SetActive(true);
    }



    private void DecreaseHealth()
    {
        health = health - _playerController.damage;
    }



    void DestroyMe()
    {
        Destroy(gameObject);
    }



    private void InitialiseBoxCollider()
    {
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }



    void IncreaseScore()
    {
        scoreboard.AddScore(points);
    }

}
