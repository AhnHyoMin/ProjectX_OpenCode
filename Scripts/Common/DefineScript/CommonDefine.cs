using System;
using UnityEngine;
public static class CResourcePath
{
    public const string PackagedRoot = @"";



    public const string UIPath = @"Prefabs/UI/";
    public const string UIHUDPath = @"Prefabs/UI/Hud/";
    public const string UIModulePath = @"Prefabs/UI/UIModule/";
    public const string UIListPath = @"Prefabs/UI/UIList/";
    public const string UIIGamePath = @"Prefabs/UI/InGame/";
    public const string EntityPath = @"Prefabs/Entity/";
    public const string PrefabsPath = @"Prefabs/";
    public const string ModelPath = @"Prefabs/Model/";
    public const string ProjectilePath = @"Prefabs/Projectile/";


    public const string ModelAnimations = @"ModelAnimations/";
    public const string AnimatorController = @"ModelAnimations/CharacterAnimator/";

    public const string ActionData = @"ProjectData/ActionData/";

    public const string EffectPath = @"Prefabs/Effect/";
    public const string UIEffectPath = @"Prefabs/Effect/UIEffect/";

    public const string ScenePath = @"Prefabs/Scene/";
    public const string GameModePath = @"Prefabs/GameMode/";
    public const string BGMPath = @"Sound/BGM/";
    public const string SFXPath = @"Sound/SFX/";
    public const string SoundPath = @"Sound/";
    public const string ImagePath = @"Image/";
    public const string MapTrigger = @"Prefabs/Map/MapTrigger/";



    public const string AssetBundle = @"Assets/AssetBundle/";
}

/// <summary>
/// 리스트 UI 프리펩 이름
/// </summary>
public static class CUIListItemName
{
    public const string UIListInventoryItem = "UIListInventoryItem";
    public const string UIListItemInfo = "UIListItemInfo";
    public const string UIListUpgradeNeedItemInfo = "UIListUpgradeNeedItemInfo";

    public const string UIListInventorySkillItem = "UIListInventorySkillItem";
    public const string UIListStateOptionItem = "UIListStateOptionItem";
    public const string UIListRewardItemInfo = "UIListRewardItemInfo";
    public const string UIListStageRewardItemInfo = "UIListStageRewardItemInfo";
    

    public const string UIListShopCategoryItem = "UIListShopCategoryItem";
    public const string UIListShopItem = "UIListShopItem";


    public const string UIListBuffInfoItem = "UIListBuffInfoItem";
    

}

public static class CUIHUDName
{
    public const string UIHudDamageText = "UIHudDamageText";
    public const string UIHudHpBar = "UIHudHpBar";
    public const string UIHudNameBar = "UIHudNameBar";
    public const string UIHudFloatingMessageText = "UIHudFloatingMessageText";


}

public static class CUIEffectName
{
    public const string Text_Bonus = "Text_Bonus";    
}


public static class CEffectName
{
    public const string PortalBlue = "PortalBlue";
}

public static class CTimeActionKey
{
    public const string CreateDamageHUD = "CreateDamageHUD";
    public const string CreateSFX = "CreateSFX";
    public const string CreateProjectile = "CreateProjectile";

}

public static class CSoundName
{

    //----------------------------------------------------------------------
    // BGM
    public const string Intro_BGM = "Intro_BGM";
    public const string Loading_BGM = "Loading_BGM";



    //----------------------------------------------------------------------
    // SFX
    public const string Intro_SFX = "Intro_SFX";  //라게임 로고출력시
    public const string ItemPurchase_SFX = "ItemPurchase_SFX"; //아이템 구매완료시

    public const string WindowClose_SFX = "WindowClose_SFX";
    public const string WindowOpen_SFX = "WindowOpen_SFX";
    
}

/// <summary>
/// 이미지 이름
/// </summary>
public static class CUIImageName
{
    public const string itembg_hammer = "itembg_hammer";
}

public static class CAnimatiorParamKey
{
    public const string Hit_b = "Hit";
    public const string HitIndex_i = "HitIndex";
    public const string Move_b = "Move";
    public const string MoveSpeed_f = "MoveSpeed";
    public const string Attack_b = "Attack";
    public const string AttackSpeed_f = "AttackSpeed";
    public const string AnimationID_i = "AnimationID";
    public const string WeaponType_i = "WeaponType";
    public const string Mirror_b = "Mirror";
    public const string Death_b = "Death";

