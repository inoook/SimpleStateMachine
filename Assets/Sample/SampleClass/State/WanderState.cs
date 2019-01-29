using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : CharacterStateBase
{
    private Vector3 nextDestination;

    private float wanderTime = 5f;

    private float timer;

    public WanderState(Character character) : base(character)
    {
    }

    public override void OnStateEnter()
    {
        nextDestination = GetRandomDestination();
        timer = 0f;
        character.GetComponent<Renderer>().material.color = Color.green;
    }

    private Vector3 GetRandomDestination()
    {
        return new Vector3(
            UnityEngine.Random.Range(-40, 40),
            0f,
            UnityEngine.Random.Range(-40, 40)
            );
    }

    public override void Tick()
    {
        if (ReachedDestination())
        {
            nextDestination = GetRandomDestination();
        }

        character.MoveToward(nextDestination);

        timer += Time.deltaTime;
        if (timer >= wanderTime)
        {
            //SetState(new ReturnHomeState(character));
            SetState(Character.State.ReturnHome);

        }
    }

    private bool ReachedDestination()
    {
        return Vector3.Distance(character.transform.position, nextDestination) < 0.5f;
    }
}