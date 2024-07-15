public interface IHeroController : IController, IDamageableController, IControllable
{
    void Initialize(IHeroModel model, SOHealth health);
}
