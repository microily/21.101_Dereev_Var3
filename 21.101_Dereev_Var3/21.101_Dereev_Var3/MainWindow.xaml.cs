using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _21._101_Dereev_Var3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int[] GenerateAndSortArray(int N, int minRange, int maxRange)
        {
            Random random = new Random();
            int[] array = new int[N];

            for (int i = 0; i < N; i++)
            {
                array[i] = random.Next(minRange, maxRange + 1);
            }

            return array;
        }

        private int[] SortArray(int[] array)
        {
            return array.OrderBy(x => x % 2).ThenBy(x => x).ToArray();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(number.Text, out int N) &&
               int.TryParse(MinBorder.Text, out int minRange) &&
               int.TryParse(MaxBorder.Text, out int maxRange))
            {
                if (minRange >= maxRange)
                {
                    result.Text = "Минимальное значение диапазона должно быть меньше максимального значения.";
                    return;
                }

                int[] array = GenerateAndSortArray(N, minRange, maxRange);
                string originalArrayStr = "Исходный массив: " + string.Join(", ", array);

                array = SortArray(array);
                string sortedArrayStr = "Отсортированный массив: " + string.Join(", ", array);

                result.Text = originalArrayStr + "\n" + sortedArrayStr;
            }
            else
            {
                MessageBox.Show("Ошибка! Введите корректные значения.");
            }
        }
    }
}
