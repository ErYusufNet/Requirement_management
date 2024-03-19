using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Requirement_management
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Register_Click(object sender, EventArgs e)
        {


            {
                // 'Date.Text' üzerinden alınan değeri DateTime türüne çevirin
                DateTime parsedDate = DateTime.Parse(Date.Text);

                // SqlConnection bağlantı dizesi oluşturun (diğer bilgileri ekleyin)
                SqlConnection con = new SqlConnection("Data Source=YusufEr\\SQLEXPRESS; Initial Catalog=requirtment; Integrated Security=True;");

                try
                {
                    // SQL sorgusunu oluşturun ve parametreleri ekleyin
                    string sql = @"INSERT INTO [dbo].[users2]
            (
             [user_name]
            ,[phone_number]
            ,[time]
            ,[email]
            ,[password])
        VALUES
            (@UserName, @Phone, @Date, @Email, @Password)";

                    SqlCommand cmd = new SqlCommand(sql, con);

                    // Parametreleri ekleyin ve değerlerini belirtin
                    cmd.Parameters.AddWithValue("@UserName", UserName.Text);
                    cmd.Parameters.AddWithValue("@Phone", Phone.Text);
                    cmd.Parameters.AddWithValue("@Date", parsedDate); // Çevrilen DateTime değerini kullanın
                    cmd.Parameters.AddWithValue("@Email", Email.Text);
                    cmd.Parameters.AddWithValue("@Password", Password.Text);

                    // UserId parametresini ekleyin
                    //cmd.Parameters.AddWithValue("@UserId", UserId.Text);

                    // Bağlantıyı açın
                    con.Open();

                    // Sorguyu çalıştırın
                    cmd.ExecuteNonQuery();

                    // Başarıyla eklendiğinde kullanıcıya bilgi verin veya diğer işlemleri gerçekleştirin
                    MessageBox.Show("Registered!!");
                }
                catch (Exception ex)
                {
                    // Hata durumunda kullanıcıya bilgi verin veya loglayın
                    MessageBox.Show("Error " + ex.Message);
                }
                finally
                {
                    // Bağlantıyı kapatın
                    con.Close();
                }
            }




        }

        private void Login_Click(object sender, EventArgs e)
        {
            // Yeni login formunu oluşturun
            Login loginForm = new Login();

            // Oluşturulan login formunu gösterin
            loginForm.ShowDialog();

            this.Close();//register formunu kapatir
        }
    }
}