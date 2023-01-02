using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace SystAnalys_lr1
{
    public partial class Form1 : Form
    {
        DrawGraph G;
        List<Vertex> V;
        List<Edge> E;
        int[,] AMatrix; //матрица смежности
        int[,] IMatrix; //матрица инцидентности

        int selected1; //выбранные вершины, для соединения линиями
        int selected2;

        public bool closeApp;
        public bool back;

        public Form1()
        {
            InitializeComponent();
            V = new List<Vertex>();
            G = new DrawGraph(sheet.Width, sheet.Height);
            E = new List<Edge>();
            sheet.Image = G.GetBitmap();
            this.closeApp = true;
        }

        public Form1(string json, string filename)
        {
            InitializeComponent();

            GraphVE graphVE = JsonSerializer.Deserialize<GraphVE>(json);

            this.filePath.Text = filename;
            V = graphVE.vertex;
            G = new DrawGraph(sheet.Width, sheet.Height);
            E = graphVE.edges;
            G.drawALLGraph(V, E);
            vertexСonnectivity_Click(null, null);
            sheet.Image = G.GetBitmap();
            this.filePath.Text = filename;
            this.closeApp = true;
        }

        //кнопка - выбрать вершину
        private void selectButton_Click(object sender, EventArgs e)
        {
            // selectButton.Enabled = false;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            // clearEdgesAllocate();
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
            selected1 = -1;
        }

        //кнопка - рисовать вершину
        private void drawVertexButton_Click(object sender, EventArgs e)
        {
            drawVertexButton.Enabled = false;
            // selectButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            // clearEdgesAllocate();
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }

        //кнопка - рисовать ребро
        private void drawEdgeButton_Click(object sender, EventArgs e)
        {
            drawEdgeButton.Enabled = false;
            // selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            deleteButton.Enabled = true;
            // clearEdgesAllocate();
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
            selected1 = -1;
            selected2 = -1;
        }

        //кнопка - удалить элемент
        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;
            // selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }

        //кнопка - удалить граф
        private void deleteALLButton_Click(object sender, EventArgs e)
        {
            // selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            const string message = "Вы действительно хотите полностью удалить граф?";
            const string caption = "Удаление";
            var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MBSave == DialogResult.Yes)
            {
                V.Clear();
                E.Clear();
                G.clearSheet();
                sheet.Image = G.GetBitmap();
                listBoxMatrix.Items.Clear();
            }
        }

        //кнопка - матрица смежности
        private void buttonAdj_Click(object sender, EventArgs e)
        {
            createAdjAndOut();
        }

        //кнопка - матрица инцидентности 
        private void buttonInc_Click(object sender, EventArgs e)
        {
            createIncAndOut();
        }

        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {

            //нажата кнопка "рисовать вершину"
            if (drawVertexButton.Enabled == false)
            {
                Vertex newVertex = new Vertex(e.X, e.Y);
                bool res = true;
                foreach (Vertex vertex in V)
                {
                    if (findDistance(newVertex, vertex) < (G.R * 1.5 + G.R))
                    {
                        res = false; 
                        break;
                    }
                }

                if (res)
                {
                    V.Add(newVertex);
                    clearIsVertexConnection();
                    listBoxMatrix.Items.Clear();
                    G.drawVertex(e.X, e.Y, V.Count.ToString());
                    sheet.Image = G.GetBitmap();
                }
                else
                {
                    if (listBoxMatrix.Items.Count > 0 && listBoxMatrix.ForeColor != Color.Red)
                        listBoxMatrix.Items.Clear(); 
                    listBoxMatrix.Items.Add("Вершина находится близко!");
                    listBoxMatrix.ForeColor = Color.Red;
                }
            }
            //нажата кнопка "рисовать ребро"
            if (drawEdgeButton.Enabled == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < V.Count; i++)
                    {
                        if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                        {
                            if (selected1 == -1)
                            {
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected1 = i;
                                sheet.Image = G.GetBitmap();
                                break;
                            }
                            if (selected2 == -1)
                            {
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected2 = i;
                                E.Add(new Edge(selected1, selected2));
                                clearIsVertexConnection();
                                listBoxMatrix.Items.Clear();
                                G.drawEdge(V[selected1], V[selected2], E[E.Count - 1], E.Count - 1);
                                selected1 = -1;
                                selected2 = -1;
                                sheet.Image = G.GetBitmap();
                                break;
                            }
                        }
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    if ((selected1 != -1) &&
                        (Math.Pow((V[selected1].x - e.X), 2) + Math.Pow((V[selected1].y - e.Y), 2) <= G.R * G.R))
                    {
                        G.drawVertex(V[selected1].x, V[selected1].y, (selected1 + 1).ToString());
                        selected1 = -1;
                        sheet.Image = G.GetBitmap();
                    }
                }
            }
            //нажата кнопка "удалить элемент"
            if (deleteButton.Enabled == false)
            {
                bool flag = false; //удалили ли что-нибудь по ЭТОМУ клику
                //ищем, возможно была нажата вершина
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                    {
                        for (int j = 0; j < E.Count; j++)
                        {
                            if ((E[j].v1 == i) || (E[j].v2 == i))
                            {
                                E.RemoveAt(j);
                                j--;
                            }
                            else
                            {
                                if (E[j].v1 > i) E[j].v1--;
                                if (E[j].v2 > i) E[j].v2--;
                            }
                        }
                        V.RemoveAt(i);
                        clearIsVertexConnection();
                        listBoxMatrix.Items.Clear();
                        flag = true;
                        break;
                    }
                }
                //ищем, возможно было нажато ребро
                if (!flag)
                {
                    for (int i = 0; i < E.Count; i++)
                    {
                        if (E[i].v1 == E[i].v2) //если это петля
                        {
                            if ((Math.Pow((V[E[i].v1].x - G.R - e.X), 2) + Math.Pow((V[E[i].v1].y - G.R - e.Y), 2) <= ((G.R + 2) * (G.R + 2))) &&
                                (Math.Pow((V[E[i].v1].x - G.R - e.X), 2) + Math.Pow((V[E[i].v1].y - G.R - e.Y), 2) >= ((G.R - 2) * (G.R - 2))))
                            {
                                E.RemoveAt(i);
                                clearIsVertexConnection();
                                listBoxMatrix.Items.Clear();
                                flag = true;
                                break;
                            }
                        }
                        else //не петля
                        {
                            if (((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) <= (e.Y + 4) &&
                                ((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) >= (e.Y - 4))
                            {
                                if ((V[E[i].v1].x <= V[E[i].v2].x && V[E[i].v1].x <= e.X && e.X <= V[E[i].v2].x) ||
                                    (V[E[i].v1].x >= V[E[i].v2].x && V[E[i].v1].x >= e.X && e.X >= V[E[i].v2].x))
                                {
                                    E.RemoveAt(i);
                                    clearIsVertexConnection();
                                    listBoxMatrix.Items.Clear();
                                    flag = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                //если что-то было удалено, то обновляем граф на экране
                if (flag)
                {
                    G.clearSheet();
                    G.drawALLGraph(V, E);
                    sheet.Image = G.GetBitmap();
                }
            }
        }

        //создание матрицы смежности и вывод в листбокс
        private void createAdjAndOut()
        {
            AMatrix = new int[V.Count, V.Count];
            G.fillAdjacencyMatrix(V.Count, E, AMatrix);
            listBoxMatrix.Items.Clear();
            string sOut = "    ";
            for (int i = 0; i < V.Count; i++)
                sOut += (i + 1) + " ";
            listBoxMatrix.Items.Add(sOut);
            for (int i = 0; i < V.Count; i++)
            {
                sOut = (i + 1) + " | ";
                for (int j = 0; j < V.Count; j++)
                    sOut += AMatrix[i, j] + " ";
                listBoxMatrix.Items.Add(sOut);
            }
        }

        //создание матрицы инцидентности и вывод в листбокс
        private void createIncAndOut()
        {
            if (E.Count > 0)
            {
                IMatrix = new int[V.Count, E.Count];
                G.fillIncidenceMatrix(V.Count, E, IMatrix);
                listBoxMatrix.Items.Clear();
                string sOut = "    ";
                for (int i = 0; i < E.Count; i++)
                    sOut += (char)('a' + i) + " ";
                listBoxMatrix.Items.Add(sOut);
                for (int i = 0; i < V.Count; i++)
                {
                    sOut = (i + 1) + " | ";
                    for (int j = 0; j < E.Count; j++)
                        sOut += IMatrix[i, j] + " ";
                    listBoxMatrix.Items.Add(sOut);
                }
            }
            else
                listBoxMatrix.Items.Clear();
        }

        // ++
        private void vertexСonnectivity_Click(object sender, EventArgs e)
        {
            if (V.Count == 0)
            {
                MessageBox.Show("Введите вершину!");
                return;
            }

            listBoxMatrix.Items.Clear();
            listBoxMatrix.ForeColor = Color.Black;

            List<VertexVC> listVertex = vertexConnectivity();

            listBoxMatrix.Items.Add("Вершинная связность = " + listVertex.Count);
            listBoxMatrix.Items.Add("Точки сочленения:");
            foreach (VertexVC vertex in listVertex)
            {
                listBoxMatrix.Items.Add((vertex.index + 1).ToString());
            }

            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }

        private void clearIsVertexConnection()
        {
            foreach (Vertex vertex in V)
            {
                vertex.isVertexConnection = false;
            }

            G.clearSheet();
            G.drawALLGraph(V, E);
        }

        private double findDistance(Vertex v1, Vertex v2)
        {
            return Math.Sqrt((v2.x - v1.x) * (v2.x - v1.x) + (v2.y - v1.y) * (v2.y - v1.y));
        }



        private List<VertexVC> vertexConnectivity()
        {
            int countVertex = V.Count;

            List<VertexVC> listVC = new List<VertexVC>();

            for (int i = 0; i < countVertex; i++)
            {
                listVC.Add(new VertexVC(V[i], i, false, 0, 0, countVertex, false));
            }

            foreach (VertexVC current in listVC) 
            {
                if (!current.visited)
                {
                    apt(current.index, listVC);
                }
            }

            List<VertexVC> apoints = new List<VertexVC>();
            foreach (VertexVC current in listVC)
            {
                if (current.ap)
                {
                    current.vertex.isVertexConnection = true;
                    apoints.Add(current);
                }
            }

            return apoints;
        }

        private void apt(int currentIndex, List<VertexVC> listVC, int t = 0)
        {
            int child = 0;
            listVC[currentIndex].visited = true;
            t++;
            listVC[currentIndex].dis = t;
            listVC[currentIndex].low = t;

            List<VertexVC> relatedVertex = findRelatedVertex(currentIndex, listVC);

            foreach (VertexVC element in relatedVertex)
            {
                if (!element.visited)
                {
                    child++;
                    element.par = currentIndex;
                    apt(element.index, listVC, t);
                    listVC[currentIndex].low = Math.Min(listVC[currentIndex].low, listVC[element.index].low);

                    if (listVC[currentIndex].par == V.Count && child > 1)
                        listVC[currentIndex].ap = true;
                    if (listVC[currentIndex].par != V.Count && listVC[element.index].low >= listVC[currentIndex].dis)
                        listVC[currentIndex].ap = true;
                }
                else if ((element.index != listVC[currentIndex].par))
                {
                    listVC[currentIndex].low = Math.Min(listVC[currentIndex].low, listVC[element.index].dis);
                }
            }

        }

        private List<VertexVC> findRelatedVertex(int index, List<VertexVC> listVC)
        {
            List<VertexVC> result = new List<VertexVC>();
            foreach (Edge edge in E)
            {
                if (edge.v1 == index)
                {
                    result.Add(listVC[edge.v2]);
                } 
                else if (edge.v2 == index)
                {
                    result.Add(listVC[edge.v1]);
                }
            }
            return result;
        }

        // --


        //О программе
        private void about_Click(object sender, EventArgs e)
        {
            aboutForm FormAbout = new aboutForm();
            FormAbout.ShowDialog();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (sheet.Image != null)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить проект как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Json files(*.json)|*.json";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    string fileNameForSave = savedialog.FileName;
                    bool isJSON = fileNameForSave.Contains(".json");   

                    if (isJSON)
                    {
                        try
                        {
                            GraphVE graphVE = new GraphVE(V, E);
                            string json = JsonSerializer.Serialize<GraphVE>(graphVE);
                            File.WriteAllText(savedialog.FileName, json);
                            this.filePath.Text = savedialog.FileName;
                            MessageBox.Show("Проект сохранен!");
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка при сохранении файла JSON", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }   
                    else
                    {
                        try
                        {
                            sheet.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        catch
                        {
                            MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Проект не сохранен!");
                }
            }
        }

        private void saveInCurrent_Click(object sender, EventArgs e)
        {
            if (sheet.Image != null)
            {
                if (filePath.Text == "")
                {
                    SaveFileDialog savedialog = new SaveFileDialog();
                    savedialog.Title = "Сохранить картинку как...";
                    savedialog.OverwritePrompt = true;
                    savedialog.CheckPathExists = true;
                    // savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                    savedialog.Filter = "Json files(*.json)|*.json";
                    savedialog.ShowHelp = true;
                    if (savedialog.ShowDialog() == DialogResult.OK)
                    {
                        string fileNameForSave = savedialog.FileName;
                        bool isJSON = fileNameForSave.Contains(".json");

                        if (isJSON)
                        {
                            try
                            {
                                GraphVE graphVE = new GraphVE(V, E);
                                string json = JsonSerializer.Serialize<GraphVE>(graphVE);
                                File.WriteAllText(fileNameForSave, json);
                                filePath.Text = fileNameForSave;
                                MessageBox.Show("Проект сохранен!");
                            }
                            catch
                            {
                                MessageBox.Show("Ошибка при сохранении файла JSON", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            try
                            {
                                sheet.Image.Save(fileNameForSave, System.Drawing.Imaging.ImageFormat.Jpeg);
                            }
                            catch
                            {
                                MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Проект не сохранен!");
                    }
                }
                else
                {
                    try
                    {
                        GraphVE graphVE = new GraphVE(V, E);
                        string json = JsonSerializer.Serialize<GraphVE>(graphVE);
                        File.WriteAllText(filePath.Text, json);
                        MessageBox.Show("Проект сохранен!");
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка при сохранении файла JSON", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.back)
                return;

            DialogResult res = (new CloseForm()).ShowDialog();

            if (res == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else if (res == DialogResult.OK)
            {
                this.closeApp = true;
            }
            else if (res == DialogResult.No) 
            {
                this.closeApp = false;
            }
           
        }
        private void backInMainMenu_Click(object sender, EventArgs e)
        {
            this.back = true;
            this.closeApp = false;
            this.Close();
        }
    }
}
