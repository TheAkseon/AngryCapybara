using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _numberOfForce;
    [SerializeField] private TextMeshProUGUI _countForceText;
    [SerializeField] private GameObject _effectPrefab;
    [SerializeField] private Transform _particlePosition;

    public int NumberOfForce => _numberOfForce;

    public event UnityAction<Enemy> Die;
    private void Start()
    {
        _countForceText.text = _numberOfForce.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (PlayerMove.Instance.IsInvulnerble == false)
        {
            Instantiate(_effectPrefab, _particlePosition.position, transform.rotation);
            Die?.Invoke(this);
        }
    }

    public void SetForce(int value)
    {
        _numberOfForce = value;
        _countForceText.text = _numberOfForce.ToString();
    }
}
