using Microsoft.AspNetCore.SignalR.Client;

namespace TowerDefense.Client
{
    public partial class MainForm : Form
    {
        HubConnection connection;
        public MainForm()
        {
            InitializeComponent();
            connection = new HubConnectionBuilder()
                .WithUrl(Properties.Settings.Default.ApiUrl)
                .Build();
        }

        private async void HelloButton_Click(object sender, EventArgs e)
        {
            await connection.SendAsync("HelloServer", nameTextBox.Text);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await connection.StartAsync();

            connection.On<string>("HelloClient", (user) =>
            {
                response.Text = user;
            });
        }
    }
}
