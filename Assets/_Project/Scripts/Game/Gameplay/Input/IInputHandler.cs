using System;
using UnityEngine;

namespace _Project.Gameplay
{
    public interface IInputHandler
    {
        Vector2 MovementInput { get; }
        event Action<Vector2> OnScreenTouched;
    }
}