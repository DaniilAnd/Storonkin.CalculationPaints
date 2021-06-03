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
            Result.IsEnabled = false;
            rbtn_acrl.IsChecked = true;

        }



        // TODO: Доделать окно, дверь, объем банки, найти где лейблы вывода результата, так же доделать стены

        public double TempSquareWall;
        public double TempSquareDoor;
        public double TempSquareWindow;
        public double TempResultsCount;
        public int TempLayer;
        public int TempPrice;
        public double[] wall_H = new double[4];
        public double[] wall_W = new double[4];
        double Temp;
        // Кнопка Результат
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Заполнение данных.
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

            //Вычисление промежуточных значений
            TempSquareWall = Calc.SquareWall(wall_W, wall_H);
            TempSquareDoor = Calc.SquareDoor(double.Parse(doorheight.Text), double.Parse(doorwidth.Text));
            TempSquareWindow = Calc.SquareWindow(double.Parse(heightWindow.Text), double.Parse(widthWindow.Text));


            
            // Площадь окон должна быть меньше площади стен
            if (TempSquareWall > TempSquareWindow)
            {
                // Вывод стоимость краски для покраски стен
                TempResultsCount = Math.Floor(Calc.ResCount(TempSquareWall, TempLayer, TempSquareWindow, TempSquareDoor));
                Temp = Math.Round(Calc.Result(TempResultsCount,  TempPrice),2);
                
                // Вывод количества банок с запасом для покупки
                OutCount.Content = TempResultsCount;
                WarringLabel.Content = "";

                //Проверка типа краски и изменение цены
                if ((bool)rbtn_acrl.IsChecked)
                    OutPrice.Content = Temp;
                if ((bool)rbtn_lateks.IsChecked)
                    OutPrice.Content = Temp * 1.15;

                if (TempResultsCount < 3)
                {
                    other.Content = "750";

                }
                else if (TempResultsCount > 3 || TempResultsCount < 10)
                    other.Content = "1300";
                else if (TempResultsCount > 11 || TempResultsCount < 20)
                    other.Content = "2000";

            }
            // Вывод логических ошибкок
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
            //Regex regexAZ = new Regex("[^a-zA-Z]+");
            //Regex regexRus = new Regex("[^а-яА-ЯZ]+");

            Regex regex = new Regex("[^0-9,]+");

            e.Handled = regex.IsMatch(e.Text);
            

            // Проверка ввода букв
            //if (e.Handled == regexAZ.IsMatch(e.Text) || regexRus.IsMatch(e.Text))
            //{
            //    WarringLabel.Content = "Ввод букв запрещен";
            //}
            //else if (e.Handled == regex.IsMatch(e.Text))
            //    WarringLabel.Content = "";
            //else
            //    WarringLabel.Content = "";





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
        // Активация/Деактивация кнопки/запрет ввода первым нуля и запятой
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (doorheight.Text.StartsWith("0"))
                doorheight.Text = doorheight.Text.Substring(1);
            if (doorheight.Text.StartsWith(","))
                doorheight.Text = doorheight.Text.Substring(1);

            if (doorwidth.Text.StartsWith("0"))
                doorwidth.Text = doorwidth.Text.Substring(1);
            if (doorwidth.Text.StartsWith(","))
                doorwidth.Text = doorwidth.Text.Substring(1);

            if (widthWindow.Text.StartsWith("0"))
                widthWindow.Text = widthWindow.Text.Substring(1); 
            if (widthWindow.Text.StartsWith(","))
                widthWindow.Text = widthWindow.Text.Substring(1);

            if (heightWindow.Text.StartsWith("0"))
                heightWindow.Text = heightWindow.Text.Substring(1);
            if (heightWindow.Text.StartsWith(","))
                heightWindow.Text = heightWindow.Text.Substring(1);

            if (wallheight1.Text.StartsWith("0"))
                wallheight1.Text = wallheight1.Text.Substring(1); 
            if (wallheight1.Text.StartsWith(","))
                wallheight1.Text = wallheight1.Text.Substring(1);

            if (wallheight2.Text.StartsWith("0"))
                wallheight2.Text = wallheight2.Text.Substring(1);
            if (wallheight2.Text.StartsWith(",")) wallheight2.Text = wallheight2.Text.Substring(1);

            if (wallheight3.Text.StartsWith("0"))
                wallheight3.Text = wallheight3.Text.Substring(1);
            if (wallheight3.Text.StartsWith(","))
                wallheight3.Text = wallheight3.Text.Substring(1);

            if (wallheight4.Text.StartsWith("0"))
                wallheight4.Text = wallheight4.Text.Substring(1);
            if (wallheight4.Text.StartsWith(","))
                wallheight4.Text = wallheight4.Text.Substring(1);


            if (wallwidth1.Text.StartsWith("0"))
                wallwidth1.Text = wallwidth1.Text.Substring(1);
            if (wallwidth1.Text.StartsWith(","))
                wallwidth1.Text = wallwidth1.Text.Substring(1);

            if (wallwidth2.Text.StartsWith("0"))
                wallwidth2.Text = wallwidth2.Text.Substring(1);
            if (wallwidth2.Text.StartsWith(","))
                wallwidth2.Text = wallwidth2.Text.Substring(1);

            if (wallwidth3.Text.StartsWith("0"))
                wallwidth3.Text = wallwidth3.Text.Substring(1);
            if (wallwidth3.Text.StartsWith(","))
                wallwidth3.Text = wallwidth3.Text.Substring(1);

            if (wallwidth4.Text.StartsWith("0"))
                wallwidth4.Text = wallwidth4.Text.Substring(1);
            if (wallwidth4.Text.StartsWith(","))
                wallwidth4.Text = wallwidth4.Text.Substring(1);

            if (Layer.Text.StartsWith("0"))
                Layer.Text = Layer.Text.Substring(1);
            if (Layer.Text.StartsWith(","))
                Layer.Text = Layer.Text.Substring(1);

            if (Price.Text.StartsWith("0"))
                Price.Text = Price.Text.Substring(1);
            if (Price.Text.StartsWith(","))
                Price.Text = Price.Text.Substring(1);

            if (wallheight1.Text.Length == 0 || wallheight2.Text.Length == 0 || wallheight3.Text.Length == 0 || wallheight4.Text.Length == 0 ||
                wallwidth1.Text.Length == 0 || wallwidth2.Text.Length == 0 || wallwidth3.Text.Length == 0 || wallwidth4.Text.Length == 0 ||
                Layer.Text.Length == 0 || Price.Text.Length == 0 || heightWindow.Text.Length == 0 || widthWindow.Text.Length == 0 || doorheight.Text.Length == 0 || doorwidth.Text.Length == 0)
            {
                Result.IsEnabled = false;
            }
            else
            {
                Result.IsEnabled = true;
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void inputTestData(object sender, MouseButtonEventArgs e)
        {
            wallheight1.Text = "3";
            wallheight2.Text = "3";
            wallheight3.Text = "3";
            wallheight4.Text = "3";
            wallwidth1.Text = "3";
            wallwidth2.Text = "2";
            wallwidth3.Text = "3";
            wallwidth4.Text = "2";
            Price.Text = "400";
            Layer.Text = "2";
            doorheight.Text = "2";
            doorwidth.Text = "1";
            widthWindow.Text = "1";
            heightWindow.Text = "1";
        }
    }
}
