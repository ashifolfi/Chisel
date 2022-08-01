using Godot;
using System;

namespace Chisel.UI
{
    public class RootPanel : Panel
    {
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