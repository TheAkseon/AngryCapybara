using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance;

    [SerializeField] private ParticleSystem _warpSpeedEffect;

    // New movement
    [SerializeField] private float speed = 2;
    [SerializeField] private float rotationSpeed = 5;
    [SerializeField] private Vector2 movementLimit = Vector2.one;
    [SerializeField] private float _timeApplyInvulnerble = 0.1f;

    private float _originalSpeed;
    private bool _canMove = true;
    private Vector2 _direction = Vector2.zero;
    private bool _extendNitro = false;
    private bool _isInvulnerble = false;

    public bool IsInvulnerble => _isInvulnerble;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start() => _originalSpeed = speed;

    private void FixedUpdate()
    {
        if (CanMove())
        {
            // Handle Movement
            var direction = new Vector3(_direction.x * speed, 0, speed);

            transform.position += direction * Time.fixedDeltaTime;

            // Handle Rotation
            var currRotation = transform.rotation;

            var targetRotation = Quaternion.Euler(new Vector3(0, Mathf.Atan2(_direction.x, _direction.y) * 90 / Mathf.PI, 0));

            transform.rotation = Quaternion.Lerp(currRotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);
        }

        ValidateLocation();
    }

    public void StopMovement() => _canMove = false;

    public void ResumeMovement() => _canMove = true;

    public bool CanMove() => _canMove;

    public void ApplyInvulnerable()
    {
        _isInvulnerble = true;
        Invoke(nameof(StopInvulnerable), _timeApplyInvulnerble);
    }

    private void StopInvulnerable()
    {
        _isInvulnerble = false;
    }

    private void ValidateLocation()
    {
        var currentLocation = transform.position;

        if (currentLocation.x >= movementLimit.y)
        {
            currentLocation.x = movementLimit.y;

            _direction = Vector2.zero;
        }

        else if (currentLocation.x <= movementLimit.x)
        {
            currentLocation.x = movementLimit.x;

            _direction = Vector2.zero;
        }

        transform.position = currentLocation;
    }

    private void OnDragged(Vector2 direction) => _direction = direction; 

    private void OnReleased() => _direction = Vector2.zero;

    private void OnPressed() { }

   public void ApplyNitro(float timeApplyNitro, float nitroMultiplier)
    {
        if (speed == _originalSpeed)
        {
            speed *= nitroMultiplier;
            _warpSpeedEffect.gameObject.SetActive(true);
        }
        else
        {
            _extendNitro = true;
        }

        Invoke(nameof(StopNitro), timeApplyNitro);
    }

    private void StopNitro()
    {
        if (!_extendNitro)
        {
            speed = _originalSpeed;
            _warpSpeedEffect.gameObject.SetActive(false);
        }
        _extendNitro = false;
    }

    private void OnEnable()
    {
        Joystick.OnJoystickDrag += OnDragged;
        Joystick.OnJoystickPress += OnPressed;
        Joystick.OnJoystickRelease += OnReleased;
    }

    private void OnDisable()
    {
        Joystick.OnJoystickDrag -= OnDragged;
        Joystick.OnJoystickPress -= OnPressed;
        Joystick.OnJoystickRelease -= OnReleased;
    }
}
