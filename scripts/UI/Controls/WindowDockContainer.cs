using Godot;

namespace Chisel.UI
{
    public class WindowDockContainer : PanelContainer
    {
        // Add self (we use this for all of our custom nodes)
        private WindowDockContainer Self;
        public override void _Ready()
        {
            Globals.RootPanel = GetNode<RootPanel>("/root/UI");
            // Make self contain us
            Self = GetNode<WindowDockContainer>(".");
            Globals.RootPanel.DockContainers.Add(Self);
            
            // Always clip content to prevent weird oddities
            //RectClipContent = true;
        }
    }
}