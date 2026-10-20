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
//using java.awt;
using java.util;
//using DefaultMutableTreeNode = javax.swing.tree.DefaultMutableTreeNode;
//using MutableTreeNode = javax.swing.tree.MutableTreeNode;
using VectorExplosionGenerator = org.allbinary.animation.VectorExplosionGenerator;
using VectorMirrorGenerator = org.allbinary.animation.VectorMirrorGenerator;
using VectorCenterGenerator = org.allbinary.animation.vector.VectorCenterGenerator;
using GameInputStrings = org.allbinary.game.input.GameInputStrings;
using GPoint = org.allbinary.graphics.GPoint;
using PointFactory = org.allbinary.graphics.PointFactory;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using GraphicsException = org.allbinary.graphics.j2me.GraphicsException;
using StatusFactory = org.allbinary.graphics.j2me.StatusFactory;
using WorkAreaJTreeJPanel = org.allbinary.graphics.j2me.workarea.WorkAreaJTreeJPanel;
using GraphicItemFactory = org.allbinary.graphics.j2me.workarea.tools.GraphicItemFactory;
using GraphicItemInterface = org.allbinary.graphics.j2me.workarea.tools.GraphicItemInterface;
using LinesGraphicItem = org.allbinary.graphics.j2me.workarea.tools.LinesGraphicItem;
using MouseStrings = org.allbinary.graphics.j2me.workarea.tools.MouseStrings;
using Points = org.allbinary.graphics.j2me.workarea.tools.Points;
using ToolFactory = org.allbinary.graphics.j2me.workarea.tools.ToolFactory;
using MyGraphicItemEvent = org.allbinary.graphics.j2me.workarea.tools.@event.MyGraphicItemEvent;
using MyGraphicItemEventListener = org.allbinary.graphics.j2me.workarea.tools.@event.MyGraphicItemEventListener;
using MyGraphicItemEventService = org.allbinary.graphics.j2me.workarea.tools.@event.MyGraphicItemEventService;
using RandomRotationFactory = org.allbinary.graphics.pipeline.RandomRotationFactory;
using LOGGING = org.allbinary.log.LOGGING;
using StdUtil = org.allbinary.logic.StdUtil;
using GuiLog = org.allbinary.logic.communication.log.GuiLog;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using PositionStrings = org.allbinary.math.PositionStrings;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using Node = org.w3c.dom.Node;

namespace org.allbinary.graphics.j2me.workarea.canvas;

