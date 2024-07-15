public interface IHeroController : IController, IDamageableController
{
    void Initialize(IHeroModel model, SOHealth health);
}
