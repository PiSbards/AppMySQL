using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppMySQL.Controller;

namespace AppMySQL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCadastrar : ContentPage
    {
        public PageCadastrar()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            MySQLConn.InserirPessoa(txtNome.Text,txtIdade.Text,txtCidade.Text);
            DisplayAlert("Inserção", "Pessoa cadastrada com sucesso!", "OK");
            Navigation.PushAsync(new PageListar());
        }
    }
}