/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2011 AllBinary
 * 
 * By agreeing to this license you and any business entity you represent are
 * legally bound to the AllBinary Open License Version 1 legal agreement.
 * 
 * You may obtain the AllBinary Open License Version 1 legal agreement from
 * AllBinary or the root directory of AllBinary's AllBinary Platform repository.
 * 
 * Created By: Travis Berthelot
 *  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
using BasicGameResources = org.allbinary.game.layer.resources.BasicGameResources;
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.game.ag.layer.weapon.mine;

public class MineWeaponResources : BasicGameResources
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static MineWeaponResources getInstance()
    {
        if (MineWeaponResources.instance == NullUtil.getInstance().NULL_OBJECT) {
            MineWeaponResources.instance = new MineWeaponResources();
        }
        return ((MineWeaponResources) MineWeaponResources.instance);
    }

    public readonly string DROP_TEXT_RESOURCE = "/mine_drop_text_20_by_20.png";
    public readonly string DROP_RESOURCE = "/mine_drop_20_by_20.png";
    public readonly string DROP_ICON_RESOURCE = "/mine_drop_icon_20_by_20.png";
    protected MineWeaponResources()
    {
        string ROOT = "/mine";
        string SMALL = "_20_by_20.png";
        string MEDIUM = SMALL;
        string SIZE_FOUR = SMALL;
        string SIZE_FIVE = SMALL;
        string SIZE_SIX = SMALL;
        string[] SIZE = new string[] { SMALL, MEDIUM, SIZE_FOUR, SIZE_FIVE, SIZE_SIX };
        base.init(ROOT, SIZE);
    }

}

