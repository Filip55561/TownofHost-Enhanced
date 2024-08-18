using AmongUs.GameOptions;
using static TOHE.Options;


namespace TOHE.Roles.AddOns.Common;



internal class UnTorched : RoleBase
{
    private const int Id = 29000;
    private static OptionItem StartingVision;
    private static OptionItem LostVision;

    public static OptionItem ImpCanLooseVision;
    public static OptionItem CrewCanLooseVision;
    public static OptionItem NeutralCanLooseVision;

    public override CustomRoles ThisRoleBase => CustomRoles.Engineer;
    public override Custom_RoleType ThisRoleType => Custom_RoleType.CrewmateSupport;

    public static float vision;

    public static void SetupCustomOptions()
    {
        SetupAdtRoleOptions(Id, CustomRoles.UnTorched, canSetNum: true);
        ImpCanLooseVision = BooleanOptionItem.Create(Id + 10, "ImpCanLooseVision", true, TabGroup.Addons, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.UnTorched]);
        CrewCanLooseVision = BooleanOptionItem.Create(Id + 11, "CrewCanLooseVision", true, TabGroup.Addons, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.UnTorched]);
        NeutralCanLooseVision = BooleanOptionItem.Create(Id + 12, "NeutralCanLooseVision", true, TabGroup.Addons, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.UnTorched]);
        StartingVision = FloatOptionItem.Create(Id + 13, "StartingVision", new(0f, 5f, 0.05f), 0.5f, TabGroup.Addons, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.UnTorched])
            .SetValueFormat(OptionFormat.Multiplier);
    }

    public static void ApplyGameOptions(IGameOptions opt)
    {
        vision = StartingVision.GetFloat();
        if (!Utils.IsActive(SystemTypes.Electrical))
        opt.SetFloat(FloatOptionNames.CrewLightMod, vision);
        opt.SetFloat(FloatOptionNames.ImpostorLightMod, vision);
    }

    public override void OnEnterVent(PlayerControl pc, Vent vent)
    {
        vision -= LostVision.GetFloat();
    }

    public override void OnShapeshift(PlayerControl shapeshifter, PlayerControl target, bool IsAnimate, bool shapeshifting)
    {
        vision -= LostVision.GetFloat();
    }
}
