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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonSeps = org.allbinary.@string.CommonSeps;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.score;

public class HighScores : HighScoresInterface
{
    private BasicArrayList orderedHighScoresList = new BasicArrayListD();
    private readonly string name;
    private readonly string heading;
    private readonly string columnOneHeading = "Name";
    private readonly string columnTwoHeading;
    public HighScores(string name, string heading, string columnTwoHeading)
    {
        this.name = name;
        this.heading = heading;
        this.columnTwoHeading = columnTwoHeading;
    }

    public virtual void setList(BasicArrayList orderedHighScoresList)
    {
        this.orderedHighScoresList = orderedHighScoresList;
    }

    public virtual BasicArrayList getList()
    {
        return this.orderedHighScoresList;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual int getTotal()
    {
        return this.getList().size();
    }

    public virtual void addHighScore(HighScore newHighScore)
    {
        this.orderedHighScoresList.add(newHighScore);
    }

    public virtual string getHeading()
    {
        return this.heading;
    }

    public virtual string getColumnOneHeading()
    {
        return this.columnOneHeading;
    }

    public virtual string getColumnTwoHeading()
    {
        return this.columnTwoHeading;
    }

    // throws Exception
    public virtual bool isBestScore(HighScore newHighScore)
    {
        return false;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("HighScores: ");
        stringBuffer.append(this.heading);
        stringBuffer.append(CommonSeps.getInstance().SPACE);
        stringBuffer.append(CommonLabels.getInstance().TOTAL_LABEL);
        stringBuffer.appendint(this.orderedHighScoresList.size());
        return stringBuffer.ToString();
    }

}

