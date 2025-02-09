using Leopotam.EcsLite;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Voody.UniLeo.Lite;

public class EcsStartup : MonoBehaviour
{
    EcsWorld _world;
    EcsSystems _systems;

    void Start()
    {
        // ������� ���������, ���������� �������.
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);
        _systems
            .ConvertScene()
            .Add(new IncrementSystem())
            .Add(new ZigZagMovementSystem())
            .Init();
    }

    void Update()
    {
        // ��������� ��� ������������ �������.
        _systems?.Run();
    }

    void OnDestroy()
    {
        // ���������� ������������ �������.
        if (_systems != null)
        {
            _systems.Destroy();
            _systems = null;
        }
        // ������� ���������.
        if (_world != null)
        {
            _world.Destroy();
            _world = null;
        }
    }
}
