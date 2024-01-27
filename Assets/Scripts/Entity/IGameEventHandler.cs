namespace Entity
{
    public interface IGameEventHandler<T>
    {
        public void On(T payload);
    }
}