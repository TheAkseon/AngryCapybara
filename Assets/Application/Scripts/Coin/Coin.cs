using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject _effectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        CoinManager.Instance.AddMoney(1);
        SoundsManager.Instance.PlaySound("CoinUp");
        Destroy(gameObject);
        Instantiate(_effectPrefab, transform.position, transform.rotation);
    }

}
