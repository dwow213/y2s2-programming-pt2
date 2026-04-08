using NodeCanvas.Framework;
using UnityEditor.Build;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public bool opponentEgg;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (opponentEgg && !collision.gameObject.CompareTag("Opponent"))
        {
            print("touching shit");
            opponentEgg = false;
            GameObject opponent = collision.transform.parent.gameObject;
            //GameObject egg = opponent.transform.GetChild(0).gameObject;
            transform.parent = null;
            opponent.GetComponent<Blackboard>().SetVariableValue("eggTarget", null);
            
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (opponentEgg && !collision.gameObject.CompareTag("Opponent"))
        {
            print("touching shit");
            opponentEgg = false;
            GameObject opponent = collision.transform.parent.gameObject;
            //GameObject egg = opponent.transform.GetChild(0).gameObject;
            transform.parent = null;
            opponent.GetComponent<Blackboard>().SetVariableValue("eggTarget", null);

        }
    }
}
