public interface IEnemyController : IController, IDamageableController
{
    void Initialize(IHeroController hero, IEnemyModel model, SOHealth health); 
}
