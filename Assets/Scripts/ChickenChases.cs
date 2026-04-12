using NodeCanvas.Framework;
using UnityEngine;

public class ChickenChases : MonoBehaviour
{
    Blackboard blackboard;
    public float pushPower;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blackboard = GetComponent<Blackboard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!blackboard.GetVariableValue<bool>("currentlyAttacking"))
            return;

        if (collision.gameObject.tag != "Player" || collision.gameObject.CompareTag("Opponent"))
            return;

        Vector3 directionVector = collision.transform.position - transform.position;
        collision.rigidbody.AddForce(directionVector);
        blackboard.SetVariableValue("currentlyAttacking", true);
    }
}
