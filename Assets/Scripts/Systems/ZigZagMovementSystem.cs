using Leopotam.EcsLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ZigZagMovementSystem : IEcsInitSystem, IEcsRunSystem
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

            ZigZagMovement(counterComponent.Transform ,counterComponent.Speed, counterComponent.Magnitude, counterComponent.Frequency);
        }
    }

    public void ZigZagMovement(Transform transform, float speed, float amplitude, float frequency)
    {
        /*        Vector3 pos = Vector3.up * Time.deltaTime * speed;
                transform.position = (pos + Vector3.forward) * Mathf.Sin(Time.time) * magnitude;*/
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        float offsetX = Mathf.Sin(Time.time * frequency) * amplitude;

        transform.position = new Vector3(transform.position.x + offsetX, transform.position.y, transform.position.z);
    }
}
