using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System;
using System.Collections.Generic;

namespace Idojaras
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		List<List<string>> idojarasLista = Read_File(@"..\..\..\..\idojaras.txt");

		public MainWindow()
		{
			InitializeComponent();
		}

		private static List<List<string>> Read_File(string filePath)
		{
			List<List<string>> idojarasLista = new List<List<string>>();

			try
			{
				// Fájl sorainak beolvasása és feldolgozása
				using (StreamReader sr = new StreamReader(filePath))
				{
					string sor;
					while ((sor = sr.ReadLine()) != null)
					{
						// Sor szétválasztása városra és időjárásra+hőmérsékletre
						string[] sorReszek = sor.Split(' ');
						string varos = sorReszek[0];
						string idojaras = sorReszek[1] + " " + sorReszek[2];

						// 2 elemű lista létrehozása és hozzáadása a fő listához
						idojarasLista.Add(new List<string> { varos, idojaras });
					}
				}

				return idojarasLista;
			}
			catch (Exception e)
			{
				MessageBox.Show("Hiba történt a fájl olvasása közben: " + e.Message);
				return idojarasLista;
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string varos = text_box.Text;
			int i = 0;
            while (i < idojarasLista.Count && idojarasLista[i][0] == varos)  
            {
				i++;
            }
			if (i < idojarasLista.Count)
			{
				MessageBox.Show(idojarasLista[0] + idojarasLista[i][1]);
			}
			else
			{
				MessageBox.Show("Nincs ilyen város.");
			}
			MessageBox.Show(varos);
        }
	}
}