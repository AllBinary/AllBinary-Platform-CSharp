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
//using Command = javax.microedition.lcdui.Command;
//using CommandListener = javax.microedition.lcdui.CommandListener;
using GameInfo = org.allbinary.game.GameInfo;
using HighScore = org.allbinary.game.score.HighScore;
using HighScoreNamePersistanceSingleton = org.allbinary.game.score.HighScoreNamePersistanceSingleton;
using HighScores = org.allbinary.game.score.HighScores;
using HighScoresFactoryInterface = org.allbinary.game.score.HighScoresFactoryInterface;
using HighScoresHelperBaseInterface = org.allbinary.game.score.HighScoresHelperBaseInterface;
using HighScoresResultsListener = org.allbinary.game.score.HighScoresResultsListener;
using MyCanvas = org.allbinary.graphics.displayable.MyCanvas;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.score.displayable;

public class HighScoreUtil : HighScoresResultsListener
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public static readonly Command SUBMIT_TEXTBOX_COMMAND = new Command("Submit", StringUtil.getInstance().EMPTY_STRING, Command.SCREEN, 1);
    private readonly HighScoresFactoryInterface highScoresFactoryInterface;
    private HighScores[] highScoresArray;
    private readonly HighScore highScore;
    private readonly AbeClientInformationInterface abeClientInformation;
    private readonly GameInfo gameInfo;
    private readonly HighScoresHelperBaseInterface highScoresHelper;
    private bool firstTime = true;
    public HighScoreUtil(HighScoresFactoryInterface highScoresFactoryInterface, HighScoresHelperBaseInterface highScoresHelper, AbeClientInformationInterface abeClientInformation, GameInfo gameInfo, CommandListener cmdListener, string name, HighScore highScore)
    {
        this.highScoresFactoryInterface = highScoresFactoryInterface;
        this.highScoresHelper = highScoresHelper;
        this.highScoresArray = this.highScoresHelper.getHighScoresArray();
        this.highScore = highScore;
        this.abeClientInformation = abeClientInformation;
        this.gameInfo = gameInfo;
    }

    public virtual void setHighScoresArray(HighScores[] highScoresArray)
    {
        this.highScoresArray = highScoresArray;
        this.firstTime = false;
        this.saveHighScore();
    }

    public virtual void update(string name)
    {
        HighScoreNamePersistanceSingleton.getInstance().save(this.abeClientInformation, this.gameInfo, name);
        this.highScore.setName(name);
    }

    public virtual void saveHighScore()
    {
        this.logUtil.putF(new StringMaker().append(this.commonStrings.START).append(StringUtil.getInstance().toString(this.highScore)).ToString(), this, "saveHighScore");
        int size = this.highScoresArray.Length;
        if (this.firstTime && size == 0) {
            this.logUtil.putF("Games canvas did not give us any HighScores", this, "saveHighScore");
            this.highScoresFactoryInterface.fetchHighScores(this.gameInfo, this);
            return;
        }
        HighScores highScores = null;
        string highScoresAsString = null;
        for (int index = 0; index < size; index++) {
            highScores = this.highScoresArray[index];
            highScores.addHighScore(this.highScore);
            highScoresAsString = highScores.ToString();
            this.logUtil.putF(new StringMaker().append("Added/Adding Score: ").append(highScoresAsString).ToString(), this, "saveHighScore");
        }
        this.highScoresHelper.setHighScoresArray(this.highScoresArray);
    }

    public virtual void submit(MyCanvas myCanvas)
    {
        CommandListener commandListener = myCanvas.getCustomCommandListener();
        commandListener.commandAction(HighScoreUtil.SUBMIT_TEXTBOX_COMMAND, myCanvas);
    }

}