    public static string[] AnimatorOverrideControllerParamKey = new string[]
   {
        "Death_0", "Death_1", "Death_2", "Death_3",
        "Evade",
        "Hit_0", "Hit_1",
        "Idle", "Run",
        "Phase_0","Phase_1","Phase_2","Phase_3","Phase_4","Phase_5","Phase_6","Phase_7","Phase_8","Phase_9",
   };
}

public static class CSystemDefineKey
{
    /// <summary>
    /// 초기 시작 레벨
    /// </summary>
    public const string START_LEVEL_i = "START_LEVEL_i";
    /// <summary>
    /// 최고 레벨
    /// </summary>
    public const string END_LEVEL_i = "END_LEVEL_i";
    /// <summary>
    /// 스테이지 모드 진입 가능 레벨
    /// </summary>
    public const string BLITZMODE_AVAILABLE_LEVEL_i = "BLITZMODE_AVAILABLE_LEVEL_i";
    /// <summary>
    /// 나닝도당 아이템 보정값
    /// </summary>
    public const string ITEMDROP_DIFF_PARAM_f = "ITEMDROP_DIFF_PARAM_f";
    /// <summary>
    /// 시작 캐릭터 ID
    /// </summary>
    public const string STARTCHARACTER_ID = "STARTCHARACTER_ID";
    /// <summary>
    /// 시작 지급 아이템
    /// </summary>
    public const string STARTGIVEITEM_EItemType_Id = "STARTGIVEITEM_EItemType_Id";

    public const string BLITZSTAGEMODE_ENDLEVEL_i = "BLITZSTAGEMODE_ENDLEVEL_i";
    public const string WAVESTAGEMODE_ENDLEVEL_i = "WAVESTAGEMODE_ENDLEVEL_i";

}

public static class CAnimationID
{
    public static readonly int[] MonsterDeath = new int[] { 401, 402, 403, 404 };

}




public static class CColor
{
    public static Color32 Grade_None = new Color32(215, 215, 215, 20); // 약간 흰색
    public static Color32 Grade_Common = new Color32(215, 215, 215, 255); // 약간 흰색
    public static Color32 Grade_Uncommon = new Color32(0, 104, 55, 255); // 짙은초록
    public static Color32 Grade_Magic = new Color32(24, 76, 152, 255); // 파랑
    public static Color32 Grade_Rare = new Color32(255, 180, 20, 255); // 주황
    public static Color32 Grade_Unique = new Color32(255, 0, 0, 255); // 붉은
    public static Color32 Grade_Legend = new Color32(206, 0, 0, 255); // ???

    public static Color32 Orange = new Color32(255, 125, 0, 255);
    public static Color32 Orange_effect = new Color32(125, 60, 0, 255);
    public static Color32 Red = new Color32(255, 40, 40, 255);
    public static Color32 Red_effect = new Color32(125, 20, 20, 255);
    public static Color32 Yellow = new Color32(255, 255, 0, 255);
    public static Color32 Yellow_effect = new Color32(125, 125, 0, 255);
    public static Color32 Purple = new Color32(255, 0, 255, 255);
    public static Color32 Purple_effect = new Color32(125, 0, 125, 255);
    public static Color32 Blue = new Color32(0, 160, 255, 255);
    public static Color32 Blue_effect = new Color32(0, 80, 125, 255);
    public static Color32 Green = new Color32(16, 228, 16, 255);
    public static Color32 Green_effect = new Color32(8, 114, 8, 255);
    public static Color32 White = Color.white;
    public static Color32 White_effect = new Color32(56, 58, 58, 255);

    public static string ToHtmlStringRGBA(Color32 _Color)
    {
        return "#" + ColorUtility.ToHtmlStringRGBA(_Color);
    }
    public static string ToHtmlStringRGB(Color32 _Color)
    {
        return "#" + ColorUtility.ToHtmlStringRGB(_Color);
    }

}


public static class CLayerName
{
    public const string Player = "Player";
    public const string Enemy = "Enemy";
    public const string DefanceWall = "DefanceWall";

    public const string UI3D = "3DUI";


    public const string Entity = "Entity";
    public const string EntityObstacle = "EntityObstacle";
    public const string Obstacle = "Obstacle";
    public const string EntityBound = "EntityBound";

    public const string TransparentFX = "TransparentFX";
    public const string Default = "Default";

    public const string NGUI = "NGUI";
    public const string NGUI_HUD = "NGUI_HUD";
    public const string NGUI_3D = "NGUI_3D";

}


public static class CTags
{
    public const string Enemy = "Enemy";
    public const string Player = "Player";

}
