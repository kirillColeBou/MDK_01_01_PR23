﻿using System;
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
using OrderingGifts_Тепляков.Classes;
using OrderingGifts_Фамилия.Pages;
using OrderingGifts_Фамилия.Pages.PagesItem;

namespace OrderingGifts_Тепляков
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<GiftContext> AllGifts = new GiftContext().AllGifts();
        public List<CategoryContext> AllCategories = new CategoryContext().AllCategories();
        public List<RangeContext> AllRanges = new RangeContext().AllRanges();
        public static MainWindow init;
        public MainWindow()
        {
            InitializeComponent();
            init = this;
            OpenPages(pages.main);
        }

        public enum pages
        {
            main, add, range, addCategory
        }

        public void OpenPages(pages _pages)
        {
            if (_pages == pages.main)
                frame.Navigate(new Main());
            if (_pages == pages.add)
                frame.Navigate(new Add());
            if (_pages == pages.range)
                frame.Navigate(new Range());
            if (_pages == pages.addCategory)
                frame.Navigate(new Pages.PagesItem.AddCategory());
        }
    }
}
