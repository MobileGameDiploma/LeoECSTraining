using Leopotam.EcsLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ZigZagMovementSystem 
{
    public EcsPool<MovementComponent> CounterComponents;
    public EcsFilter CounterComponentFilter;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        CounterComponents = world.GetPool<MovementComponent>();
        CounterComponentFilter = world.Filter<MovementComponent>()
            //.Exc<T>()
            .End();
    }

    public void Run(IEcsSystems systems)
    {
        foreach (var entity in CounterComponentFilter)
        {
            ref MovementComponent counterComponent = ref CounterComponents.Get(entity);
            
        }
    }

    public void ZigZagMovement()
    {
        Vector3 pos = Vector3.up * Time.deltaTime * speed;
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = pos + axis * Mathf.Sin(Time.time) * magnitude;
        }
    }
