using Storonkin.CalculationPaints.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Storonkin.CalculationPaints
{
    /// <summary>
    /// Логика взаимодействия для Главной формы
    /// </summary>
    public partial class MainWindow : Window
    {

        
        public MainWindow()
        {
            InitializeComponent();
            
        }



        // TODO: Доделать окно, дверь, объем банки, найти где лейблы вывода результата, так же доделать стены

        public double TempSquareWall;
        public double TempSquareDoor;
        public double TempSquareWindow;
        public int TempLayer;
        public int TempPrice;
        public double[] wall_H = new double[4];
        public double[] wall_W = new double[4];
        double Temp;
        // Кнопка Результат
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wall_H[0] = double.Parse(wallheight1.Text);
            wall_H[1] = double.Parse(wallheight2.Text);
            wall_H[2] = double.Parse(wallheight3.Text);
            wall_H[3] = double.Parse(wallheight4.Text);
            wall_W[0] = double.Parse(wallwidth1.Text);
            wall_W[1] = double.Parse(wallwidth2.Text);
            wall_W[2] = double.Parse(wallwidth3.Text);
            wall_W[3] = double.Parse(wallwidth4.Text);
            TempLayer = int.Parse(Layer.Text);
            TempPrice = int.Parse(Price.Text);

            TempSquareWall = Calc.SquareWall(wall_W, wall_H);
            TempSquareDoor = Calc.SquareDoor(double.Parse(doorheight.Text), double.Parse(doorwidth.Text));
            TempSquareWindow = Calc.SquareWindow(double.Parse(heightWindow.Text), double.Parse(widthWindow.Text));


            // Square - площадь стен Layer - кол-во слоёв Price - цена за банку SquareWindow - площадь окон
            // Площадь окон должна быть меньше площади стен
            if (TempSquareWall > TempSquareWindow)
            {
                // Вывод стоимость краски для покраски стен
                 Temp = Calc.Result(TempSquareWall, TempLayer, TempPrice, TempSquareWindow,TempSquareDoor);
                 
                // Вывод количества банок с запасом для покупки
                OutCount.Content = Calc.ResCount(TempSquareWall, TempLayer, TempSquareWindow, TempSquareDoor).ToString();
                WarringLabel.Content = "";
                //Проверка типа краски и изменение цены
                if ((bool)rbtn_acrl.IsChecked)
                    OutPrice.Content = Temp;
                if ((bool)rbtn_lateks.IsChecked)
                    OutPrice.Content = Temp * 1.15;


            }
            // Вывод ошибкок
            else if ((double.Parse(Layer.Text) < 1))
                WarringLabel.Content = "Кол-во слоев не может быть меньше 1 или отрицательные";
            else
                WarringLabel.Content = "Площадь окон не может быть больше площади стен";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        // Ввод валидация 
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //Ввод только чисел
            Regex regexAZ = new Regex("[^a-zA-Z]+");
            Regex regexRus = new Regex("[^а-яА-ЯZ]+");
            Regex regex = new Regex("[^0-9]+");

            e.Handled = regex.IsMatch(e.Text);
            // Проверка ввода букв
            if (e.Handled == regexAZ.IsMatch(e.Text) || regexRus.IsMatch(e.Text))
            {
                WarringLabel.Content = "Ввод букв запрещен";
            }
            else
                WarringLabel.Content = "";





        }


        
        private void СleanTB_Click(object sender, RoutedEventArgs e)
        {
            LoopVisualTree(this);
        }
        void LoopVisualTree(DependencyObject obj)//обнуление текст боксов
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {

                if (obj is TextBox)
                {
                    ((TextBox)obj).Text = null;
                }
                // РЕКУРСИЯ
                LoopVisualTree(VisualTreeHelper.GetChild(obj, i));
            }

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
