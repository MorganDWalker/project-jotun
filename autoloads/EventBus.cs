using Godot;

namespace ProjectJotun.Autoloads
{
    // Global signal hub so unrelated systems (UI, combat, dungeon) can react
    // to game events without holding direct references to each other.
    public partial class EventBus : Node
    {
        public static EventBus Instance { get; private set; }

        [Signal] public delegate void EntityDiedEventHandler(Node entity);
        [Signal] public delegate void FloorChangedEventHandler(int newFloor);
        [Signal] public delegate void ItemPickedUpEventHandler(Node item);

        public override void _Ready()
        {
            Instance = this;
        }
    }
}

