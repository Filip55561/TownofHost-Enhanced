using AmongUs.GameOptions;
using static TOHE.Options;

namespace TOHE.Roles.AddOns.Crewmate;

public class UnTorched
{
    private const int Id = 20400;
    private static OptionItem TorchVision;
    private static OptionItem TorchAffectedByLights;

    public static OptionItem ImpCanBeTiebreaker;
    public static OptionItem CrewCanBeTiebreaker;
    public static OptionItem NeutralCanBeTiebreaker;

    public static void SetupCustomOptions()
    {
        SetupAdtRoleOptions(Id , CustomRoles.UnTorched, canSetNum: true);
        ImpCanBeTiebreaker = BooleanOptionItem.Create(Id + 10, "ImpCanBeTiebreaker", true, TabGroup.Addons, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.UnTorched]);
        CrewCanBeTiebreaker = BooleanOptionItem.Create(Id + 11, "CrewCanBeTiebreaker", true, TabGroup.Addons, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.UnTorched]);
        NeutralCanBeTiebreaker = BooleanOptionItem.Create(Id + 12, "NeutralCanBeTiebreaker", true, TabGroup.Addons, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.UnTorched]);
    }

    public static void ApplyGameOptions(IGameOptions opt)
    {
        if (!Utils.IsActive(SystemTypes.Electrical))
            opt.SetVision(true);
        opt.SetFloat(FloatOptionNames.CrewLightMod, TorchVision.GetFloat());
        opt.SetFloat(FloatOptionNames.ImpostorLightMod, TorchVision.GetFloat());

        if (Utils.IsActive(SystemTypes.Electrical) && !TorchAffectedByLights.GetBool())
            opt.SetVision(true);
        opt.SetFloat(FloatOptionNames.CrewLightMod, TorchVision.GetFloat() / 5);
        opt.SetFloat(FloatOptionNames.ImpostorLightMod, TorchVision.GetFloat() / 5);
    }
}