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
        if (opponentEgg && (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Chicken") || CheckIfPlayerEgg(collision)))
        {
            print("touching shit");
            opponentEgg = false;
            if (transform.parent.CompareTag("Opponent"))
            {
                GameObject opponent = transform.parent.gameObject;
                //GameObject egg = opponent.transform.GetChild(0).gameObject;
                transform.parent = eggsHolder.transform;
                opponent.GetComponent<Blackboard>().SetVariableValue("eggTarget", null);
            }
        }

        if (!collision.gameObject.CompareTag("Player"))
            playerEgg = false;
    }

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
