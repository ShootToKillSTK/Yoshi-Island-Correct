using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public enum PickupType
    {
        Powerup = 0,
        Life = 1,
        Score = 2,
    }

    public PickupType currentPickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController pc = collision.GetComponent<PlayerController>();

            switch (currentPickup)
            {
                case PickupType.Powerup:
                    pc.StartJumpForceChange();
                    //do powerup functionality
                    break;
                case PickupType.Life:
                        pc.lives++;
                    //do life funtionality
                    break;
                case PickupType.Score:
                    pc.score++;
                    //do score funtionality
                    break;
            }

            Destroy(gameObject);
        }
    }
}
