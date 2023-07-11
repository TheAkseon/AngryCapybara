using UnityEngine;
using UnityEngine.Events;

public class Nitro : MonoBehaviour
{
    [SerializeField] private float _nitroMultiplier;
    [SerializeField] private float _timeApplyNitro;

    public float NitroMultiplier => _nitroMultiplier;
    public float TimeApplyNitro => _timeApplyNitro;

    public event UnityAction<Nitro> Offend;

    private void OnTriggerEnter(Collider other)
    {
        SoundsManager.Instance.PlaySound("Nitro");
        Offend?.Invoke(this);
    }
}
