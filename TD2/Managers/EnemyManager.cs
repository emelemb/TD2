using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD2.Objects;
using TD2.Utilities;

namespace TD2.Managers
{

    // remeber that the enemies die bu only change texture not stop updating their movement, ake sure that the "ned" only takes dmg whe the enemy is alive
    internal class EnemyManager
    {
        public List<BaseEnemy> enemies;
        bool spawnOk = true;
        GraphicsDevice graphicsDevice;
        float delayT = 2000f;
        float delayC = 2000f;
        int timeSinceLast;
        int time;
        int tabletAmount = 1;
        int computerAmount = 1;
        float wave2 = 20000;



        public EnemyManager(GraphicsDevice gd)
        {
            enemies = new List<BaseEnemy>();
            this.graphicsDevice = gd;
        }

        public void SpawnTabletScarps(GameTime gametime)
        {
            for (int i = 0; i < tabletAmount; i++)
            {
                if (timeSinceLast >= delayT)
                {
                    BaseEnemy tbs = new TabletScraps(graphicsDevice);
                    enemies.Add(tbs);
                    timeSinceLast = 0;
                }
            }

            timeSinceLast += gametime.ElapsedGameTime.Milliseconds;
            if (tabletAmount < enemies.Count)
            {
                spawnOk = false;
            }
        }

        public void SpawnComputers(GameTime gametime)
        {
            for (int i = 0; i < computerAmount; i++)
            {
                if (timeSinceLast >= delayC)
                {
                    BaseEnemy cps = new ComputerScraps(graphicsDevice);
                    enemies.Add(cps);
                    timeSinceLast = 0;
                }
            }

            timeSinceLast += gametime.ElapsedGameTime.Milliseconds;
            if (computerAmount < enemies.Count)
            {
                spawnOk = false;
            }


        }

        public void Update(GameTime gametime)
        {
            time += gametime.ElapsedGameTime.Milliseconds;
            if (spawnOk && time > 20000)
            {
                SpawnTabletScarps(gametime);
                SpawnComputers(gametime);

            }

            if (enemies.Count == 0)
            {
                Globals.timeUntilNextWave -= gametime.ElapsedGameTime.Milliseconds * 0.001f;
            }

            Debug.WriteLine(Globals.timeUntilNextWave);

            if (Globals.timeUntilNextWave <= 0)
            {
                spawnOk = true;
                Globals.waveCount++;
                Globals.timeUntilNextWave = 20;

            }

            foreach (BaseEnemy enemy in enemies)
            {
                enemy.update(gametime);
            }
        }

        public void Draw(SpriteBatch sb)
        {

            foreach (BaseEnemy enemy in enemies)
            {
                enemy.Draw(sb);

            }


        }
    }
}
