/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2002 AllBinary 
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
using NumberStringHud = org.allbinary.game.ag.layer.hud.basic.NumberStringHud;

namespace org.allbinary.game.layer.capital;

public class HudCapital : Capital
{
    private NumberStringHud capitalGraphic;
    public HudCapital(NumberStringHud moneyGraphic)
    {
        this.capitalGraphic = moneyGraphic;
    }

    public override void removeMoney(int points)
    {
        base.removeMoney(points);
        this.capitalGraphic.reduce(points);
    }

    public override int getTotalMoney()
    {
        return this.capitalGraphic.get();
    }

    public override void addMoney(int points)
    {
        base.addMoney(points);
        this.capitalGraphic.add(points);
    }

}

