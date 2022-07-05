﻿using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.WPF.DI;
using ProviderSystemManager.WPF.ViewModels.Tables.CreateUpdate.Update;
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

namespace ProviderSystemManager.WPF.Views.Tables.CreateUpdate.Update
{
    /// <summary>
    /// Interaction logic for FirmUpdateWindow.xaml
    /// </summary>
    public partial class FirmUpdateWindow : Window
    {
        public FirmUpdateWindow(FirmGetDto dto)
        {
            InitializeComponent();

            var vm = IoC.Resolve<FirmUpdateWindowViewModel>();

            vm.Dto = dto;
            DataContext = vm;
        }
    }
}