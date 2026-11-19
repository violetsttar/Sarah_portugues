namespace Sarah_portugues;

public partial class pergunta6 : ContentPage
{
    private bool respondida = false;
    public pergunta6()
	{
		InitializeComponent();
        lblPontuacao.Text = $"Pontos: {ScoreStore.Points}";
    }

    private async void OnResponderClicked(object sender, EventArgs e)
    {
        if (respondida)
        {
            await Navigation.PushAsync(new pergunta7());
            return;
        }

        if (!(rbA.IsChecked || rbB.IsChecked || rbC.IsChecked || rbD.IsChecked))
        {
            lblResultado.Text = "Selecione uma alternativa.";
            return;
        }

        rbA.InputTransparent = true;
        rbB.InputTransparent = true;
        rbC.InputTransparent = true;
        rbD.InputTransparent = true;

        bdC.BackgroundColor = Color.FromArgb("#E6A5D6A7");

        if (rbC.IsChecked)
        {
            ScoreStore.Add(10);
            lblResultado.Text = "Resposta correta!";
            lblResultado.TextColor = Colors.Green;
            lblPontuacao.Text = $"Pontos: {ScoreStore.Points}";
        }
        else if (rbA.IsChecked || rbB.IsChecked || rbD.IsChecked)
        {
            if (rbA.IsChecked) bdA.BackgroundColor = Color.FromArgb("#E6EF9A9A");
            if (rbB.IsChecked) bdB.BackgroundColor = Color.FromArgb("#E6EF9A9A");
            if (rbD.IsChecked) bdD.BackgroundColor = Color.FromArgb("#E6EF9A9A");

            lblResultado.Text = "Resposta incorreta.\nA resposta certa é a letra C.";
            lblResultado.TextColor = Colors.Red;
            lblPontuacao.Text = $"Pontos: {ScoreStore.Points}";
        }

        respondida = true;
        btnResponder.Text = "Próxima pergunta";
    }
}