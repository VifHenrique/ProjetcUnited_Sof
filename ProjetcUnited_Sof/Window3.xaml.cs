using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace ProjetoUnited_Sof
{
    public partial class Window2 : Window
    {
        // String de conexão com o banco de dados
        private readonly string connectionString;

        // Objetos para referenciar os controles TextBox no XAML
        private TextBox txtCodigo_editar;
        private TextBox txtModelo_editar;
        private TextBox txtMarca_editar;
        private TextBox txtValor_editar;
        private TextBox txtEstoque_editar;

        // Construtor que recebe a string de conexão como argumento
        public Window2(string connectionString)
        {
            InitializeComponent();

            // Define a string de conexão
            this.connectionString = connectionString;

            // Vincula os objetos aos elementos do XAML
            txtCodigo_editar = new TextBox();
            txtModelo_editar = new TextBox();
            txtMarca_editar = new TextBox();
            txtValor_editar = new TextBox();
            txtEstoque_editar = new TextBox();
        }

        // Método chamado quando o botão de editar é clicado
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            // Recuperar os valores dos campos
            int codigo = Convert.ToInt32(txtCodigo_editar.Text);
            string modelo = txtModelo_editar.Text;
            string marca = txtMarca_editar.Text;
            decimal valor = Convert.ToDecimal(txtValor_editar.Text);
            int estoque = Convert.ToInt32(txtEstoque_editar.Text);

            // Chamar o método para editar o produto
            EditarProduto(codigo, modelo, marca, valor, estoque);
        }

        private void EditarProduto(int codigo, string modelo, string marca, decimal valor, int estoque)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL parametrizada para atualizar as informações do produto
                    string query = "UPDATE TabelaProdutos SET Modelo = @Modelo, Marca = @Marca, Valor = @Valor, Estoque = @Estoque " +
                                   "WHERE Codigo = @Codigo";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Adicionando parâmetros
                        command.Parameters.AddWithValue("@Modelo", modelo);
                        command.Parameters.AddWithValue("@Marca", marca);
                        command.Parameters.AddWithValue("@Valor", valor);
                        command.Parameters.AddWithValue("@Estoque", estoque);
                        command.Parameters.AddWithValue("@Codigo", codigo);

                        // Executando a consulta
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Produto editado com sucesso!");
                        else
                            MessageBox.Show("Nenhum produto encontrado com o código especificado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar produto: " + ex.Message);
            }
        }
    }
}
