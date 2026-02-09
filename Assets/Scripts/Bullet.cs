using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody _rigidbody;
    [SerializeField] private float _bulletSpeed = 60f;
    public float bulletDamage = 2;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody.AddForce(transform.forward * _bulletSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if(GetComponent<Collider>().gameObject.layer == 6)
        {
            Enemy enemyScript = GetComponent<Collider>().gameObject.GetComponent<Enemy>();
            enemyScript.TakeDamage(bulletDamage);
        }
        gameObject.SetActive(false);
    }
}
