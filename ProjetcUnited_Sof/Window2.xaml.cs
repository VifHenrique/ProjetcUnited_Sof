using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace ProjetoUnited_Sof
{
    public partial class Window2 : Window
    {
        // String de conexão com o banco de dados
        string connectionString = "Data Source=SEUSERVIDOR;Initial Catalog=SUA_BASE_DE_DADOS;Integrated Security=True";

        // Objetos para referenciar os controles TextBox no XAML
        private TextBox txtCodigo;
        private TextBox txtModelo;
        private TextBox txtMarca;
        private TextBox txtValor;
        private TextBox txtEstoque;

        public Window2()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Criação dos controles TextBox
            txtCodigo = new TextBox();
            txtModelo = new TextBox();
            txtMarca = new TextBox();
            txtValor = new TextBox();
            txtEstoque = new TextBox();

            // Configuração do layout dos controles
            // (Você precisa ajustar isso de acordo com o layout definido no XAML)
            // Exemplo:
            // txtCodigo.SetValue(Grid.RowProperty, 0);
            // txtCodigo.SetValue(Grid.ColumnProperty, 1);
            // ...

            // Botão para cadastrar
            Button btnCadastrar = new Button();
            btnCadastrar.Content = "Cadastrar";
            btnCadastrar.Click += btnCadastrar_Click;

            // Adição dos controles à janela
            this.Content = new StackPanel()
            {
                Children =
                {
                    txtCodigo,
                    txtModelo,
                    txtMarca,
                    txtValor,
                    txtEstoque,
                    btnCadastrar
                }
            };
        }

        private void CadastrarProduto(int codigo, string modelo, string marca, decimal valor, int estoque)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL parametrizada para inserir um novo produto
                    string query = "INSERT INTO TabelaProdutos (Codigo, Modelo, Marca, Valor, Estoque) " +
                                   "VALUES (@Codigo, @Modelo, @Marca, @Valor, @Estoque)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Adicionando parâmetros
                        command.Parameters.AddWithValue("@Codigo", codigo);
                        command.Parameters.AddWithValue("@Modelo", modelo);
                        command.Parameters.AddWithValue("@Marca", marca);
                        command.Parameters.AddWithValue("@Valor", valor);
                        command.Parameters.AddWithValue("@Estoque", estoque);

                        // Executando a consulta
                        command.ExecuteNonQuery();

                        MessageBox.Show("Produto cadastrado com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar produto: " + ex.Message);
            }
        }

        // Método chamado quando o botão de cadastrar é clicado
        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            // Recuperar os valores dos campos
            int codigo = Convert.ToInt32(txtCodigo.Text);
            string modelo = txtModelo.Text;
            string marca = txtMarca.Text;
            decimal valor = Convert.ToDecimal(txtValor.Text);
            int estoque = Convert.ToInt32(txtEstoque.Text);

            // Chamar o método para cadastrar o produto
            CadastrarProduto(codigo, modelo, marca, valor, estoque);
        }
    }
}
