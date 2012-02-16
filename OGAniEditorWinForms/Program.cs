using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OGAniEditor;

namespace OGAniEditorWinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form1 form = new Form1();
            form.Show();
            Game1 game = new Game1(form.GetDrawSurface());
            form.game = game;
            game.Run();
        }
    }
}
