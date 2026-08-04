using Godot;
using System.Collections.Generic;
//using ProjectJotun.Entities;

namespace ProjectJotun.Autoloads
{
    // Holds turn order and steps entities through their turns one at a time.
    // Register/unregister entities as they spawn and die.
    public partial class TurnManager : Node
    {
        // public static TurnManager Instance { get; private set; }

        // [Signal]
        // public delegate void TurnStartedEventHandler(Entity entity);

        // [Signal]
        // public delegate void RoundCompletedEventHandler();

        // private readonly List<Entity> _turnOrder = new();
        // private int _currentIndex = 0;

        // public override void _Ready()
        // {
        //     Instance = this;
        // }

        // public void RegisterEntity(Entity entity)
        // {
        //     _turnOrder.Add(entity);
        //     SortBySpeed();
        // }

        // public void UnregisterEntity(Entity entity)
        // {
        //     _turnOrder.Remove(entity);
        // }

        // private void SortBySpeed()
        // {
        //     _turnOrder.Sort((a, b) => b.Stats.Speed.CompareTo(a.Stats.Speed));
        // }

        // public void AdvanceTurn()
        // {
        //     if (_turnOrder.Count == 0) return;

        //     var current = _turnOrder[_currentIndex];
        //     EmitSignal(SignalName.TurnStarted, current);

        //     _currentIndex = (_currentIndex + 1) % _turnOrder.Count;
        //     if (_currentIndex == 0)
        //     {
        //         EmitSignal(SignalName.RoundCompleted);
        //     }
        // }
    }
}

