using Storonkin.CalculationPaints.Class;
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

        





        double Temp;
        // Кнопка Результат
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Square - площадь стен Layer - кол-во слоёв Price - цена за банку SquareWindow - площадь окон
            // Площадь окон должна быть меньше площади стен
            if (double.Parse(Square.Text) > double.Parse(SquareWindow1.Text))
            {
                // Вывод стоимость краски для покраски стен
                 Temp = Math.Round(Calc.Result(double.Parse(Square.Text), int.Parse(Layer.Text), int.Parse(Price.Text), double.Parse(SquareWindow1.Text)), 2);
                 OutPrice.Content = Temp;
                // Вывод количества банок с запасом для покупки
                OutCount.Content = Calc.ResCount(double.Parse(Square.Text), int.Parse(Layer.Text), double.Parse(SquareWindow1.Text)).ToString();
                WarringLabel.Content = "";
                //Проверка типа краски и изменение цены
                //if (ComboBox1.SelectedItem.ToString() == "Акриловая")
                   // OutPrice.Content = Temp;
                //else if (ComboBox1.SelectedItem.ToString() == "Латексная")
                    //OutPrice.Content = Temp * 1.10;
               // else if (ComboBox1.SelectedItem.ToString() == "Акрилатная")
                    //OutPrice.Content = Temp * 1.15;
                //else if (ComboBox1.SelectedItem.ToString() == "Водно-диспансерная")
                    //OutPrice.Content = Temp * 1.20;

            

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
    }
}
