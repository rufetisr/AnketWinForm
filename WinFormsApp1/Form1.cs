using Newtonsoft.Json;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<User> users = new();
        private void button1_Click(object sender, EventArgs e)
        {
            var select = radioButton1.Checked ? true : false;

            var user = new User()
            {
                Name = textBox2.Text,
                Surname = textBox3.Text,
                FatherName = textBox4.Text,
                Country = textBox5.Text,
                City = textBox6.Text,
                PhoneNum = maskedTextBox1.Text,
                birthday = dateTimePicker1.Value,

            };
            if (select)
            {
                user.Gender = "Kisi";
            }
            else
            {
                user.Gender = "Qadin";
            }


            users.Add(user);
            var str = JsonConvert.SerializeObject(user, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText($"{textBox1.Text}.json", str);

        }

        private void Load_button_Click(object sender, EventArgs e)
        {
            if (File.Exists($"{textBox1.Text}.json"))
            {
                var user = new User();
                var jsonStr = File.ReadAllText($"{textBox1.Text}.json");

                user = JsonConvert.DeserializeObject<User>(jsonStr);
                textBox2.Text = user?.Name;
                textBox3.Text = user?.Surname;
                textBox4.Text = user?.FatherName;
                textBox5.Text = user?.Country;
                textBox6.Text = user?.City;
                maskedTextBox1.Text = user?.PhoneNum;
                dateTimePicker1.Value = user.birthday;
                if (user.Gender == "Kisi")
                {
                    radioButton1.Select();
                }
                else if (user.Gender == "Qadin")
                {
                    radioButton2.Select();
                }
            }
            else
            {
                try
                {
                    throw new DirectoryNotFoundException($"{textBox1.Text} adinda Anket tapilmadi");
                }
                catch (Exception ex)
                {
                   var dr = MessageBox.Show(ex.Message, "Error",MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (dr == DialogResult.Retry)
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        maskedTextBox1.Text = "";
                        dateTimePicker1.Value = DateTime.Now;
                    }
                }
            }
        }
    }
}
