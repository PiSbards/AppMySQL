using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppMySQL.Models;
using AppMySQL.Controller;

namespace AppMySQL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListar : ContentPage
    {
        public PageListar()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lsvPessoas.ItemsSource = MySQLConn.ListarPessoas();
        }

        void NavegarPessoa(Pessoas pessoa)
        {
            PageUpDel upDel = new PageUpDel();
            upDel.pessoa = pessoa;
            Navigation.PushAsync(upDel);
        }

        private void lsvPessoas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                NavegarPessoa(e.SelectedItem as Pessoas);
        }

        private void btnNovo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageCadastrar());
        }
    }
}