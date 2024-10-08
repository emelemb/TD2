﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD2.Managers;

namespace TD2.Objects
{
    internal class Wrench : Projectile
    {
        public Wrench(Texture2D tex, Vector2 pos, int targetDirection) : base(tex, pos, targetDirection)
        {
            speed = 5.0f;
            texture = TextureManager.wrench;
        } 
    }
}
