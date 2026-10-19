// Generated Code Do Not Modify

using System;
using System.Linq;
using GameAdState = org.allbinary.game.GameAdState;
using SoftwareInformation = org.allbinary.logic.system.SoftwareInformation;

namespace org.allbinary.business.advertisement;

public class GameAdStateFactory : GameAdStateFactoryInterface
{
    private static readonly GameAdStateFactory instance = new GameAdStateFactory();
    public static GameAdStateFactory getInstance()
    {
        return GameAdStateFactory.instance;
    }

    private readonly GameAdState[] gameAdStateArray = new GameAdState[] { new GameAdState(new AppNameLicensingAdConfiguration()) };
    private GameAdState gameAdState;
    public virtual GameAdState getCurrentInstance()
    {
        return this.gameAdState;
    }

    // throws Exception
    public virtual GameAdStateBase getInstanceForApp(SoftwareInformation softwareInformation)
    {
        this.gameAdState = this.gameAdStateArray[0];
        return this.gameAdStateArray[0];
    }

    public virtual bool isEnabled()
    {
        return false;
    }

    public GameAdStateFactory()
    {
        this.gameAdState = this.gameAdStateArray[0];
    }

}

