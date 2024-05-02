using ProjetcUnited_Sof;
using System;
using System.Data.SqlClient;
using System.Windows;

namespace ProjetoUnited_Sof
{
    public partial class MainWindow : Window
    {
        // String de conexão com o banco de dados
        string connectionString = "Data Source=SEUSERVIDOR;Initial Catalog=SUA_BASE_DE_DADOS;Integrated Security=True";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = pasSenha.Password;

            if (ValidarUsuario(usuario, senha))
            {
                MessageBox.Show("Login bem-sucedido!");

                // Oculta a janela atual
                this.Hide();

                // Cria uma nova instância da janela desejada
                Window1 novaJanela = new Window1();

                // Exibe a nova janela
                novaJanela.Show();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos!");
            }
        }

        private bool ValidarUsuario(string usuario, string senha)
        {
            bool isValid = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM TabelaUsuarios WHERE Usuario = @Usuario AND Senha = @Senha";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", usuario);
                        command.Parameters.AddWithValue("@Senha", senha);

                        int count = (int)command.ExecuteScalar();

                        isValid = (count > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
            }

            return isValid;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }

    internal class txtUsuario
    {
        public static string Text { get; internal set; }
    }
}
