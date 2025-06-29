using Appodeal.Core.Factory;
using Appodeal.Core.ScriptableObjects;
using Appodeal.Core.Signal;
using UnityEngine;
using Zenject;

namespace Appodeal.Core
{
    public class GameContext : MonoInstaller
    {
        [SerializeField] private CardSpritesSO  _cardSpritesSo;
        [SerializeField] private CardStackView _stackViewPrefab;
        [SerializeField] private GameCardView _cardViewPrefab;
        [SerializeField] private BoardManager _boardManager;
        [SerializeField] private Canvas _canvas;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            Container.BindInstance(_cardSpritesSo).AsSingle();
            Container.Bind<BoardManager>().FromComponentOn(_boardManager.gameObject).AsSingle().NonLazy();
            Container.Bind<Canvas>().FromComponentOn(_canvas.gameObject).AsSingle();
            
            Container.BindInstance(_stackViewPrefab).WhenInjectedInto<CardStackFactory>();
            Container.BindIFactory<Transform, CardStack>().To<CardStack>().FromFactory<CardStackFactory>();
            Container.BindInstance(_cardViewPrefab).WhenInjectedInto<GameCardFactory>();
            Container.BindIFactory<GameCardData, Transform, GameCard>().To<GameCard>().FromFactory<GameCardFactory>();
            
            
            Container.DeclareSignal<OnCardGameClickSignal>();
        }
    }
}