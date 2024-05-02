using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjetoUnited_Sof
{
    public partial class Window1 : Window
    {
        // Lista de produtos
        private List<Produto> produtos;

        public Window1()
        {
            InitializeComponent();

            // Inicializa a lista de produtos (você precisa preencher essa lista com os dados do banco)
            produtos = new List<Produto>();

            // Adiciona alguns dados de exemplo (você pode remover isso quando conectar ao banco de dados)
            produtos.Add(new Produto { Codigo = 1, Modelo = "Modelo 1", Marca = "Marca 1", Valor = 100, Estoque = 10 });
            produtos.Add(new Produto { Codigo = 2, Modelo = "Modelo 2", Marca = "Marca 2", Valor = 200, Estoque = 20 });

            // Exibe os dados no DataGrid
            tabDados.ItemsSource = produtos;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            // Obter o código de pesquisa do TextBox
            string codigoPesquisa = txtPesquisaCodigo.Text;

            // Verificar se o código de pesquisa não está vazio
            if (!string.IsNullOrWhiteSpace(codigoPesquisa))
            {
                // Filtrar os produtos com base no código de pesquisa
                var resultado = produtos.Where(p => p.Codigo.ToString().Contains(codigoPesquisa)).ToList();

                // Atualizar a fonte de dados do DataGrid com os resultados da pesquisa
                tabDados.ItemsSource = resultado;
            }
            else
            {
                // Se o campo de pesquisa estiver vazio, mostrar todos os produtos
                tabDados.ItemsSource = produtos;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para o botão "Cadastrar"
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Lógica para o botão "Excluir" ou "Editar"
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Lógica para o evento de seleção do DataGrid, se necessário
        }
    }

    // Classe modelo para Produto (você pode ter essa classe em outro arquivo)
    public class Produto
    {
        public int Codigo { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public decimal Valor { get; set; }
        public int Estoque { get; set; }
    }
}
