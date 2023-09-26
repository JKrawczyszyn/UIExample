using System.Collections.Generic;
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
        private GameViewConfig config;

        [Inject]
        private GameController controller;

        [Inject]
        private ScenePositionHelper positionProvider;

        private Pool<Bullet> pool;

        private readonly List<Bullet> bullets = new();
        private readonly List<Bullet> toRemove = new();

        private void Awake()
        {
            controller.OnCreateBullet += CreateBullet;

            pool = new Pool<Bullet>(parent, config.BulletPrefab);
        }

        private void CreateBullet(BulletModel model)
        {
            Bullet instance = pool.Get();
            instance.Initialize(model);
            bullets.Add(instance);
        }

        private void Update()
        {
            toRemove.Clear();

            foreach (Bullet bullet in bullets)
            {
                if (!bullet.gameObject.activeSelf)
                    continue;

                if (!positionProvider.IsOnScreen(bullet.transform.position))
                {
                    toRemove.Add(bullet);

                    continue;
                }

                bullet.Move();
            }

            foreach (Bullet bullet in toRemove)
            {
                pool.Release(bullet);

                bullets.Remove(bullet);
            }
        }

        private void OnDestroy()
        {
            controller.OnCreateBullet -= CreateBullet;
        }
    }
}
