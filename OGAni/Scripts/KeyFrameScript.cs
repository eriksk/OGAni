using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OGAni.Scripts
{
    public class KeyFrameScript
    {
        protected string[] script;

        public KeyFrameScript(string[] script)
        {
            this.script = script;
        }

        public virtual void Run()
        {
        }
    }
}
