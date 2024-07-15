public interface IEnemyView : IView, IDamageableView
{
    void LookAtHero(IHeroController hero);
}
