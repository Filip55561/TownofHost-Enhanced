/*

using AmongUs.GameOptions;
using TOHE.Modules;
using static TOHE.Options;
using static TOHE.Translator;

namespace TOHE.Roles.Impostor;

internal class Taskler : RoleBase
{
    private static readonly Dictionary<byte, NetworkedPlayerInfo.PlayerOutfit> OriginalPlayerSkins = [];

    //===========================SETUP================================\\
    private const int Id = 5500;
    private static readonly HashSet<byte> PlayerIds = [];
    public static bool HasEnabled => PlayerIds.Any();
    
    public override CustomRoles ThisRoleBase => CustomRoles.Shapeshifter;
    public override Custom_RoleType ThisRoleType => Custom_RoleType.ImpostorHindering;
    //==================================================================\\

    private static OptionItem DefaultKillCooldown;

    public override void SetupCustomOption()
    {
        SetupRoleOptions(Id, TabGroup.ImpostorRoles, CustomRoles.Taskler);
        DefaultKillCooldown = FloatOptionItem.Create(Id + 10, GeneralOption.DefaultKillCooldown, new(0f, 180f, 2.5f), 30f, TabGroup.ImpostorRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Taskler])
            .SetValueFormat(OptionFormat.Seconds);
    }
    public override void Init()
    {
        PlayerIds.Clear();
    }
    public override void Add(byte playerId)
    {
        PlayerIds.Add(playerId);
    }
    public override void Remove(byte playerId)
    {
        PlayerIds.Remove(playerId);
    }

    public override void ApplyGameOptions(IGameOptions opt, byte playerId)
    {
    //    AURoleOptions.ShapeshifterCooldown = ShapeshiftCooldown.GetFloat();
    //    AURoleOptions.ShapeshifterDuration = 1f;
    }

    // public override void SetKillCooldown(byte id) => Main.AllPlayerKillCooldown[id] = NowCooldown[id];

    /*
    public override bool OnCheckShapeshift(PlayerControl shapeshifter, PlayerControl target, ref bool resetCooldown, ref bool shouldAnimate)
    {
        if (ShowShapeshiftAnimationsOpt.GetBool() || shapeshifter.PlayerId == target.PlayerId) return true;

        DoEatSkin(shapeshifter, target);
        return false;
    }
    
    public override void OnShapeshift(PlayerControl shapeshifter, PlayerControl target, bool IsAnimate, bool shapeshifting)
    {
        if (!shapeshifting) return;

        DoEatSkin(shapeshifter, target);
    }
    private static void DoEatSkin(PlayerControl shapeshifter, PlayerControl target)
    {
        if (!PlayerSkinsCosumed[shapeshifter.PlayerId].Contains(target.PlayerId))
        {
            if (!Camouflage.IsCamouflage)
            {
                target.SetNewOutfit(ConsumedOutfit, setName: false, setNamePlate: false);
            }

            PlayerSkinsCosumed[shapeshifter.PlayerId].Add(target.PlayerId);
            shapeshifter.Notify(Utils.ColorString(Utils.GetRoleColor(CustomRoles.Devourer), GetString("DevourerEatenSkin")));
            target.Notify(Utils.ColorString(Utils.GetRoleColor(CustomRoles.Devourer), GetString("EatenByDevourer")));

            OriginalPlayerSkins.Add(target.PlayerId, Camouflage.PlayerSkins[target.PlayerId]);
            Camouflage.PlayerSkins[target.PlayerId] = ConsumedOutfit;

            float cdReduction = ReduceKillCooldown.GetFloat() * PlayerSkinsCosumed[shapeshifter.PlayerId].Count;
            float cd = DefaultKillCooldown.GetFloat() - cdReduction;

            NowCooldown[shapeshifter.PlayerId] = cd < MinKillCooldown.GetFloat() ? MinKillCooldown.GetFloat() : cd;
        }
    }
    private static void OnDevourerDied(PlayerControl devourer)
    {
        if (devourer == null) return;
        var devourerId = devourer.PlayerId;

        foreach (byte player in PlayerSkinsCosumed[devourerId])
        {
            Camouflage.PlayerSkins[player] = OriginalPlayerSkins[player];

            if (!Camouflage.IsCamouflage)
            {
                PlayerControl pc =
                    Main.AllAlivePlayerControls.FirstOrDefault(a => a.PlayerId == player);
                if (pc == null) continue;

                pc.SetNewOutfit(OriginalPlayerSkins[player], setName: false, setNamePlate: false);
            }
        }

        PlayerSkinsCosumed[devourerId].Clear();
    }

    public override void OnMurderPlayerAsTarget(PlayerControl killer, PlayerControl devourer, bool inMeeting, bool isSuicide)
    {
        OnDevourerDied(devourer);
    }

    public override void OnPlayerExiled(PlayerControl player, NetworkedPlayerInfo exiled)
    {
        if (exiled != null && exiled.Object.Is(CustomRoles.Devourer))
            OnDevourerDied(exiled.Object);
    }

    public override void SetAbilityButtonText(HudManager hud, byte playerId)
    {
        hud.AbilityButton.OverrideText(GetString("DevourerButtonText"));
    }
}

*/