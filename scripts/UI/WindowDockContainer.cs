using Godot;
using Chisel;

namespace Chisel.UI
{
    public class WindowDockContainer : PanelContainer
    {
        // Add self (we use this for all of our custom nodes)
        private WindowDockContainer Self;
        public override void _Ready()
        {
            // Make self contain us
            Self = GetNode<WindowDockContainer>(".");
            Globals.RootPanel.DockContainers.Add(Self);
            
            // Always clip content to prevent weird oddities
            RectClipContent = true;
        }
        
        public void DockContainer(DockableDialog Dialog)
        {
            // Tie this container to the dialog and mark it as docked
            Dialog.ToDock(Self);
        }
    }
}