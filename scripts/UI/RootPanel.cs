using Godot;
using System;

namespace Chisel.UI
{
    public class RootPanel : Panel
    {
        // On ready resize the container to fit the current window size
        public override void _Ready()
        {
            RectSize = OS.WindowSize;
        }

        public override void _Draw()
        {
            // Resize root panel to the window size
            if (RectSize != OS.WindowSize)
            {
                RectSize = OS.WindowSize;
            }
        }
    }
}