using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Events;

namespace Core.Managers
{
    public class EventManager : AbstractManager
    {
        public GameStartedEvent GameStartedEvent { get; private set; }
        public CanGenerateNewWaveEvent CanGenerateNewWaveEvent { get; private set; }
        public EnemyWaveGeneratedEvent EnemyWaveGeneratedEvent { get; private set; }
        public EnemyDieEvent EnemyDieEvent { get; private set; }
        public SquadDieEvent SquadDieEvent { get; private set; }
        public FormationDieEvent FormationDieEvent { get; private set; }
        public PlayerDieEvent PlayerDieEvent { get; private set; }
        public DifficultUpEvent DifficultUpEvent { get; private set; }
        public HealthPickedEvent HealthPickedEvent { get; private set; }
        public EndMusicEvent EndMusicEvent { get; private set; }

        public override void Initialization()
        {
            GameStartedEvent = new GameStartedEvent();
            CanGenerateNewWaveEvent = new CanGenerateNewWaveEvent();
            EnemyWaveGeneratedEvent = new EnemyWaveGeneratedEvent();
            EnemyDieEvent = new EnemyDieEvent();
            SquadDieEvent = new SquadDieEvent();
            FormationDieEvent = new FormationDieEvent();
            PlayerDieEvent = new PlayerDieEvent();
            DifficultUpEvent = new DifficultUpEvent();
            HealthPickedEvent = new HealthPickedEvent();
            EndMusicEvent = new EndMusicEvent();
        }

        public override void Finalization()
        {

        }
    }
}