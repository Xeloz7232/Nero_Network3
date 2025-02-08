using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nero_Network3
{
    public partial class Form1 : Form
    {
        #region Данные
        public static string weightsPath = "Weights";
        public static float startAlpha;
        public static bool isTeachTestFlag = false;
        public static string[] neuronNames = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public static int neuronSize = neuronNames.Length;
        public Neuron[] neuron = new Neuron[neuronSize];
        public int lastX, lastY;
        public const int N = 10000;
        public static int sampleSize = 30;
        public static int[][] sampleNormal = new int[neuronSize * sampleSize][];
        public static int[][] sampleCenter = sampleNormal;
        public static int[][] sampleScale = sampleNormal;
        public static int testSize = 10;
        public static int[][] testNormal = new int[neuronSize * testSize][];
        public static int[][] testCenter = testNormal;
        public static int[][] testScale = testNormal;
        public static Random random = new Random();
        #endregion

        public Form1()
        {
            InitializeComponent();
            lGuess.Text = "";
            for (int i = 0; i < neuronSize; i++)
            {
                neuron[i] = new Neuron(N, i);
                neuron[i].LoadWeight();
            }
            if (File.Exists($"{weightsPath}/time.txt"))
            {
                StreamReader load = new StreamReader($"{weightsPath}/time.txt");
                int time = Convert.ToInt32(load.ReadLine());
                int epoch = Convert.ToInt32(load.ReadLine());
                lEpoch.Text = $"Эпохи = {epoch} ({string.Format("{0:0.000}", time / 1000f)} сек)";
                load.Close();
            }
            #region Загрузка изображений
            for (int n = 0; n < neuronSize; n++)
            {
                for (int j = 0; j < sampleSize; j++)
                {
                    sampleNormal[j + n * sampleSize] = new int[N];
                    sampleCenter[j + n * sampleSize] = new int[N];
                    sampleScale[j + n * sampleSize] = new int[N];
                    Bitmap bm;
                    bm = (Bitmap)Image.FromFile($"Sample/{neuronNames[n]}-{j}.bmp");
                    for (int k = 0; k < N; k++)
                    {
                        sampleNormal[j + n * sampleSize][k] = bm.GetPixel(k % 100, k / 100) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                    }
                    bm = Centering(bm);
                    for (int k = 0; k < N; k++)
                    {
                        sampleCenter[j + n * sampleSize][k] = bm.GetPixel(k % 100, k / 100) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                    }
                    bm = Scaling(bm);
                    for (int k = 0; k < N; k++)
                    {
                        sampleScale[j + n * sampleSize][k] = bm.GetPixel(k % 100, k / 100) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                    }
                }
                for (int j = 0; j < testSize; j++)
                {
                    testNormal[j + n * testSize] = new int[N];
                    testCenter[j + n * testSize] = new int[N];
                    testScale[j + n * testSize] = new int[N];
                    Bitmap bm;
                    bm = (Bitmap)Image.FromFile($"Test/{neuronNames[n]}-{j}.bmp");
                    for (int k = 0; k < N; k++)
                    {
                        testScale[j + n * testSize][k] = bm.GetPixel(k % 100, k / 100) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                    }
                    bm = Centering(bm);
                    for (int k = 0; k < N; k++)
                    {
                        testScale[j + n * testSize][k] = bm.GetPixel(k % 100, k / 100) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                    }
                    bm = Scaling(bm);
                    for (int k = 0; k < N; k++)
                    {
                        testScale[j + n * testSize][k] = bm.GetPixel(k % 100, k / 100) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                    }
                }
            }
            #endregion

            Clear();
            ShowWeightMap();
        }

        #region Карта весов
        public float function(float x, float a, float b)
        {
            float y;
            if (x <= a)
                y = 0;
            else if (x > a && x < b)
                y = (x - a) / (b - a);
            else y = 1;
            return y;
        }
        public void ShowWeightMap()
        {
            PictureBox[] pbs = new PictureBox[] { pbWM1, pbWM2, pbWM3, pbWM4, pbWM5, pbWM6, pbWM7, pbWM8, pbWM9, pbWM10};
            float temp;
            for (int j = 0; j < neuronSize; j++)
            {
                Bitmap bm = new Bitmap(100, 100);
                for (int i = 0; i < N; i++)
                {
                    temp = 1 - function(neuron[j].weight[i], 0f, 1f);
                    bm.SetPixel(i % 100, i / 100, Color.FromArgb(255, (int)(255 * temp), (int)(255 * temp), (int)(255 * temp)));
                }
                pbs[j].Image = bm;
            }
        }
        #endregion

        #region Масштабирование/Центрирование
        public Bitmap Scaling(Bitmap bm)
        {
            int height, width;
            int minX = 100, maxX = 0, minY = 100, maxY = 0;
            int[] imageArray = new int[10000];
            for (int i = 0; i < N; i++)
            {
                int curX = i % 100;
                int curY = i / 100;
                imageArray[i] = bm.GetPixel(curX, curY) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                if (imageArray[i] == 1)
                {
                    if (curX > maxX) maxX = curX;
                    if (curX < minX) minX = curX;
                    if (curY > maxY) maxY = curY;
                    if (curY < minY) minY = curY;
                }
            }
            width = maxX - minX + 1;
            height = maxY - minY + 1;

            if (!(width < 0 || height < 0))
            {
                Bitmap bmp = new Bitmap(width, height);
                for (int y = 0; y < height; y++)
                {
                    for (int InputVector = 0; InputVector < width; InputVector++)
                    {
                        int index = (y + minY) * 100 + (InputVector + minX);
                        if (imageArray[index] == 1)
                            bmp.SetPixel(InputVector, y, Color.FromArgb(255, 0, 0, 0));
                        else
                            bmp.SetPixel(InputVector, y, Color.FromArgb(0, 0, 0, 0));
                    }
                }
                Bitmap centeredBmp = new Bitmap(100, 100);
                Graphics g = Graphics.FromImage(centeredBmp);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.Clear(Color.FromArgb(0, 0, 0, 0));
                g.DrawImage(bmp, 0, 0, 100, 100);
                return Centering(centeredBmp);
            }
            return bm;
        }

        public Bitmap Centering(Bitmap bm)
        {
            int height, width;
            int minX = 100, maxX = 0, minY = 100, maxY = 0;
            int[] imageArray = new int[10000];
            for (int i = 0; i < N; i++)
            {
                int curX = i % 100;
                int curY = i / 100;
                imageArray[i] = bm.GetPixel(curX, curY) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                if (imageArray[i] == 1)
                {
                    if (curX > maxX) maxX = curX;
                    if (curX < minX) minX = curX;
                    if (curY > maxY) maxY = curY;
                    if (curY < minY) minY = curY;
                }
            }
            width = maxX - minX + 1;
            height = maxY - minY + 1;

            int offsetX = (100 - width) / 2;
            int offsetY = (100 - height) / 2;
            if (!(width < 0 || height < 0))
            {
                Bitmap bmp = new Bitmap(width, height);
                for (int y = 0; y < height; y++)
                {
                    for (int InputVector = 0; InputVector < width; InputVector++)
                    {
                        int index = (y + minY) * 100 + (InputVector + minX);
                        if (imageArray[index] == 1)
                            bmp.SetPixel(InputVector, y, Color.FromArgb(255, 0, 0, 0));
                        else
                            bmp.SetPixel(InputVector, y, Color.FromArgb(0, 0, 0, 0));
                    }
                }
                Bitmap centeredBmp = new Bitmap(100, 100);
                Graphics g = Graphics.FromImage(centeredBmp);
                g.Clear(Color.FromArgb(0, 0, 0, 0));
                g.DrawImage(bmp, offsetX, offsetY);
                return centeredBmp;
            }
            return bm;
        }
        #endregion

        #region Обучение и тест
        private void Teach()
        {
            #region Данные
            int[][] sample = rbCenter.Checked ? sampleCenter : rbScale.Checked ? sampleScale : sampleNormal;
            float alpha = (float)nudAlpha.Value;
            startAlpha = alpha;
            float dMax = 0;
            float dTemp;
            int epoch = 0;
            float weightsChange;
            Stopwatch stopWatch = new Stopwatch();
            if (!Directory.Exists($"Results/Aльфа {startAlpha}"))
            { Directory.CreateDirectory($"Results/Aльфа {startAlpha}"); }
            DirectoryInfo epochDirInfo = new DirectoryInfo($"Results/Aльфа {startAlpha}");
            foreach (FileInfo file in epochDirInfo.GetFiles())
            { file.Delete(); }
            #endregion
            stopWatch.Start();
            for (int i = 0; i < neuronSize; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    neuron[i].weight[j] = random.Next(-300, 300) / 1000f;
                }
            }
            for (int i = 0; i < neuronSize; i++)
            {
                for (int j = 0; j < neuronSize; j++)
                {
                    dTemp = Distance(neuron[i].weight, neuron[j].weight);
                    if (dTemp > dMax) dMax = dTemp;
                }
            }
            float startD = dMax;
            do
            {
                epoch++;
                weightsChange = 0;
                StreamWriter epochs = new StreamWriter($"Results/Aльфа {startAlpha}/Эпоха({epoch}).txt");
                Stopwatch epochWatch = new Stopwatch();
                epochWatch.Start();
                int[] counter = new int[sample.GetLength(0)];
                for (int i = 0; i < sample.GetLength(0); i++)
                {
                    counter[i] = i;
                }
                do
                {
                    int g = random.Next(0, counter.Length);
                    int minIndex = 0;

                    for (int i = 0; i < neuronSize; i++)
                    {
                        neuron[i]._distance = Distance(sample[counter[g]], neuron[i].weight);
                        if (neuron[i]._distance < neuron[minIndex]._distance) minIndex = i;
                    }
                    neuron[minIndex].symbolID = counter[g] / sampleSize;
                    weightsChange += neuron[minIndex].ChangeWeights(sample[counter[g]], alpha);
                    for (int i = 0; i < neuronSize; i++)
                    {
                        if (i != minIndex)
                        {
                            dTemp = Distance(neuron[minIndex].weight, neuron[i].weight);
                            if (dTemp < dMax)
                            {
                                weightsChange += neuron[i].ChangeWeights(sample[counter[g]], alpha);
                            }
                        }
                    }

                    for (int i = g; i < counter.Length - 1; i++)
                    {
                        counter[i] = counter[i + 1];
                    }
                    Array.Resize(ref counter, counter.Length - 1);
                } while (counter.Length > 0);
                epochWatch.Stop();
                epochs.WriteLine($"Эпоха: {epoch}");
                epochs.WriteLine($"Изменение весов: {weightsChange}");
                epochs.WriteLine($"Альфа: {alpha}");
                epochs.WriteLine($"Максимальная дистанция: {dMax}");
                epochs.WriteLine($"Время: {epochWatch.ElapsedMilliseconds / 1000f}");
                epochs.Close();
                alpha *= 0.9f;
                dMax *= 0.9f;
            } while (weightsChange >= 50 & epoch < 300);
            stopWatch.Stop();
            DirectoryInfo dirInfo = new DirectoryInfo($"Weights");
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }
            if (!Directory.Exists($"Results/Aльфа {startAlpha}/Weights"))
            { Directory.CreateDirectory($"Results/Aльфа {startAlpha}/Weights"); }
            DirectoryInfo weightDirInfo = new DirectoryInfo($"Results/Aльфа {startAlpha}/Weights");
            foreach (FileInfo file in weightDirInfo.GetFiles())
            { file.Delete(); }
            for (int i = 0; i < neuronSize; i++)
            {
                neuron[i].SaveWeight();
            }
            StreamWriter results = new StreamWriter($"Results/Aльфа {startAlpha}/_Результаты.txt");
            results.WriteLine($"Альфа: {startAlpha}\n" +
                $"Начальная дистанция: {startD}\n" +
                $"Время: {stopWatch.ElapsedMilliseconds / 1000f}\n" +
                $"Эпохи: {epoch}");
            results.Close();
            StreamWriter time = new StreamWriter($"Weights/time.txt");
            time.WriteLine(stopWatch.ElapsedMilliseconds);
            time.WriteLine(epoch);
            time.WriteLine(startAlpha);
            time.Close();
            StreamWriter timeBackup = new StreamWriter($"Results/Aльфа {startAlpha}/Weights/time.txt");
            timeBackup.WriteLine(stopWatch.ElapsedMilliseconds);
            timeBackup.WriteLine(epoch);
            timeBackup.WriteLine(startAlpha);
            timeBackup.Close();
            if (!isTeachTestFlag)
            {
                SystemSounds.Asterisk.Play();
                MessageBox.Show("Обучение завершено!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                BringToFront();
                Activate();
            }
        }
        private void Test()
        {
            logs.Items.Clear();
            float wrong = 0; float right = 0;
            int[][] _test = rbCenter.Checked ? testCenter : rbScale.Checked ? testScale : testNormal;
            for (int i = 0; i < _test.GetLength(0); i++)
            {
                int minIndex = 0;
                bool guess = true;
                for (int j = 0; j < neuronSize; j++)
                {
                    if (Distance(_test[i], neuron[j].weight) < Distance(_test[i], neuron[minIndex].weight)) minIndex = j;
                }
                if (neuron[minIndex].symbolID != i / testSize)
                {
                    wrong++;
                    guess = false;
                }
                else right++;
                if (!guess) logs.Items.Add($"Ошибка на: {neuronNames[i / testSize]}-{i % testSize} Выдал-{neuron[minIndex].symbolID}");
            }
            lRight.Text = $"Угадал = {Math.Round(right / (right + wrong) * 100f, 2)}% ({right}/{wrong + right})";
            if (isTeachTestFlag)
            {
                StreamWriter results = File.AppendText($"Results/Aльфа {startAlpha}/_Результаты.txt");
                results.WriteLine($"Процент угадываний: {Math.Round(right / (right + wrong) * 100f, 2)}% ({right}/{wrong + right})");
                results.Close();
            }
        }
        private void bStartTesting_Click(object sender, EventArgs e)
        {
            Test();
        }
        private void bTeachTest_Click(object sender, EventArgs e)
        {
            isTeachTestFlag = true;
            Teach();
            Test();
            isTeachTestFlag = false;
        }
        #endregion
        private float Distance(float[] w1, float[] w2)
        {
            float dist = 0f;
            for (int i = 0; i < w1.Length; i++)
            {
                dist += (float)Math.Pow(w1[i] - w2[i], 2);
            }
            return dist;
        }
        private float Distance(int[] x, float[] w)
        {
            float dist = 0f;
            for (int i = 0; i < x.Length; i++)
            {
                dist += (float)Math.Pow(x[i] - w[i], 2);
            }
            return dist;
        }
        private void bMegaTraining_Click(object sender, EventArgs e)
        {
            nudAlpha.Value = 0.9m;
            bTeachTest_Click(sender, e);
            nudAlpha.Value = 0.8m;
            bTeachTest_Click(sender, e);
            nudAlpha.Value = 0.7m;
            bTeachTest_Click(sender, e);
            nudAlpha.Value = 0.6m;
            bTeachTest_Click(sender, e);
            nudAlpha.Value = 0.5m;
            bTeachTest_Click(sender, e);
            nudAlpha.Value = 0.4m;
            bTeachTest_Click(sender, e);
            SystemSounds.Asterisk.Play();
            MessageBox.Show("Обучение завершено!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            BringToFront();
            Activate();
        }

        #region Рисовалка
        private void bGive_Click(object sender, EventArgs e)
        {
            int[][] sample = rbCenter.Checked ? sampleCenter : rbScale.Checked ? sampleScale : sampleNormal;
            if (rbCenter.Checked) pbMain.Image = Centering((Bitmap)pbMain.Image);
            else if (rbScale.Checked) pbMain.Image = Scaling((Bitmap)pbMain.Image);
            Bitmap bm = (Bitmap)pbMain.Image;
            int minIndex = 0; int summ = 0;
            int[] X = new int[N];
            for (int i = 0; i < N; i++)
            {
                X[i] = bm.GetPixel(i % 100, i / 100) == Color.FromArgb(255, 0, 0, 0) ? 1 : 0;
                summ += X[i];
            }
            if (summ != 10000)
            {
                for (int j = 0; j < neuronSize; j++)
                {
                    if (Distance(X, neuron[j].weight) < Distance(X, neuron[minIndex].weight)) minIndex = j;
                }
            }
            lGuess.Text = $"{neuron[minIndex].symbolID}";
        }
        private void bResultsFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string resultFolderPath = Path.Combine(projectDirectory, "Results");
                Process.Start("explorer.exe", resultFolderPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось открыть папку: " + ex.Message);
            }
        }
        private void pbMain_MouseMove(object sender, MouseEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            int X = e.X;
            int Y = e.Y;
            Graphics g = Graphics.FromImage(pbMain.Image);
            if (e.Button == MouseButtons.Left)
            {
                g.DrawLine(blackPen, lastX, lastY, X, Y);
            }
            blackPen.Dispose();
            g.Dispose();
            pbMain.Invalidate();
            lastX = X;
            lastY = Y;
        }
        private void Clear()
        {
            pbMain.Image = new Bitmap(100, 100);
            Graphics g = Graphics.FromImage(pbMain.Image);
            g.Clear(Color.FromArgb(255, 255, 255, 255));
            lGuess.Text = string.Empty;
        }

        private void bChooseWeights_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                folderDialog.SelectedPath = Path.Combine(projectPath, "Results");

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    weightsPath = folderDialog.SelectedPath + "/Weights";
                    //MessageBox.Show("Вы выбрали папку: " + selectedPath);
                    lGuess.Text = "";
                    for (int i = 0; i < neuronSize; i++)
                    {
                        neuron[i].LoadWeight();
                    }
                    if (File.Exists($"{weightsPath}/time.txt"))
                    {
                        StreamReader load = new StreamReader($"{weightsPath}/time.txt");
                        int time = Convert.ToInt32(load.ReadLine());
                        int epoch = Convert.ToInt32(load.ReadLine());
                        lEpoch.Text = $"Эпохи = {epoch} ({string.Format("{0:0.000}", time / 1000f)} сек)";
                        load.Close();
                    }
                    Clear();
                    ShowWeightMap();
                }
            }
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #endregion
    }
}
