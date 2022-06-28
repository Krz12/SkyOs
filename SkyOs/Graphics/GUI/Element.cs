﻿using SkyOs.Numerics;
using System;

namespace SkyOs.Graphics.GUI
{
    public abstract class Element
    {
        public Action OnClick = () => { }, OnUpdate = () => { };
        public bool Clicked, Hovering, Visible = true;
        public Position Position;
        public Size Size;

        public abstract void Update(Canvas Canvas, Window Parent);
    }
}