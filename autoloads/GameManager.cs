using Godot;

namespace ProjectJotun.Autoloads
{
    public partial class GameManager : Node
    {
        public enum GameState { MainMenu, Playing, Paused, GameOver }

        public static GameManager Instance { get; private set; }

        public GameState CurrentState { get; private set; } = GameState.MainMenu;
        public int CurrentFloor { get; private set; } = 1;

        public override void _Ready()
        {
            Instance = this;
        }

        public void ChangeState(GameState newState)
        {
            CurrentState = newState;
            GD.Print($"Game state changed to {newState}");
        }

        public void AdvanceFloor()
        {
            CurrentFloor++;
        }
    }
}

