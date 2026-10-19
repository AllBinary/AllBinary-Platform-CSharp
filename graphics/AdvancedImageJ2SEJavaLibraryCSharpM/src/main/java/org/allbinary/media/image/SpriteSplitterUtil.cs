/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
//using BufferedImage = java.awt.image.BufferedImage;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.image;

public class SpriteSplitterUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly SpriteSplitterUtil instance = new SpriteSplitterUtil();
    public static SpriteSplitterUtil getInstance()
    {
        return SpriteSplitterUtil.instance;
    }

    private readonly CommonSeps commonSeps = CommonSeps.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly string[] ANIMATIONS_LABELS = new string[] { "Row Total:", "Column Total:", "Column Total:", "Row Total:", "Column Total:", "Row Total:" };
    public readonly string DIRECTIONAL_ANIMATIONS = "Directional DLRU";
    public readonly string HORIZONTAL_ANIMATIONS = "Horizontal Animations";
    public readonly string HORIZONTAL_SPRITE = "Horizontal A=R=Y F=C=X";
    private readonly string[] ROW_NAME = new string[] { "idle", "walk", "attack", "defeat" };
    private readonly string _ROW = "_row";
    // throws Exception
    public virtual void process(ImageProcessorInput imageProcessorInput, int totalFrames, int totalAnimations, int widthReduction, int heightReduction, int increaseWidth, int increaseHeight, string spriteType, ImageProcessedVisitor visitor)
    {
        BufferedImage bufferedImage = null;
        BufferedImage[][] generatedBufferedImageArray = null;
        BufferedImage[] bufferedImageArray = imageProcessorInput.getBufferedImageArray();
        for (int index = 0; index < bufferedImageArray.Length; index++) {
            bufferedImage = bufferedImageArray[index];
            this.logUtil.putF(spriteType, this, this.commonStrings.RUN);
            if (spriteType == this.HORIZONTAL_SPRITE) {
                int cellHeight = bufferedImage.getHeight() / totalAnimations;
                int cellWidth = bufferedImage.getWidth() / totalFrames;
                int columns = totalFrames;
                int rows = totalAnimations;
                generatedBufferedImageArray = System.Linq.Enumerable.Range(0, rows).Select(_ => new BufferedImage[columns]).ToArray();
                this.logUtil.putF("Processing Individual Cells columns: " + columns + " rows: " + rows, this, this.commonStrings.RUN);
                this.logUtil.putF("Processing Individual Cells cellHeight: " + cellHeight + " cellWidth: " + cellWidth, this, this.commonStrings.RUN);
                ImageUtil imageUtil = ImageUtil.getInstance();
                string nameEnding = null;
                int x = 0;
                int y = 0;
                for (int index2 = 0; index2 < rows; index2++) {
                    y = cellHeight * index2;
                    for (int index3 = 0; index3 < columns; index3++) {
                        x = cellWidth * index3;
                        generatedBufferedImageArray[index2][index3] = bufferedImage.getSubimage(x + widthReduction, y + heightReduction, cellWidth - (widthReduction * 2), cellHeight - (heightReduction * 2));
                        if (increaseWidth != 0 || increaseHeight != 0) {
                            generatedBufferedImageArray[index2][index3] = imageUtil.createBufferedImageAllowTranslate(generatedBufferedImageArray[index2][index3], cellWidth + increaseWidth, cellHeight + increaseHeight, false, true);
                        }
                        nameEnding = new StringMaker().appendint(index2).append(this.commonSeps.UNDERSCORE).appendint(index3).ToString();
                        visitor.visit(generatedBufferedImageArray[index2][index3], nameEnding, index);
                    }
                }
                this.logUtil.putF("Processing Rows from Cells", this, this.commonStrings.RUN);
                ImageUnifierProperties imageUnifierProperties = new ImageUnifierProperties();
                imageUnifierProperties.setRows((1).ToString());
                imageUnifierProperties.setColumns((columns).ToString());
                ImageUnifierCell imageUnifierCell = new ImageUnifierCell((cellWidth - (2 * widthReduction)).ToString(), (cellHeight - (2 * heightReduction)).ToString());
                imageUnifierProperties.setImageUnifierCell(imageUnifierCell);
                for (int index2 = 0; index2 < rows; index2++) {
                    y = cellHeight * index2;
                    BufferedImage[] tempBufferedImageArray = new BufferedImage[columns];
                    for (int index3 = 0; index3 < columns; index3++) {
                        tempBufferedImageArray[index3] = generatedBufferedImageArray[index2][index3];
                        nameEnding = new StringMaker().appendint(index2).append(this.commonSeps.UNDERSCORE).appendint(1).append(this._ROW).ToString();
                    }
                    BufferedImage generatedBufferedImage = ImageUnifierUtil.getInstance().getImage(tempBufferedImageArray, imageUnifierProperties);
                    visitor.visit(generatedBufferedImage, nameEnding, index);
                }
            } else if (spriteType == HORIZONTAL_ANIMATIONS) {
            } else if (spriteType == this.DIRECTIONAL_ANIMATIONS) {
                int totalFrames2 = 4;
                int cellHeight = bufferedImage.getHeight() / totalFrames2;
                int cellWidth = bufferedImage.getWidth() / totalAnimations;
                int columns = totalAnimations;
                int rows = totalFrames2;
                generatedBufferedImageArray = System.Linq.Enumerable.Range(0, rows).Select(_ => new BufferedImage[columns]).ToArray();
                this.logUtil.putF("Processing Individual Cells for each Direction", this, this.commonStrings.RUN);
                string nameEnding = null;
                int x = 0;
                int y = 0;
                for (int index2 = 0; index2 < rows; index2++) {
                    y = cellHeight * index2;
                    for (int index3 = 0; index3 < columns; index3++) {
                        x = cellWidth * index3;
                        generatedBufferedImageArray[index2][index3] = bufferedImage.getSubimage(x + widthReduction, y + heightReduction, cellWidth - (widthReduction * 2), cellHeight - (heightReduction * 2));
                        if (increaseWidth != 0 || increaseHeight != 0) {
                            generatedBufferedImageArray[index2][index3] = ImageUtil.getInstance().createBufferedImageAllowTranslate(generatedBufferedImageArray[index2][index3], cellWidth + increaseWidth, cellHeight + increaseHeight, false, true);
                        }
                        nameEnding = new StringMaker().append(this.commonStrings.DIRECTION_NAME[index2]).append(this.commonSeps.UNDERSCORE).appendint(index3).ToString();
                        visitor.visit(generatedBufferedImageArray[index2][index3], nameEnding, index);
                    }
                }
                ImageUnifierProperties imageUnifierProperties = new ImageUnifierProperties();
                imageUnifierProperties.setRows((1).ToString());
                imageUnifierProperties.setColumns((columns).ToString());
                ImageUnifierCell imageUnifierCell = new ImageUnifierCell((cellWidth - (2 * widthReduction)).ToString() + increaseWidth, (cellHeight - (2 * heightReduction) + increaseHeight).ToString());
                imageUnifierProperties.setImageUnifierCell(imageUnifierCell);
                this.logUtil.putF("Processing Rows from Cells for each Direction", this, this.commonStrings.RUN);
                for (int index2 = 0; index2 < rows; index2++) {
                    y = cellHeight * index2;
                    BufferedImage[] tempBufferedImageArray = new BufferedImage[columns];
                    for (int index3 = 0; index3 < columns; index3++) {
                        tempBufferedImageArray[index3] = generatedBufferedImageArray[index2][index3];
                        nameEnding = new StringMaker().append(this.commonStrings.DIRECTION_NAME[index2]).append(this.commonSeps.UNDERSCORE).appendint(1).append(this._ROW).ToString();
                    }
                    BufferedImage generatedBufferedImage = ImageUnifierUtil.getInstance().getImage(tempBufferedImageArray, imageUnifierProperties);
                    visitor.visit(generatedBufferedImage, nameEnding, index);
                }
            }
        }
    }

}

