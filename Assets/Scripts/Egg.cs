using NodeCanvas.Framework;
using UnityEditor.Build;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public bool opponentEgg;
    public GameObject eggsHolder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //eggHolder = GameObject.Find("EggHolder");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (opponentEgg && !collision.gameObject.CompareTag("Opponent") && !collision.gameObject.CompareTag("Egg"))
        {
            print("touching shit");
            opponentEgg = false;
            GameObject opponent = transform.parent.gameObject;
            //GameObject egg = opponent.transform.GetChild(0).gameObject;
            transform.parent = eggsHolder.transform;
            opponent.GetComponent<Blackboard>().SetVariableValue("eggTarget", null);
            
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (opponentEgg && !collision.gameObject.CompareTag("Opponent") && !collision.gameObject.CompareTag("Egg"))
        {
            print("touching shit");
            opponentEgg = false;
            if (collision.transform.parent.CompareTag("Opponent"))
            {
                GameObject opponent = transform.parent.gameObject;
                //GameObject egg = opponent.transform.GetChild(0).gameObject;
                transform.parent = null;
                opponent.GetComponent<Blackboard>().SetVariableValue("eggTarget", null);
            }
                


        }
    }
}
