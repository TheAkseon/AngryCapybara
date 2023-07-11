using UnityEngine;

public class Gate : MonoBehaviour
{

    [SerializeField] private int _value;
    [SerializeField] private DeformationType _deformationType;
    [SerializeField] private GateAppearaence _gateAppearaence;
    [SerializeField] private GameObject _effectPrefab;
    [SerializeField] private Transform _particlePosition;

    private void OnValidate()
    {
        _gateAppearaence.UpdateVisual(_deformationType, _value);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerModifier playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();
        if (playerModifier)
        {
            ForceManager.Instance.AddForce(_value);

            if (_deformationType == DeformationType.Width)
            {
                playerModifier.AddWidth(_value);
            }
            else if (_deformationType == DeformationType.Height)
            {
                playerModifier.AddHeight(_value);
            }

            Instantiate(_effectPrefab, _particlePosition.position, transform.rotation);
            Destroy(gameObject);
        }

    }

}
