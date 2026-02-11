using UnityEngine;

public class Enemy : MonoBehaviour
{
    private AudioSource _audioSource;
    private Rigidbody _rigidBody;

    public AudioClip _deathSFX;
    private BoxCollider _boxCollider;
    public float maxHealth;
    private float currentHealth;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidBody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death()
    {
        //direction = 0;
        //_rigidBody.gravityScale = 0;
        _boxCollider.enabled = false;
        _audioSource.PlayOneShot(_deathSFX);
        //Destroy(gameObject, 1);
        gameObject.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        currentHealth-= damage;

        if(currentHealth <= 0)
        {
            Death();
        }
    }
}
