using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;

public class ChickenChases : MonoBehaviour
{
    Blackboard blackboard;
    public float pushPower;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blackboard = GetComponent<Blackboard>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        print($"collision: {collision.gameObject}, {collision.gameObject.tag}");

        if (!blackboard.GetVariableValue<bool>("currentlyAttacking"))
            return;

        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Opponent"))
            return;

        if (collision.gameObject != blackboard.GetVariableValue<GameObject>("pushTarget"))
            return;

        //push the character the chicken targetted
        Deceleration hitObject = collision.gameObject.GetComponent<Deceleration>();
        Vector3 directionVector = collision.transform.position - transform.position;
        print($"dir vector: {directionVector}, vel: {directionVector.normalized * Mathf.Pow(pushPower, 2)}");
        hitObject.AddKinematicForce(directionVector, pushPower);
        print($"vel: {collision.rigidbody.linearVelocity}");

        //stop chicken's attacking state
        blackboard.SetVariableValue("currentlyAttacking", false);
        print("PUSHING P");
    }
}
