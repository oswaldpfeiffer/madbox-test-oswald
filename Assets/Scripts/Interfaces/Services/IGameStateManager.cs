public interface IGameStateManager : IService
{
    void ChangeGameState (EGameState newGameState);
    EGameState GetCurrentGameState();
}
