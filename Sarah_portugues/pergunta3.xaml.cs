namespace Sarah_portugues;

public partial class pergunta3 : ContentPage
{
    private bool respondida = false;
    public pergunta3()
	{
		InitializeComponent();
        lblPontuacao.Text = $"Pontos: {ScoreStore.Points}";
    }

    private async void OnResponderClicked(object sender, EventArgs e)
    {
        if (respondida)
        {
            await Navigation.PushAsync(new pergunta4());
            return;
        }

        if (!(rbA.IsChecked || rbB.IsChecked || rbC.IsChecked || rbD.IsChecked))
        {
            lblResultado.Text = "Selecione uma alternativa.";
            return;
        }

        rbA.IsEnabled = false;
        rbB.IsEnabled = false;
        rbC.IsEnabled = false;
        rbD.IsEnabled = false;

        rbA.TextColor = Colors.Green;
        rbA.BackgroundColor = Color.FromArgb("#B3C8E6C9");

        if (rbA.IsChecked)
        {
            ScoreStore.Add(10);
            lblResultado.Text = "Resposta correta!";
            lblResultado.TextColor = Colors.Green;
            lblPontuacao.Text = $"Pontuação: {ScoreStore.Points}";
        }
        else if (rbB.IsChecked || rbC.IsChecked || rbD.IsChecked)
        {
            RadioButton marcada = rbB.IsChecked ? rbB :
                                  rbC.IsChecked ? rbC : rbD;

            marcada.TextColor = Colors.Red;
            marcada.BackgroundColor = Color.FromArgb("#B3FFCDD2");

            lblResultado.Text = "Resposta incorreta.\nA resposta certa é a letra A";
            lblResultado.TextColor = Colors.Red;
            lblPontuacao.Text = $"Pontuação: {ScoreStore.Points}";
        }

        respondida = true;
        btnResponder.Text = "Próxima pergunta";
    }
}