public class CanvasJPanel : javax.swing.JPanel, java.awt.event.MouseListener, java.awt.event.MouseMotionListener, java.awt.event.KeyListener, MyGraphicItemEventListener
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static int frame = 0;
    private readonly GuiLog guiLog = GuiLog.getInstance();
    private readonly GameInputStrings gameInputStrings = GameInputStrings.getInstance();
    private GraphicItemInterface selectedTool = null;
    private HashMap<object, object> graphicItemHashMap = null;
    private IntegerDimension canvasDimension = null;
    private double angle = 0.0;
    private DefaultMutableTreeNode canvasTreeNode = null;
    private CanvasTreeLabel frameLabel = null;
    private WorkAreaJTreeJPanel workAreaJTreeJPanel = null;
    private static readonly Color gridColor = new Color(((int) BasicColorFactory.getInstance().WHITE));
    private static readonly Color backgroundColor = new Color(((int) BasicColorFactory.getInstance().CLEAR_COLOR));
    private readonly Grid grid;
    public CanvasJPanel(WorkAreaJTreeJPanel workAreaJTreeJPanel, Dimension dimension, int x, int y)
    {
        this.grid = new Grid();
        try {
            this.workAreaJTreeJPanel = workAreaJTreeJPanel;
            this.initComponents();
            this.initMyComponents();
            this.setSize(dimension);
            this.setCanvasSize(x, y);
        } catch (Exception e) {
            if (LOGGING.contains(LOGGING.GRAPHICSCREATION)) {
                this.guiLog.put("Constructor Error", this, "contructor", e);
            }
        }
    }

    public CanvasJPanel(WorkAreaJTreeJPanel workAreaJTreeJPanel, Dimension dimension, CanvasDom canvasDom)
    {
        this.grid = new Grid(canvasDom.getGrid());
        try {
            this.workAreaJTreeJPanel = workAreaJTreeJPanel;
            this.initComponents();
            this.initMyComponents();
            this.setSize(dimension);
            this.setCanvasSize(canvasDom.getDimension().getWidth(), canvasDom.getDimension().getHeight());
            this.graphicItemHashMap = canvasDom.getGraphicItemHashMap();
            object[] graphicItemArray = this.graphicItemHashMap.keySet().toArray();
            int size = graphicItemArray.Length;
            for (int index = 0; index < size; index++) {
                MutableTreeNode graphicItemTreeNode = ((MutableTreeNode) graphicItemArray[index]);
                this.canvasTreeNode.add(graphicItemTreeNode);
            }
            this.repaint();
            this.setAngle(canvasDom.getAngle());
            this.workAreaJTreeJPanel.updateTree();
            this.workAreaJTreeJPanel.expand();
            this.workAreaJTreeJPanel.repaint();
        } catch (Exception e) {
            if (LOGGING.contains(LOGGING.GRAPHICSCREATION)) {
                this.guiLog.put("Constructor Error", this, "contructor", e);
            }
        }
    }

    // throws Exception
    private void initMyComponents()
    {
        this.frameLabel = new CanvasTreeLabel("FrameLabel" + CanvasJPanel.frame.ToString());
        this.canvasTreeNode = new DefaultMutableTreeNode(this.frameLabel);
        CanvasJPanel.frame++;
        this.workAreaJTreeJPanel.add(this.getTreeNode());
        this.graphicItemHashMap = StdUtil.getInstance().createHashMap();
        this.grid.grid = PointFactory.getInstance().createXY(0, 0);
        this.setCanvasDimension(new IntegerDimension(0, 0));
        this.selectedTool = null;
        this.addKeyListener(this);
        this.addMouseListener(this);
        this.addMouseMotionListener(this);
        MyGraphicItemEventService.addListener(this);
    }

    public virtual MutableTreeNode getTreeNode()
    {
        return this.canvasTreeNode;
    }

    private void initComponents()
    {
        setLayout(new java.awt.GridLayout(1, 1));
    }

    // throws Exception
    public virtual void setCanvasSize(int x, int y)
    {
        this.grid.isGridPossible = true;
        if (x <= 0) {
            this.grid.isGridPossible = false;
            throw new GraphicsException("X Size Error: " + x, this, "setWorkAreaSize");
        }
        if (y <= 0) {
            this.grid.isGridPossible = false;
            throw new GraphicsException("Y Size Error: " + y, this, "setWorkAreaSize");
        }
        if (x > this.getWidth()) {
            this.grid.isGridPossible = false;
        }
        if (y > this.getHeight()) {
            this.grid.isGridPossible = false;
        }
        this.setCanvasDimension(new IntegerDimension(x, y));
        this.grid.isChanged = true;
    }

    public virtual void setGrid(GPoint point)
    {
        this.setGrid(point.getX(), point.getY());
    }

    public virtual void setGrid(int xSize, int ySize)
    {
        try {
            if (xSize >= getCanvasDimension().getWidth() / 2 || xSize < 1) {
                throw new GraphicsException("X Size Error: " + xSize + " WorkArea X: " + getCanvasDimension().getWidth(), this, "setGrid");
            }
            if (ySize >= getCanvasDimension().getHeight() / 2 || ySize < 1) {
                throw new GraphicsException("Y Size Error" + ySize + " WorkArea Y: " + getCanvasDimension().getHeight(), this, "setGrid");
            }
            this.grid.grid = PointFactory.getInstance().createXY(xSize, ySize);
            this.grid.isChanged = true;
        } catch (Exception e) {
        }
    }

    // throws Exception
    public virtual void setDefaultGrid()
    {
        int xPixelsPerWorkAreaPixel = this.getWidth() / this.getCanvasDimension().getWidth();
        int yPixelsPerWorkAreaPixel = this.getHeight() / this.getCanvasDimension().getHeight();
        this.setGrid(1, 1);
        this.grid.isChanged = true;
    }

    public virtual double getAngle()
    {
        return this.angle;
    }

    public virtual void setAngle(double angle)
    {
        this.angle = angle;
    }

    public virtual void addAngle(double angle)
    {
        this.setAngle(this.angle + angle);
    }

    public virtual void explodeAll()
    {
        BasicArrayList newPoints = new BasicArrayListD();
        object[] graphicItemArray = this.getGraphicItemHashMap().keySet().toArray();
        int size = graphicItemArray.Length;
        for (int index = 0; index < size; index++) {
            MutableTreeNode graphicItemNode = ((MutableTreeNode) graphicItemArray[index]);
            GraphicItemInterface graphicItem = ((GraphicItemInterface) this.getGraphicItemHashMap().get(graphicItemNode));
            if (graphicItem.getName() == LinesGraphicItem.getStaticName()) {
                while (graphicItem.getPointsInterface().getSize() > 2) {
                    GraphicItemInterface newGraphicItem = GraphicItemFactory.getInstance().getInstance(graphicItem.getName()).getInstance(this);
                    GPoint pointOne = GPoint.getInstance(graphicItem.removePoint());
                    GPoint pointTwo = GPoint.getInstance(graphicItem.removePoint());
                    if (pointOne != null && pointTwo != null) {
                        newGraphicItem.addPoint(pointOne);
                        newGraphicItem.addPoint(pointTwo);
                    }
                    newPoints.add(newGraphicItem);
                }
            }
        }
        int size2 = newPoints.size();
        for (int index = 0; index < size2; index++) {
            GraphicItemInterface newGraphicItem = ((GraphicItemInterface) newPoints.get(index));
            this.canvasTreeNode.add(newGraphicItem.getTreeNode());
            this.getGraphicItemHashMap().put(newGraphicItem.getTreeNode(), newGraphicItem);
        }
        this.workAreaJTreeJPanel.updateTree();
        this.workAreaJTreeJPanel.expand();
        this.workAreaJTreeJPanel.repaint();
    }

    // throws Exception
    public virtual void explode(int howMuch, int explosionType)
    {
        object[] graphicItemArray = this.getGraphicItemHashMap().keySet().toArray();
        int size = graphicItemArray.Length;
        for (int index = 0; index < size; index++) {
            GraphicItemInterface item = ((GraphicItemInterface) this.getGraphicItemHashMap().get(graphicItemArray[index]));
            BasicArrayList basicArrayList = VectorExplosionGenerator.getInstance().createList(item.getPointsInterface().getPoints(), howMuch, VectorExplosionGenerator.getInstance().RANDOM);
            Points newPoints = new Points();
            newPoints.addPoints(basicArrayList);
            item.setPointsInterface(newPoints);
            int angleDelta = RandomRotationFactory.getInstance().getNextRandomAngle(howMuch);
            item.setAngle(angleDelta);
        }
        this.repaint();
    }

    // throws Exception
    public virtual void mirror()
    {
        int width = this.getCanvasDimension().getWidth();
        object[] graphicItemArray = this.getGraphicItemHashMap().keySet().toArray();
        int size = graphicItemArray.Length;
        for (int index = 0; index < size; index++) {
            GraphicItemInterface item = ((GraphicItemInterface) this.getGraphicItemHashMap().get(graphicItemArray[index]));
            BasicArrayList basicArrayList = VectorMirrorGenerator.getInstance().getInstance(item.getPointsInterface().getPoints(), width);
            Points newPoints = new Points();
            newPoints.addPoints(basicArrayList);
            item.setPointsInterface(newPoints);
        }
        this.repaint();
    }

    // throws Exception
    public virtual void center()
    {
        new VectorCenterGenerator().transform(this.getGraphicItemHashMap());
        this.repaint();
    }

    public virtual void setNewTool()
    {
        try {
            StatusFactory.getInstance().setStatus("Tool Selected");
            this.selectedTool = ToolFactory.getInstance().getSelectedToolFactory().getInstance(this);
            MutableTreeNode newNode = this.selectedTool.getTreeNode();
            this.getGraphicItemHashMap().put(newNode, this.selectedTool);
            this.canvasTreeNode.add(newNode);
            if (this.getSelectedTool() == null) {
                throw new GraphicsException("No Tool Selected", this, "setSelectedTool");
            }
        } catch (Exception e) {
        }
    }

    // throws Exception
    public virtual void duplicateGraphicItem(GraphicItemInterface graphicItem)
    {
        GraphicItemInterface graphicItemClone = graphicItem.duplicate();
        this.getGraphicItemHashMap().put(graphicItemClone.getTreeNode(), graphicItemClone);
        this.canvasTreeNode.add(graphicItemClone.getTreeNode());
    }

    // throws Exception
    public virtual void duplicateGraphicItemHashMap(HashMap<object, object> hashMap)
    {
        object[] mutableTreeNodeArray = hashMap.keySet().toArray();
        int size = mutableTreeNodeArray.Length;
        for (int index = 0; index < size; index++) {
            MutableTreeNode treeNode = ((MutableTreeNode) mutableTreeNodeArray[index]);
            GraphicItemInterface graphicItem = ((GraphicItemInterface) hashMap.get(treeNode));
            this.duplicateGraphicItem(graphicItem);
        }
    }

    public virtual HashMap<object, object> getGraphicItemHashMap()
    {
        return this.graphicItemHashMap;
    }

    public virtual int getXPixelsPerWorkAreaPixel()
    {
        int x = this.getGrid().grid.getX() * (this.getWidth() - 10) / this.getCanvasDimension().getWidth();
        if (this.getGrid().getZoom() == 1) {
            return 1;
        } else {
            return x;
        }
    }

    public virtual int getYPixelsPerWorkAreaPixel()
    {
        int y = this.getGrid().grid.getY() * (this.getHeight() - 10) / this.getCanvasDimension().getHeight();
        if (this.getGrid().getZoom() == 1) {
            return 1;
        } else {
            return y;
        }
    }

    public virtual GraphicItemInterface getSelectedTool()
    {
        return this.selectedTool;
    }

    public virtual void drawItems(Graphics graphics)
    {
        double? angleDouble = this.angle;
        object[] graphicItemArray = this.getGraphicItemHashMap().keySet().toArray();
        int size = graphicItemArray.Length;
        for (int index = 0; index < size; index++) {
            GraphicItemInterface item = ((GraphicItemInterface) this.getGraphicItemHashMap().get(graphicItemArray[index]));
            item.paint(graphics, angleDouble, this.getCanvasDimension(), this.getXPixelsPerWorkAreaPixel(), this.getYPixelsPerWorkAreaPixel());
        }
    }

    public virtual void drawGrid(Graphics graphics)
    {
        int xAdjust = (this.getWidth() % this.getXPixelsPerWorkAreaPixel()) / 2;
        int yAdjust = (this.getHeight() % this.getYPixelsPerWorkAreaPixel()) / 2;
        int xLeft = xAdjust;
        int yUpper = yAdjust;
        int xRight = this.getWidth() - xAdjust;
        int yLower = this.getHeight() - yAdjust;
        graphics.setColor(CanvasJPanel.gridColor);
        for (int value = yAdjust; value <= this.getHeight() - yAdjust; value += this.getYPixelsPerWorkAreaPixel()) {
            graphics.drawLine(xLeft, value, xRight, value);
        }
        for (int value = xAdjust; value <= this.getWidth() - xAdjust; value += this.getYPixelsPerWorkAreaPixel()) {
            graphics.drawLine(value, yUpper, value, yLower);
        }
    }

    public virtual void paint(Graphics graphics)
    {
        try {
            if (this.getGrid().isChanged) {
                graphics.setColor(CanvasJPanel.backgroundColor);
                graphics.fillRect(0, 0, getWidth(), getHeight());
                if (this.getGrid().getZoom() > 2 && this.getGrid().isGridOn && this.getGrid().isGridPossible) {
                    this.setDefaultGrid();
                    this.drawGrid(graphics);
                }
                this.drawItems(graphics);
                graphics.drawString(this.getAngle().ToString(), this.getWidth() - 75, this.getHeight() - 15);
                this.grid.isChanged = false;
            }
        } catch (Exception e) {
        }
    }

    public virtual void repaint()
    {
        if (this.grid != null) {
            this.grid.isChanged = true;
        }
        base.repaint();
    }

    // throws Exception
    public virtual Node toDom()
    {
        return new CanvasDom(this).toDom();
    }

    public virtual void changed()
    {
        this.grid.isChanged = true;
    }

    public virtual void mouseClicked(java.awt.event.MouseEvent mouseEvent)
    {
        StatusFactory.getInstance().setStatusNoLog(MouseStrings.getInstance().MOUSE_CLICKED_LABEL + this.logMouseEvent(mouseEvent));
        if (this.getSelectedTool() != null && this.getSelectedTool().isActive()) {
            GraphicItemInterface graphicItem = this.getSelectedTool();
            graphicItem.mouseClicked(mouseEvent, this.getXPixelsPerWorkAreaPixel(), this.getYPixelsPerWorkAreaPixel());
        } else {
            this.setNewTool();
            GraphicItemInterface graphicItem = this.getSelectedTool();
            if (graphicItem != null) {
                graphicItem.mouseClicked(mouseEvent, this.getXPixelsPerWorkAreaPixel(), this.getYPixelsPerWorkAreaPixel());
            }
        }
        this.grid.isChanged = true;
        this.repaint();
        this.workAreaJTreeJPanel.updateTree();
        this.workAreaJTreeJPanel.expand();
        this.workAreaJTreeJPanel.repaint();
    }

    public virtual void mouseEntered(java.awt.event.MouseEvent mouseEvent)
    {
        StatusFactory.getInstance().setStatusNoLog(this.logMouseEvent(mouseEvent));
    }

    public virtual void mouseExited(java.awt.event.MouseEvent mouseEvent)
    {
        StatusFactory.getInstance().setStatusNoLog(this.logMouseEvent(mouseEvent));
    }

    public virtual void mousePressed(java.awt.event.MouseEvent mouseEvent)
    {
        StatusFactory.getInstance().setStatusNoLog(MouseStrings.getInstance().MOUSE_PRESSED_LABEL + this.logMouseEvent(mouseEvent));
        if (this.getSelectedTool() != null) {
            GraphicItemInterface graphicItem = this.getSelectedTool();
            graphicItem.mousePressed(mouseEvent, this.getXPixelsPerWorkAreaPixel(), this.getYPixelsPerWorkAreaPixel());
        }
        this.requestFocus();
        this.grid.isChanged = true;
        this.repaint();
    }

    public virtual void mouseReleased(java.awt.event.MouseEvent mouseEvent)
    {
        StatusFactory.getInstance().setStatusNoLog(MouseStrings.getInstance().MOUSE_RELEASED_LABEL + this.logMouseEvent(mouseEvent));
        GraphicItemInterface graphicItem = this.getSelectedTool();
        if (graphicItem != null) {
            graphicItem.mouseReleased(mouseEvent, this.getXPixelsPerWorkAreaPixel(), this.getYPixelsPerWorkAreaPixel());
        }
        this.requestFocus();
        this.grid.isChanged = true;
        this.repaint();
    }

    public virtual void mouseDragged(java.awt.event.MouseEvent mouseEvent)
    {
        StatusFactory.getInstance().setStatusNoLog(MouseStrings.getInstance().MOUSE_DRAGGED_LABEL + this.logMouseEvent(mouseEvent));
        GraphicItemInterface graphicItem = this.getSelectedTool();
        if (graphicItem != null) {
            graphicItem.mouseDragged(mouseEvent, this.getXPixelsPerWorkAreaPixel(), this.getYPixelsPerWorkAreaPixel());
        }
        this.requestFocus();
        this.grid.isChanged = true;
        this.repaint();
    }

    public virtual void mouseMoved(java.awt.event.MouseEvent mouseEvent)
    {
        StatusFactory.getInstance().setStatusNoLog(MouseStrings.getInstance().MOUSE_MOVED_LABEL + this.logMouseEvent(mouseEvent));
        if (this.getSelectedTool() != null && this.getSelectedTool().isActive()) {
            GraphicItemInterface graphicItem = this.getSelectedTool();
            graphicItem.mouseMoved(mouseEvent, this.getXPixelsPerWorkAreaPixel(), this.getYPixelsPerWorkAreaPixel());
        }
        this.requestFocus();
        this.grid.isChanged = true;
        this.repaint();
    }

    private string logMouseEvent(java.awt.event.MouseEvent mouseEvent)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(PositionStrings.getInstance().X_LABEL);
        stringBuffer.appendint(((int) (mouseEvent.getX() / this.getXPixelsPerWorkAreaPixel())));
        stringBuffer.append(CommonSeps.getInstance().SPACE);
        stringBuffer.append(PositionStrings.getInstance().Y_LABEL);
        stringBuffer.appendint(((int) (mouseEvent.getY() / this.getYPixelsPerWorkAreaPixel())));
        return stringBuffer.ToString();
    }

    public virtual void keyPressed(java.awt.event.KeyEvent keyEvent)
    {
        StatusFactory.getInstance().setStatus("Key Pressed");
        try {
            object[] graphicItemArray = this.graphicItemHashMap.keySet().toArray();
            int size = graphicItemArray.Length;
            for (int index = 0; index < size; index++) {
                GraphicItemInterface graphicItemInterface = ((GraphicItemInterface) this.graphicItemHashMap.get(graphicItemArray[index]));
                int keyCode = keyEvent.getKeyCode();
                if (graphicItemInterface.isActive()) {
                    if (keyCode == keyEvent.VK_UP) {
                        graphicItemInterface.translate(0, -1);
                    } else if (keyCode == keyEvent.VK_DOWN) {
                        graphicItemInterface.translate(0, 1);
                    } else if (keyCode == keyEvent.VK_LEFT) {
                        graphicItemInterface.translate(-1, 0);
                    } else if (keyCode == keyEvent.VK_RIGHT) {
                        graphicItemInterface.translate(1, 0);
                    }
                }
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, this.gameInputStrings.KEY_PRESSED, e);
        }
        if (this.getSelectedTool() != null && this.getSelectedTool().isActive()) {
            StatusFactory.getInstance().setStatus("Key Pressed for Tool");
            GraphicItemInterface graphicItem = this.getSelectedTool();
            graphicItem.keyPressed(keyEvent);
        } else {
            this.setNewTool();
        }
        this.grid.isChanged = true;
        this.repaint();
    }

    public virtual void keyReleased(java.awt.event.KeyEvent keyEvent)
    {
    }

    public virtual void keyTyped(java.awt.event.KeyEvent keyEvent)
    {
    }

    public virtual void delete(MyGraphicItemEvent evt)
    {
        this.getGraphicItemHashMap().remove(evt.getTreeNode());
        this.workAreaJTreeJPanel.updateTree();
        this.workAreaJTreeJPanel.expand();
        this.workAreaJTreeJPanel.repaint();
    }

    public virtual void deselect(MyGraphicItemEvent evt)
    {
        GraphicItemInterface graphicItemInterface = ((GraphicItemInterface) this.getGraphicItemHashMap().get(evt.getTreeNode()));
        if (graphicItemInterface != null) {
            graphicItemInterface.setColor(Color.WHITE);
            graphicItemInterface.deactivate();
            this.workAreaJTreeJPanel.repaint();
        }
    }

    public virtual void highlight(MyGraphicItemEvent evt)
    {
        GraphicItemInterface graphicItemInterface = ((GraphicItemInterface) this.getGraphicItemHashMap().get(evt.getTreeNode()));
        if (graphicItemInterface != null) {
            graphicItemInterface.setColor(Color.YELLOW);
            graphicItemInterface.activate();
            this.workAreaJTreeJPanel.repaint();
        }
    }

    // throws Exception
    public virtual CanvasJPanel duplicate()
    {
        CanvasJPanel newCanvasJPanel = new CanvasJPanel(this.workAreaJTreeJPanel, this.getSize(), this.getCanvasDimension().getWidth(), this.getCanvasDimension().getHeight());
        newCanvasJPanel.setGrid(this.getGrid().getGrid());
        newCanvasJPanel.setAngle(this.getAngle());
        newCanvasJPanel.duplicateGraphicItemHashMap(this.getGraphicItemHashMap());
        this.workAreaJTreeJPanel.updateTree();
        this.workAreaJTreeJPanel.expand();
        this.workAreaJTreeJPanel.repaint();
        return newCanvasJPanel;
    }

    // throws Exception
    public virtual void duplicate(MyGraphicItemEvent @event)
    {
        MutableTreeNode treeNode = @event.getTreeNode();
        GraphicItemInterface graphicItem = ((GraphicItemInterface) this.getGraphicItemHashMap().get(treeNode));
        if (graphicItem != null) {
            this.duplicateGraphicItem(graphicItem);
            this.workAreaJTreeJPanel.updateTree();
            this.workAreaJTreeJPanel.expand();
            this.workAreaJTreeJPanel.repaint();
        }
    }

    public virtual void rotate(MyGraphicItemEvent @event)
    {
        MutableTreeNode treeNode = @event.getTreeNode();
        GraphicItemInterface graphicItem = ((GraphicItemInterface) this.getGraphicItemHashMap().get(treeNode));
        if (graphicItem != null) {
            graphicItem.addAngle(@event.getAngle());
        }
    }

    public virtual IntegerDimension getCanvasDimension()
    {
        return this.canvasDimension;
    }

    public virtual void setCanvasDimension(IntegerDimension canvasDimension)
    {
        this.canvasDimension = canvasDimension;
    }

    public virtual Grid getGrid()
    {
        return this.grid;
    }

}

