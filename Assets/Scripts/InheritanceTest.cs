using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritanceTest : MonoBehaviour
{
    private void Start()
    {
        InteractableObject interactableObject = new InteractableObject();

        ItemA itemA = new ItemA();
        EnemyA enemyA = new EnemyA();
        EnemyB enemyB = new EnemyB();

        interactableObject.GetName();
        itemA.GetName();
        enemyA.GetName();
        enemyB.GetName();

        InteractableObject itemAA = new ItemA();
        InteractableObject enemyAA = new EnemyA();
        InteractableObject enemyBB = new EnemyB();
    }
}

public class InteractableObject
{
    public virtual void GetName()
    {
        Debug.Log("InteractableObject");
    }
}


public class ItemA : InteractableObject
{
    public override void GetName()
    {
        Debug.Log("ItemA");
    }
}

public class EnemyA : InteractableObject
{
    public override void GetName()
    {
        Debug.Log("EnemyA");
    }
}

public class EnemyB : InteractableObject
{
    public override void GetName()
    {
        Debug.Log("EnemyB");
    }
}