using UnityEngine;

public class PlayerPlatformAttachment : MonoBehaviour
{
    private FixedJoint fixedJoint;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            fixedJoint = gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = collision.rigidbody;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            Destroy(fixedJoint);
        }
    }
}
