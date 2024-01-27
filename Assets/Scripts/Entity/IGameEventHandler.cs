namespace Entity
{
    public interface IGameEventHandler<T>
    {
        public void OnGameEvent(T payload);
    }
}