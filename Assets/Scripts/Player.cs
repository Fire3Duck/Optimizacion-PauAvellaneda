using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    private InputAction _shootAction;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _BulletSpawn;

    InputAction _moveAction;
    Vector2 _move;

    [SerializeField] float _movementSpeed = 5;

    [SerializeField] Transform _sensorPosition;
    [SerializeField] float _sensorRadius;

    private Rigidbody _rigidbody;

    private AudioSource _audioSource;
    public AudioClip _shootSFX;


    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _moveAction = InputSystem.actions["Move"];
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _shootAction = InputSystem.actions["Attack"];
    }

    // Update is called once per frame
    void Update()
    {
        _move = _moveAction.ReadValue<Vector2>();

        Movement();

        if(_shootAction.WasPerformedThisFrame())
        {
            Shoot();
        }
    }

    void Movement()
    {
        Vector3 moveDirection = new Vector3(_move.x, 0, _move.y);
        _rigidbody.linearVelocity = _move * _movementSpeed;

    }

    void Shoot()
    {
        //Instantiate(_bulletPrefab, _BulletSpawn.position, _BulletSpawn.rotation);

        GameObject bullet = PoolManager.Instance.GetPooledObject("Balas", _BulletSpawn.position, _BulletSpawn.rotation);
        bullet.SetActive(true);
        _audioSource.PlayOneShot(_shootSFX);
    }
}
