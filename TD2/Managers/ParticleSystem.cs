using System;
using Microsoft.Xna.Framework;
using TD2.Objects;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using TD2.GameStates;
using Microsoft.Xna.Framework.Content;

namespace TD2.Managers
{
    internal class ParticleSystem
    {
        private Random random;
        public Vector2 StartLocation { get; set; }    
        private List<Particle> particles;
        private List<Texture2D> textures; 

        public ParticleSystem(List<Texture2D> textures, Vector2 location)
        {
            StartLocation = location;
            this.textures = textures;
            this.particles = new List<Particle>();
            random = new Random();
        }

        public void Update()
        {
            int total = 1;

            for (int i = 0; i < total; i++)
            {
                particles.Add(NewParticle());
            }

            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();
                if (particles[particle].TTL <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        private Particle NewParticle()
        {
            Texture2D texture = textures[random.Next(textures.Count)];
            Vector2 position = StartLocation;
            Vector2 velocity = new Vector2( 1f * (float)(random.NextDouble() * 2 - 1), 1f * (float)(random.NextDouble() * 2 - 1));
            float angle = 0;
            float angularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);

            float red = 1.0f;
            float green = (float)random.NextDouble() * 0.2f + 0.8f;
            float blue = (float)random.NextDouble() * green;
            Color color = new Color( red, green , blue);
            float size = (float)random.NextDouble();
            int ttl = 20 + random.Next(40);

            return new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
          
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Draw(spriteBatch);
            }

        }
    }
}
