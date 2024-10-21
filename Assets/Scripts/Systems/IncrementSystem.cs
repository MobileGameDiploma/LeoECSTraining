using Leopotam.EcsLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementSystem : IEcsInitSystem, IEcsRunSystem
{
    public EcsPool<CounterComponent> CounterComponents;
    public EcsFilter CounterComponentFilter;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        CounterComponents = world.GetPool<CounterComponent>();
        CounterComponentFilter = world.Filter<CounterComponent>()
            //.Exc<T>()
            .End();
    }

    public void Run(IEcsSystems systems)
    {
        foreach(var entity in CounterComponentFilter)
        {
            ref CounterComponent counterComponent = ref CounterComponents.Get(entity);
            counterComponent.Value++;
            Debug.Log(counterComponent.Value);
        }
    }
}
