using System.Diagnostics.Contracts;
using NodeCanvas.Framework;
using UnityEngine;

public class EggCollection : MonoBehaviour
{
    public int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
            score++;
            GameObject opponent = other.transform.parent.gameObject;
            opponent.GetComponent<Blackboard>().SetVariableValue("eggTarget", null);
            Destroy(other.gameObject);
        }
    }
}
