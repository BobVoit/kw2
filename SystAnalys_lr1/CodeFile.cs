using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystAnalys_lr1
{
    class Vertex
    {
        public int x { get; set; }
        public int y { get; set; }
        public bool isVertexConnection { get; set; }

        public Vertex(int x, int y, bool isVertexConnection = false)
        {
            this.x = x;
            this.y = y;
            this.isVertexConnection = isVertexConnection;
        }
    }

    class Edge
    {
        public int v1 { get; set; }
        public int v2 { get; set; }
        public bool allocate { get; set; }

        public Edge(int v1, int v2, bool allocate = false)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.allocate = allocate;
        }
    }



    class DrawGraph
    {
        Bitmap bitmap;
        Pen blackPen;
        Pen redPen;
        Pen darkGoldPen;
        Pen greenPen;
        Graphics gr;
        Font fo;
        Brush br;
        PointF point;
        public int R = 20; //радиус окружности вершины

        public DrawGraph(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            gr = Graphics.FromImage(bitmap);
            clearSheet();
            blackPen = new Pen(Color.Black);
            blackPen.Width = 2;
            redPen = new Pen(Color.Red);
            redPen.Width = 2;
            darkGoldPen = new Pen(Color.DarkGoldenrod);
            darkGoldPen.Width = 2;
            greenPen = new Pen(Color.Green);
            greenPen.Width = 2;
            fo = new Font("Arial", 15);
            br = Brushes.Black;
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public void clearSheet()
        {
            gr.Clear(Color.White);
        }

        public void drawVertex(int x, int y, string number, bool isVertexConnection = false)
        {
            Pen pen = isVertexConnection ? greenPen: blackPen;
            gr.FillEllipse(Brushes.White, (x - R), (y - R), 2 * R, 2 * R);
            gr.DrawEllipse(pen, (x - R), (y - R), 2 * R, 2 * R);
            point = new PointF(x - 9, y - 9);
            gr.DrawString(number, fo, br, point);
        }

        public void drawSelectedVertex(int x, int y)
        {
            gr.DrawEllipse(redPen, (x - R), (y - R), 2 * R, 2 * R);
        }

        public void drawEdge(Vertex V1, Vertex V2, Edge E, int numberE)
        {
            Pen pen = E.allocate ? greenPen : darkGoldPen;
            if (E.v1 == E.v2)
            {
                // ++
                // gr.DrawArc(darkGoldPen, (V1.x - 2 * R), (V1.y - 2 * R), 2 * R, 2 * R, 90, 270);
                gr.DrawArc(pen, (V1.x - 2 * R), (V1.y - 2 * R), 2 * R, 2 * R, 90, 270);
                // --
                point = new PointF(V1.x - (int)(2.75 * R), V1.y - (int)(2.75 * R));
                // gr.DrawString(((char)('a' + numberE)).ToString(), fo, br, point);
                // gr.DrawString(numberE.ToString(), fo, br, point);
                drawVertex(V1.x, V1.y, (E.v1 + 1).ToString(), V1.isVertexConnection);
                // drawVertex(V1.x, V1.y, ((char)('a' + E.v1)).ToString(), V1.isVertexConnection);
            }
            else
            {
                // ++
                // gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x, V2.y);
                gr.DrawLine(pen, V1.x, V1.y, V2.x, V2.y);
                // --
                point = new PointF((V1.x + V2.x) / 2, (V1.y + V2.y) / 2);
                // gr.DrawString(((char)('a' + numberE)).ToString(), fo, br, point);
               //  gr.DrawString(numberE.ToString(), fo, br, point);
                drawVertex(V1.x, V1.y, (E.v1 + 1).ToString(), V1.isVertexConnection);
                drawVertex(V2.x, V2.y, (E.v2 + 1).ToString(), V2.isVertexConnection);
                // drawVertex(V1.x, V1.y, ((char)('a' + E.v1)).ToString());
                // drawVertex(V2.x, V2.y, ((char)('a' + E.v2)).ToString());
            }
        }

        public void drawALLGraph(List<Vertex> V, List<Edge> E)
        {
            //рисуем ребра
            for (int i = 0; i < E.Count; i++)
            {
                Pen pen = E[i].allocate ? greenPen : darkGoldPen;
                if (E[i].v1 == E[i].v2)
                {
                    // ++
                    // gr.DrawArc(darkGoldPen, (V[E[i].v1].x - 2 * R), (V[E[i].v1].y - 2 * R), 2 * R, 2 * R, 90, 270);
                    gr.DrawArc(pen, (V[E[i].v1].x - 2 * R), (V[E[i].v1].y - 2 * R), 2 * R, 2 * R, 90, 270);
                    // --
                    point = new PointF(V[E[i].v1].x - (int)(2.75 * R), V[E[i].v1].y - (int)(2.75 * R));
                    // gr.DrawString(((char)('a' + i)).ToString(), fo, br, point);
                    // gr.DrawString(i.ToString(), fo, br, point);
                }
                else
                {
                    // ++
                    // gr.DrawLine(darkGoldPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x, V[E[i].v2].y);
                    gr.DrawLine(pen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x, V[E[i].v2].y);
                    // --
                    point = new PointF((V[E[i].v1].x + V[E[i].v2].x) / 2, (V[E[i].v1].y + V[E[i].v2].y) / 2);
                    // gr.DrawString(((char)('a' + i)).ToString(), fo, br, point);
                    // gr.DrawString(i.ToString(), fo, br, point);
                }
            }
            //рисуем вершины
            for (int i = 0; i < V.Count; i++)
            {
                drawVertex(V[i].x, V[i].y, (i + 1).ToString(), V[i].isVertexConnection);
                // drawVertex(V[i].x, V[i].y, ((char)('a' + i)).ToString());
            }
        }

        //заполняет матрицу смежности
        public void fillAdjacencyMatrix(int numberV, List<Edge> E, int[,] matrix)
        {
            for (int i = 0; i < numberV; i++)
                for (int j = 0; j < numberV; j++)
                    matrix[i, j] = 0;
            for (int i = 0; i < E.Count; i++)
            {
                matrix[E[i].v1, E[i].v2] = 1;
                matrix[E[i].v2, E[i].v1] = 1;
            }
        }

        //заполняет матрицу инцидентности
        public void fillIncidenceMatrix(int numberV, List<Edge> E, int[,] matrix)
        {
            for (int i = 0; i < numberV; i++)
                for (int j = 0; j < E.Count; j++)
                    matrix[i, j] = 0;
            for (int i = 0; i < E.Count; i++)
            {
                matrix[E[i].v1, i] = 1;
                matrix[E[i].v2, i] = 1;
            }
        }

        
    }

    class GraphVE
    {
        public List<Edge> edges { get; set; }
        public List<Vertex> vertex { get; set; }

        public GraphVE(List<Vertex> vertex, List<Edge> edges)
        {
            this.vertex = vertex;
            this.edges = edges;
        }
    }

    class VertexVC
    {
        public Vertex vertex;
        public int index;
        public bool visited;
        public int dis;
        public int low;
        public int par;
        public bool ap;

        public VertexVC(Vertex vertex, int index, bool visited = false, int dis = 0, int low = 0, int par = 0, bool ap = false)
        {
            this.vertex = vertex;
            this.index = index; 
            this.visited = visited;
            this.dis = dis; 
            this.low = low;
            this.par = par;
            this.ap = ap;
        }
    }

}