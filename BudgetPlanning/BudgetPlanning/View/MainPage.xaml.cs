using BudgetPlanning.Data;
using BudgetPlanning.Model.Data;
using BudgetPlanning.ViewModels;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BudgetPlanning
{
   
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Frame frame;
        DataGrid dataGrid;

        public static ListView AllOperationEarningsView;
        public static ListView AllOperationExepensesView;
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = new MainWindowViewModel();
            AllOperationEarningsView = new ListView();
            AllOperationExepensesView = new ListView();
      
        }



        private void NavigationViewControl_ItemInvoked(NavigationView navigationView, NavigationViewItemInvokedEventArgs args)
        {
            frame = new Frame();
            navigationView.Content = frame;
         
            switch (navigationView.MenuItems.IndexOf(args.InvokedItemContainer))
            {
                case 0:
                    frame.Content = new OperationEarningPage();
                    break;
                case 1:
                    frame.Content = new OperationExpensePage();
                    break;
                case 2:
                    frame.Content = new CatygoryEarningPage();
                    break;
            }
        }
    }


    public class CatygoryEarningPage : Page
    {
        public CatygoryEarningPage()
        {
            Height = 45;
            Width = 200;
            VerticalAlignment = VerticalAlignment.Center;
            HorizontalAlignment = HorizontalAlignment.Center;
           

            Content = new TextBlock()
            {
                Text = "Введите категорию доходов",
                TextAlignment = TextAlignment.Center,
            };
        }

    }

    public class CatygoryExpensePage : Page
    {
        public CatygoryExpensePage()
        {
            Height = 45;
            Width = 200;
            VerticalAlignment = VerticalAlignment.Center;
            HorizontalAlignment = HorizontalAlignment.Center;
            TextBox textBox = new TextBox();


            Content = new TextBlock()
            {
                Text = "Введите категорию расходов",
                TextAlignment = TextAlignment.Center,
            };
        }

    }



    public class OperationEarningPage:Page
    {
        public OperationEarningPage()
        {
            Content = new DataGrid()
            {
                ItemsSource = new MainWindowViewModel().AllOperationEarnings,
                AutoGenerateColumns = true,       
            };
        }
            
    }

    public class OperationExpensePage : Page
    {
        public OperationExpensePage()
        {
            Content = new DataGrid()
            {
                ItemsSource = new MainWindowViewModel().AllOperationExpenses,
                AutoGenerateColumns = true,
            };
        }
    }

}
