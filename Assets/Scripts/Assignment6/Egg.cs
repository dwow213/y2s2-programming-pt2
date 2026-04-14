using NodeCanvas.Framework;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Rendering;

public class Egg : MonoBehaviour
{
    public bool opponentEgg;
    public bool playerEgg;
    public GameObject eggsHolder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //eggHolder = GameObject.Find("EggHolder");
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if an egg pushed by opponent and is either touched by a player, chicken or an egg pushed by a player
        if (opponentEgg && (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Chicken") || CheckIfPlayerEgg(collision)))
        {
            //stop the egg dead in its tracks and unregister it as an opponent egg
            opponentEgg = false;
            if (transform.parent.CompareTag("Opponent"))
            {
                GameObject opponent = transform.parent.gameObject;
                //GameObject egg = opponent.transform.GetChild(0).gameObject;
                transform.parent = eggsHolder.transform;
                opponent.GetComponent<Blackboard>().SetVariableValue("eggTarget", null);
            }
        }

        //just in case, make it not a player egg if it touches something that is not a player
        if (!collision.gameObject.CompareTag("Player"))
            playerEgg = false;
    }

    //same thing as OnCollisionEnter, just now for if the collision stays with the thingamajig
    private void OnCollisionStay(Collision collision)
    {
        if (opponentEgg && (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Chicken") || CheckIfPlayerEgg(collision)))
        {
            print("touching shit");
            opponentEgg = false;
            if (transform.parent.CompareTag("Opponent"))
            {
                GameObject opponent = transform.parent.gameObject;
                //GameObject egg = opponent.transform.GetChild(0).gameObject;
                transform.parent = null;
                opponent.GetComponent<Blackboard>().SetVariableValue("eggTarget", null);
            }

        }

        if (!collision.gameObject.CompareTag("Player"))
            playerEgg = false;
    }

    //just checks whether the thing they collided with is an egg pushed by a player
    bool CheckIfPlayerEgg(Collision collision)
    {
        Egg egg = collision.gameObject.GetComponent<Egg>();
        if (egg == null)
            return false;

        if (egg.playerEgg)
            return true;
        else
            return false;

    }
}
