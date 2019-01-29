using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnHomeState : CharacterStateBase
{
    private Vector3 destination;

    public ReturnHomeState(Character character) : base(character)
    {
    }

    public override void Tick()
    {
        character.MoveToward(destination);

        if (ReachedHome())
        {
            //SetState(new WanderState(character));
            SetState(Character.State.Wander);
        }
    }

    public override void OnStateEnter()
    {
        character.GetComponent<Renderer>().material.color = Color.blue;
    }

    private bool ReachedHome()
    {
        return Vector3.Distance(character.transform.position, destination) < 0.5f;
    }
}