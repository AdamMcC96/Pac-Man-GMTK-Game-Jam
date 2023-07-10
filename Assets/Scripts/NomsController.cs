using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomsController : MonoBehaviour
{
    protected virtual void Eat() 
    {
        FindObjectOfType<GameManager>().NomEat(this);
    
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            
            Eat();
        }
    }
}
