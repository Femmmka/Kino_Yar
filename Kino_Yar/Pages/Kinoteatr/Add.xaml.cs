﻿using Kino_Yar.Classes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kino_Yar.Pages.Kinoteatr
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        KinoteatrContext kinoteatr;
        public Add(KinoteatrContext kinoteatr = null)
        {
            InitializeComponent();
            if (kinoteatr != null)
            {
                this.kinoteatr = kinoteatr;
                name.Text = kinoteatr.Name;
                countZal.Text = kinoteatr.CountZal.ToString();
                count.Text = kinoteatr.CountZal.ToString();
                bthAdd.Content = "Изменить";
            }
        }

        private void AddRecord(object sender, RoutedEventArgs e)
        {
            int countZalInt = 0;
            int countInt = 0;

            if (name.Text == "")
            {
                MessageBox.Show("Необходимо указать наименование");
                return;
            }
            if (countZal.Text == "" || int.TryParse(countZal.Text, out countZalInt) == false)
            {
                MessageBox.Show("Необходимо указать количество залов");
                return;
            }
            if (count.Text == "" || int.TryParse(count.Text, out countInt) == false)
            {
                MessageBox.Show("Необходимо указать количество мест");
                return;
            }
            if (this.kinoteatr == null)
            {
                KinoteatrContext newKinoteatr = new KinoteatrContext(
                    0,
                    name.Text,
                    countZalInt,
                    countInt
                    );
                newKinoteatr.Add();
                MessageBox.Show("Запись успешно добавлена.");
            }
            else
            {
                kinoteatr = new KinoteatrContext(
                    kinoteatr.Id,
                    name.Text,
                    countZalInt,
                    countInt);
                kinoteatr.Update();
                MessageBox.Show("Запись успешно обновлена.");
            }
            MainWindow.init.OpenPage(new Pages.Kinoteatr.Main());
        }
    }
}

