﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OGAni.Frames;

namespace OGAni.Animations
{
    public class AnimationCollection
    {
        public List<Frame> allFrames;
        public List<Animation> animations;
        public string name;
        public string texture;

        public AnimationCollection()
            :this("Animation collection", new List<Frame>(), new List<Animation>(), "")
        {
        }
        public AnimationCollection(string name, List<Frame> allFrames, List<Animation> animations, string texture)
        {
            this.name = name;
            this.allFrames = allFrames;
            this.animations = animations;
            this.texture = texture;
        }
    }
}
