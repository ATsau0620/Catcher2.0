using UnityEngine;

/// <summary>
/// This class will apply continuous damage to the Player as long as it stay inside the trigger on the same object
/// </summary>
public class BallHit : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        PlayerCtr controller = other.GetComponent<PlayerCtr>();

        if (controller != null)
        {
            //the controller will take care of ignoring the damage during the invincibility time.
            //controller.Health(-1); 角色控制程式需掛health************
        }
    }
}