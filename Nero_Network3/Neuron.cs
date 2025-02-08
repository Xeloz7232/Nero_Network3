using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nero_Network3
{
    public class Neuron
    {
        public float[] weight;
        public int index;
        public float _distance;
        public int symbolID;
        public Neuron(int N, int i)
        {
            weight = new float[N];
            index = i;
        }
        public float ChangeWeights(int[] x, float alpha)
        {
            float tempW = 0;
            for (int i = 0; i < x.Length; i++)
            {
                tempW += Math.Abs(alpha * (x[i] - weight[i]));
                weight[i] += alpha * (x[i] - weight[i]);
            }
            return tempW;
        }
        public void SaveWeight()
        {
            StreamWriter save = new StreamWriter($"Weights/Weight-{index}.txt");
            StreamWriter saveBackup = new StreamWriter($"Results/Aльфа {Form1.startAlpha}/Weights/Weight-{index}.txt");
            for (int i = 0; i < weight.Length; i++)
            {
                save.WriteLine(weight[i]);
                saveBackup.WriteLine(weight[i]);
            }
            save.WriteLine(symbolID);
            save.Close();
            saveBackup.WriteLine(symbolID);
            saveBackup.Close();
        }
        public void LoadWeight()
        {
            if (File.Exists($"{Form1.weightsPath}/Weight-{index}.txt"))
            {
                StreamReader load = new StreamReader($"{Form1.weightsPath}/Weight-{index}.txt");
                for (int i = 0; i < weight.Length; i++)
                {
                    weight[i] = Convert.ToSingle(load.ReadLine());
                }
                symbolID = Convert.ToInt32(load.ReadLine());
                load.Close();
            }
        }
    }
}
