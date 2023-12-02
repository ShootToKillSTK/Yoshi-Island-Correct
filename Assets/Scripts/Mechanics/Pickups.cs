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
                    collision.GetComponent<PlayerController>();
                    //do powerup functionality
                    break;
                case PickupType.Life:
                    GameManager.Instance.lives++;
                    //do life funtionality
                    break;
                case PickupType.Score:
                    GameManager.Instance.score++;
                    //do score funtionality
                    break;
            }

            Destroy(gameObject);
        }
    }
}
