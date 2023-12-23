using Godot;

public partial class Description : TextEdit
{
    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("ui_focus_next") && HasFocus())
        {
            if (!string.IsNullOrEmpty(FocusNext)) ((Control)GetNode(FocusNext)).GrabFocus();
        }
        else if (@event.IsActionPressed("ui_focus_next") && HasFocus())
        {
            if (!string.IsNullOrEmpty(FocusPrevious)) ((Control)GetNode(FocusPrevious)).GrabFocus();
        }
    }
}