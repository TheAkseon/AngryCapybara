using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //[SerializeField] GameObject _smoke;

    public void Play() 
    {
        PlayerAnimationController.Instance.Run();
        //_smoke.SetActive(true);
    }

    public void StartFinishBehaviour() {
        UIBehaviour.Instance.Victory();
    }
}
