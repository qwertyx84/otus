namespace Spacebattle.Interfaces
{

    public interface IGameObject
    {
        public int ObjectId { get; }
        public string ObjectName { get; }
        bool Moving { get; }
    }
    public interface ISpaceShip : IGameObject
    {
      public int PlayerId { get; }
      
    }
}
