using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private string openAnimationName = "OpenDoor";

    [SerializeField] private ItemPedestal pedestal;
    [SerializeField] private Animator doorAnimator;

    private void OnEnable()
    {
        pedestal.OnCorrectItemPlaced += OpenDoor;
    }

    private void OnDisable()
    {
        pedestal.OnCorrectItemPlaced -= OpenDoor;
    }

    private void OpenDoor()
    {
        doorAnimator.SetTrigger(openAnimationName);
    }
}
