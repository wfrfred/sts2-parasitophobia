using Godot;
using MegaCrit.Sts2.Core.Bindings.MegaSpine;


[GlobalClass]
[ScriptPath("res://Src/Vfx/NSealVfx.cs")]
public partial class NSealVfx : Node
{
    private Node2D _parent;

    private MegaSprite _animController;

    public override void _Ready()
    {
        _parent = GetParent<Node2D>();
        _animController = new MegaSprite(_parent);
        _animController.ConnectAnimationEvent(Callable.From<GodotObject, GodotObject, GodotObject, GodotObject>(OnAnimationEvent));
        _animController.GetAnimationState().SetAnimation("die");
    }

    private void OnAnimationEvent(GodotObject _, GodotObject __, GodotObject ___, GodotObject spineEvent)
    {
        switch (new MegaEvent(spineEvent).GetData().GetEventName())
        {
            case "infect":
                TurnOnInfect();
                break;
            case "stop_infect":
                TurnOffInfect();
                break;
            case "explode":
                StartExplode();
                break;
        }
    }

    private void TurnOnInfect()
    {
    }

    private void TurnOffInfect()
    {
    }

    private void StartExplode()
    {
    }
}
