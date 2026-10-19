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
using Processor = org.allbinary.canvas.Processor;
using HighScores = org.allbinary.game.score.HighScores;
using HighScoresHelperBase = org.allbinary.game.score.HighScoresHelperBase;
using NullHighScoresSingletonFactory = org.allbinary.game.score.NullHighScoresSingletonFactory;
using GameStateFactory = org.allbinary.game.state.GameStateFactory;
using NullPaintable = org.allbinary.graphics.paint.NullPaintable;

namespace org.allbinary.game.displayable.canvas;

public class EndGameProcessor : Processor
{
    public readonly GameStateFactory gameStateFactory = GameStateFactory.getInstance();
    private AllBinaryGameCanvas gameCanvas;
    private readonly long WAIT = 5000L;
    public EndGameProcessor(AllBinaryGameCanvas gameCanvas)
    {
        this.gameCanvas = gameCanvas;
    }

    // throws Exception
    public override void process()
    {
        if (this.gameCanvas.isHighScoreSubmitted()) {
            if (this.gameCanvas.getGameStateTimeHelper().isElapsedTNT(this.WAIT)) {
                if (this.gameCanvas.getGameState() == this.gameStateFactory.SHOW_END_RESULT_GAME_STATE) {
                    HighScoresHelperBase highScoresBase = ((HighScoresHelperBase) this.gameCanvas.highScoresHelper);
                    HighScores highScores = highScoresBase.getSelectedHighScores();
                    if (highScores != NullHighScoresSingletonFactory.getInstance()) {
                        highScoresBase.selectHighScores();
                        this.gameCanvas.getRealHighScoresPaintable().setHighScores(highScores);
                        this.gameCanvas.setGameState(this.gameStateFactory.SHOW_HIGH_SCORE_GAME_STATE);
                        this.gameCanvas.setHighScoresPaintable(this.gameCanvas.getRealHighScoresPaintable());
                    }
                } else if (this.gameCanvas.getGameState() == this.gameStateFactory.SHOW_HIGH_SCORE_GAME_STATE) {
                    this.gameCanvas.setGameState(this.gameStateFactory.SHOW_END_RESULT_GAME_STATE);
                    this.gameCanvas.setHighScoresPaintable(NullPaintable.getInstance());
                }
            }
        }
    }

}

