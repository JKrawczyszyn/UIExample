using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Utilities.States
{
    public class StateMachine<T> where T : class, IState
    {
        [Inject]
        private readonly DiContainer container;

        public T CurrentState { get; private set; }

        private readonly Dictionary<Type, T> states = new();
        private readonly Queue<Type> pendingTransitions = new();

        private bool running;

        public void Transition<T1>() where T1 : T
        {
            Type type = typeof(T1);

            if (!states.ContainsKey(type))
            {
                T state = (T)container.Resolve(type);
                states.Add(type, state);
            }

            pendingTransitions.Enqueue(type);

            StartIfShould();
        }

        private void StartIfShould()
        {
            if (running)
                return;

            running = true;

            Update().Forget();
        }

        public void Stop()
        {
            CurrentState = null;

            running = false;

            pendingTransitions.Clear();
        }

        private async UniTask Update()
        {
            while (pendingTransitions.Count > 0)
            {
                if (!running)
                    break;

                Type transition = pendingTransitions.Dequeue();
                bool cancel = await ChangeTo(transition).SuppressCancellationThrow();
                if (cancel)
                    break;
            }

            running = false;
        }

        private async UniTask ChangeTo(Type type)
        {
            if (CurrentState != null)
                Debug.Log($"Change state from '{CurrentState.GetType().Name}'.");

            bool success = states.TryGetValue(type, out T nextState);
            Assert.IsTrue(success, $"State '{type.Name}' is not registered to state machine.");

            CurrentState = nextState;

            Debug.Log($"Change state to '{CurrentState.GetType().Name}'.");

            await CurrentState.OnEnter();
        }
    }
}
