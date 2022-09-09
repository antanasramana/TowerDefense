using Microsoft.AspNetCore.SignalR.Client;

namespace TowerDefense.Client
{
    public partial class MainForm : Form
    {
        HubConnection connection;
        public MainForm()
        {
            InitializeComponent();
            // TODO: move url to settings
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7042/gameHub")
                .Build();
        }

        private async void helloButton_Click(object sender, EventArgs e)
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
