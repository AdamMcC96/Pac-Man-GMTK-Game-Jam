using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerNomsController : NomsController
{
    public float duration = 8.0f;
    protected override void Eat()
    {
        FindObjectOfType<GameManager>().PowerNomEat(this);

    }

}
