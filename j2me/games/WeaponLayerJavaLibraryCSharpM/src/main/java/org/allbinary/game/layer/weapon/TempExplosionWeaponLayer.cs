// Generated Code Do Not Modify

using System;
using System.Linq;
using Animation = org.allbinary.animation.Animation;
using WeaponProperties = org.allbinary.game.combat.weapon.WeaponProperties;
using RemoteInfo = org.allbinary.game.multiplayer.layer.RemoteInfo;
using Rectangle = org.allbinary.graphics.Rectangle;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using Movement = org.allbinary.physics.movement.Movement;
using GameTickTimeDelayHelperFactory = org.allbinary.time.GameTickTimeDelayHelperFactory;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using ViewPositionBase = org.allbinary.view.ViewPositionBase;

namespace org.allbinary.game.layer.weapon;

public class TempExplosionWeaponLayer : SimpleWeaponLayer
{
    public readonly WeaponProperties weaponProperties = new WeaponProperties(-1L, -1L, 0, 1000, ((short) 0));
    private readonly TimeDelayHelper timeDelayHelper = new TimeDelayHelper(0);
    public TempExplosionWeaponLayer(string name, Movement movement, Animation animationInterface, Rectangle rectangle, ViewPositionBase viewPosition, int timeDelay) : base(name, RemoteInfo.REMOTE_INFO, -1, movement, animationInterface, SimpleWeaponLayer.createDestroyed(), rectangle, viewPosition)
    {
        // base(name, RemoteInfo.REMOTE_INFO, -1, movement, animationInterface, SimpleWeaponLayer.createDestroyed(), rectangle, viewPosition) is called from the constructor declaration
        this.timeDelayHelper.delay = timeDelay;
    }

    // throws Exception
    public override void processTick(AllBinaryLayerManager allBinaryLayerManager)
    {
        if (this.timeDelayHelper.isTime(GameTickTimeDelayHelperFactory.getInstance().startTime)) {
            this.getCollidableInferface().collide(this, this);
            this.totalDamage = this.getInitDamage() + 1;
        }
        base.processTick(allBinaryLayerManager);
    }

}

