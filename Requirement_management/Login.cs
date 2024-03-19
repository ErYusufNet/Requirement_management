using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Requirement_management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // SqlConnection bağlantı dizesi oluşturun (diğer bilgileri ekleyin)
            SqlConnection con = new SqlConnection("Data Source=YusufEr\\SQLEXPRESS; Initial Catalog=requirtment; Integrated Security=True;");

            try
            {
                // SQL sorgusunu oluşturun ve parametreleri ekleyin
                string sql = @"SELECT COUNT(*) FROM [dbo].[users2]
                               WHERE [user_name] = @UserName AND [password] = @Password";

                SqlCommand cmd = new SqlCommand(sql, con);

                // Parametreleri ekleyin ve değerlerini belirtin
                cmd.Parameters.AddWithValue("@UserName", Name1.Text);
                cmd.Parameters.AddWithValue("@Password", Password1.Text);

                // Bağlantıyı açın
                con.Open();

                // Sorguyu çalıştırın ve kullanıcı adı ve şifre uyumlu mu kontrol edin
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Loged in");
                    // İşlemleri gerçekleştirin (örneğin, ana formu açabilirsiniz)
                }
                else
                {
                    MessageBox.Show("Id or password is wrong!");
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi verin veya loglayın
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Bağlantıyı kapatın
                con.Close();
            }
        }
    }
}
