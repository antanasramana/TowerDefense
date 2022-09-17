using Microsoft.AspNetCore.SignalR.Client;
using TowerDefense.Client.Enums;
using TowerDefense.Shared.Models;

namespace TowerDefense.Client
{
    public partial class MainForm : Form
    {
        HubConnection connection;
        private GamePhase gamePhase;
        public MainForm()
        {
            InitializeComponent();
            connection = new HubConnectionBuilder()
                .WithUrl(Properties.Settings.Default.ApiUrl)
                .Build();
            UpdateGamePhase(GamePhase.Planning);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await connection.StartAsync();

            connection.On<TurnResult>("TurnResult", (turnResut) =>
            {
                response.Text = turnResut.Sum.ToString();
                UpdateGamePhase(GamePhase.Planning);
            });
        }

        private async void EndTurnButton_Click(object sender, EventArgs e)
        {
            if (gamePhase != GamePhase.Planning)
            {
                return;
            }
            UpdateGamePhase(GamePhase.Waiting);
            await connection.SendAsync("EndTurn", new TurnEnd { Number = (int)selectedNumber.Value });
        }

        private void UpdateGamePhase (GamePhase gamePhase)
        {
            this.gamePhase = gamePhase;
            gamePhaseLabel.Text = gamePhase.ToString();
        }
    }
}
