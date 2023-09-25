namespace Lab_2._2
{
    using System.IO;
    class Ar
    {
        private int n;
        private int[] a;
        private int k;

        public int N
        {
            get { return n; }
        }

        public int K
        {
            get { return k; }
        }

        public Ar(int n)
        {
            this.n = n;
            a = new int[n];
            Random rand = new Random();
            k = 0;

            for (int i = 0; i < n; i++)
            {
                a[i] = rand.Next(-9, 10); 
                if (a[i] > 0)
                    k++;
            }
        }

        public Ar(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                n = File.ReadAllLines(fileName).Length;
                a = new int[n];
                k = 0;

                for (int i = 0; i < n; i++)
                {
                    int num = int.Parse(sr.ReadLine());
                    a[i] = num;
                    if (num > 0)
                        k++;
                }
            }
        }

        public void Print()
        {
            foreach (int num in a)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        public int P()
        {
            for (int i = 0; i < n; i++)
            {
                if (a[i] % 3 == 0)
                    return i;
            }
            return -1;
        }

        public int Sum(int i1, int i2)
        {
            int sum = 0;
            for (int i = i1; i <= i2; i++)
            {
                sum += a[i];
            }
            return sum;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введiть номер конструктора (1 або 2): ");
            int constructorChoice = int.Parse(Console.ReadLine());

            Ar arr;

            if (constructorChoice == 1)
            {
                Console.Write("Введiть кiлькiсть елементiв в масивi: ");
                int n = int.Parse(Console.ReadLine());
                arr = new Ar(n);
            }
            else if (constructorChoice == 2)
            {
                Console.Write("Введiть iм'я текстового файлу: "); // mn.txt
                string fileName = Console.ReadLine();
                arr = new Ar(fileName);
            }
            else
            {
                Console.WriteLine("Невiрний номер конструктора.");
                return;
            }

            Console.WriteLine("Масив:");
            arr.Print();

            Console.WriteLine($"Кiлькiсть позитивних елементiв в масивi: {arr.K}");

            int index = arr.P();
            if (index != -1)
            {
                Console.WriteLine($"Iндекс першого кратного 3 елемента: {index}");
                int sum = arr.Sum(index + 1, arr.N - 1);
                Console.WriteLine($"Сума елементiв правiше вiд знайденого: {sum}");
            }
            else
            {
                Console.WriteLine("Немає кратних 3 елементiв.");
            }
        }
    }
}