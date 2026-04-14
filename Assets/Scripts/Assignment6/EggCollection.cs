using System.Diagnostics.Contracts;
using NodeCanvas.Framework;
using UnityEngine;

public class EggCollection : MonoBehaviour
{
    public int score;

    private void OnTriggerEnter(Collider other)
    {
        CheckCollision(other);
    }

    private void OnTriggerStay(Collider other)
    {
        CheckCollision(other);
    }

    void CheckCollision(Collider other)
    {
        if (other.CompareTag("Egg"))
        {
            //increase the score if an egg
            score++;

            //if the egg was pushed by the opponent
            if (other.transform.parent.CompareTag("Opponent"))
            {
                //reset the opponent's eggTarget so they can look for a new one
                GameObject opponent = other.transform.parent.gameObject;
                print($"opponent: {opponent}");
                opponent.GetComponent<Blackboard>().SetVariableValue("eggTarget", null);
            }
            Destroy(other.gameObject);
        }
    }
}
