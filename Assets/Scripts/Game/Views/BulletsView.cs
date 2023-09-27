using System.Collections.Generic;
using Entry;
using Game.Controllers;
using Game.Models;
using UnityEngine;
using Utilities;
using Zenject;

namespace Game.Views
{
    public class BulletsView : MonoBehaviour
    {
        [SerializeField]
        private Transform parent;

        [Inject]
        private Config config;
        
        [Inject]
        private GameViewConfig viewConfig;

        [Inject]
        private GameController controller;

        [Inject]
        private ScenePositionHelper positionProvider;

        private Pool<Bullet> pool;

        private readonly List<Bullet> bullets = new();
        private readonly HashSet<Bullet> toRemove = new();

        private void Awake()
        {
            controller.OnCreateBullet += CreateBullet;

            pool = new Pool<Bullet>(parent, viewConfig.BulletPrefab);
        }

        private void CreateBullet(BulletModel model)
        {
            Bullet instance = pool.Get();
            instance.Initialize(model);

            bullets.Add(instance);
        }

        public void RemoveBullet(Bullet bullet)
        {
            toRemove.Add(bullet);
        }

        private void Update()
        {
            ProcessMove();
            ProcessRemove();
        }

        private void ProcessMove()
        {
            foreach (Bullet bullet in bullets)
            {
                if (!bullet.gameObject.activeSelf)
                    continue;

                if (!positionProvider.IsOnScreen(bullet.transform.position, config.BulletRadius))
                {
                    toRemove.Add(bullet);

                    continue;
                }

                bullet.Move();
            }
        }

        private void ProcessRemove()
        {
            foreach (Bullet bullet in toRemove)
            {
                pool.Release(bullet);
                bullets.Remove(bullet);
            }

            toRemove.Clear();
        }

        private void OnDestroy()
        {
            controller.OnCreateBullet -= CreateBullet;
        }
    }
}
