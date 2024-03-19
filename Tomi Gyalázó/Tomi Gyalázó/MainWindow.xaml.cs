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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tomi_Gyalázó
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		string next = "X";
		List<Button> Buttons = new List<Button>();
		public MainWindow()
		{
			InitializeComponent();
			InitializeButtons();
		}
		private void InitializeButtons()
		{
			for (int sor = 0; sor < 3; sor++)
			{
				for(int oszlop = 0; oszlop < 3; oszlop++)
				{
					Button button = new Button();
					button.Click += Button_Click_Event;
					button.FontSize = 30;
					button.Content = "";
					Grid.SetRow(button, sor);
					Grid.SetColumn(button, oszlop);
					GameGrid.Children.Add(button);
					Buttons.Add(button);
				}
			}
		}
		private void Button_Click_Event(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			button.Content = next;
			ChangeEvent();
		}
		private void ChangeEvent()
		{
			if (next == "X")
			{
				next = "0";
			}
			else
			{
				next = "X";
			}
		}
		private void Set(Button button)
		{
			if (button.Content == "")
			{
				button.Content = next;
				ChangeEvent();
			}
		}
	}
}
