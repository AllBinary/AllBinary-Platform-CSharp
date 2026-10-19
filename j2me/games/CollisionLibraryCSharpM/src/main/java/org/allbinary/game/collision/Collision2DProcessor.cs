// Generated Code Do Not Modify

using System;
using System.Linq;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;

namespace org.allbinary.game.collision;

public class Collision2DProcessor : CollisionProcessor
{
    public override bool isCollision(AllBinaryLayer myLayer, AllBinaryLayer myLayer2)
    {
        if (myLayer2.getXP() >= myLayer.getX2() || myLayer2.getYP() >= myLayer.getY2() || myLayer2.getX2() <= myLayer.getXP() || myLayer2.getY2() <= myLayer.getYP()) {
            return false;
        } else {
            return true;
        }
    }

}

