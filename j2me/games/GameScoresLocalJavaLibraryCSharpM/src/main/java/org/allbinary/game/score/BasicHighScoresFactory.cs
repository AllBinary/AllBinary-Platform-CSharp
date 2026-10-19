// Generated Code Do Not Modify

using System;
using System.Linq;
using GameInfo = org.allbinary.game.GameInfo;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SoftwareInformation = org.allbinary.logic.system.SoftwareInformation;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;

namespace org.allbinary.game.score;

public class BasicHighScoresFactory : HighScoresBase
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly AbeClientInformationInterface abeClientInformation;
    public BasicHighScoresFactory(AbeClientInformationInterface abeClientInformation, SoftwareInformation softwareInformation)
    {
        this.abeClientInformation = abeClientInformation;
    }

    private readonly HighScores[] highScoresArray = new HighScores[1];
    private readonly string TOP = "Top";
    private readonly string SCORES = "Scores";
    private readonly string PERSONAL_HIGH_SCORES = "Personal Top Scores";
    private readonly string FETCH = "fetchHighScores";
    public override void fetchHighScores(GameInfo gameInfo, HighScoresResultsListener highScoresResultsListener)
    {
        this.logUtil.putF("Getting Local HighScores", this, this.FETCH);
        this.fetchHighScoresPreload(gameInfo, highScoresResultsListener, true);
    }

    public override void fetchHighScoresPreload(GameInfo gameInfo, HighScoresResultsListener highScoresResultsListener, bool preload)
    {
        try {
            this.highScoresArray[0] = RecordStoreHighScores.getInstance(this.abeClientInformation, gameInfo, this.TOP, this.PERSONAL_HIGH_SCORES, this.SCORES, new ScoreComparator(true));
            highScoresResultsListener.setHighScoresArray(this.highScoresArray);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.FETCH, e);
        }
    }

    public override HighScoresHelperBaseInterface createHighScoresHelper()
    {
        return new HighScoresHelper2();
    }

    public static bool loaded(int index2)
    {
        if (index2 >= 0) {
            return true;
        }
        return false;
    }

}

