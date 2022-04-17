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
using System.Windows.Shapes;

namespace PoserParser
{
	/// <summary>
	/// Логика взаимодействия для FullInfo.xaml
	/// </summary>
	public partial class FullInfo : Window
	{
		public FullInfo(string title)
		{
			this.Title = title;
			InitializeComponent();
		}
	}
}
