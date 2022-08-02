using Godot;

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
            GetNode<EditorMain>("/root/RootNode").DockContainers.Add(Self);
        }
    }
}