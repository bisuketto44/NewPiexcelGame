using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private Player_NPC player;

    void Awake()
    {
        player = GameObject.FindWithTag("PlayerObject").GetComponent<Player_NPC>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Layout_Collision")
        {
            switch (this.gameObject.tag)
            {

                case "collUP":
                    player.isProcessing[0] = false;
                    player.MotionInterruption(0);
                    break;
                case "collDOWN":
                    player.isProcessing[1] = false;
                    player.MotionInterruption(1);
                    break;
                case "collLEFT":
                    player.isProcessing[2] = false;
                    player.MotionInterruption(2);
                    break;
                case "collRIGHT":
                    player.isProcessing[3] = false;
                    player.MotionInterruption(3);
                    break;
            }
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Layout_Collision")
        {
            switch (this.gameObject.tag)
            {
                case "collUP":
                    player.isProcessing[0] = true;
                    break;
                case "collDOWN":
                    player.isProcessing[1] = true;
                    break;
                case "collLEFT":
                    player.isProcessing[2] = true;
                    break;
                case "collRIGHT":
                    player.isProcessing[3] = true;
                    break;
            }

        }

    }


}
